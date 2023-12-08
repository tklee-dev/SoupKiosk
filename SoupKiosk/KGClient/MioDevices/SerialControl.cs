using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KGClient
{
    public class SerialControl : DisposeBase
    {

        public static string[] GetSerialPortNames()
        {
            int num;
            // 10이 넘어가는 포트가 있어도 순서대로 정렬하여 표시하기 위해
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }

        public enum ReadModes { SingleByte, Block };

        public ReadModes ReadMode { get; set; } = ReadModes.SingleByte;

        /// <summary>
        /// COM Port 이름 ex) "COM1", "COM2"
        /// </summary>
        public string Port { get { return serialPort.PortName; } set { serialPort.PortName = value; } }

        /// <summary>
        /// Default : 38400
        /// </summary>
        public int BaudRate { get { return serialPort.BaudRate; } set { serialPort.BaudRate = value; } }

        /// <summary>
        /// Default : 8
        /// </summary>
        public int DataBits { get { return serialPort.DataBits; } set { serialPort.DataBits = value; } }

        /// <summary>
        /// Default : Parity.None;
        /// </summary>
        public Parity Parity { get { return serialPort.Parity; } set { serialPort.Parity = value; } }

        /// <summary>
        /// Default : StopBits.One;
        /// </summary>
        public StopBits StopBits { get { return serialPort.StopBits; } set { serialPort.StopBits = value; } }

        public bool RtsEnable { get => serialPort.RtsEnable; set => serialPort.RtsEnable = value; }

        private SerialPort serialPort;
        private CancellationTokenSource tokenSource;
        private Task ReadTask;

        public SerialControl()
        {
            serialPort = new SerialPort();
            serialPort.PortName = "COM1";
            serialPort.BaudRate = 38400;
            serialPort.DataBits = 8;
            serialPort.Parity = System.IO.Ports.Parity.Odd;
            serialPort.StopBits = System.IO.Ports.StopBits.One;
            //serialPort.Disposed += serialPort_Disposed;
            //serialPort.DataReceived += serialPort_DataReceived;
        }

        protected override void DisposeManaged()
        {
            //serialPort.DataReceived -= serialPort_DataReceived;

            this.Close();

            serialPort.Dispose();
            serialPort = null;
        }


        public void Open(string portName)
        {
            if (!SerialPort.GetPortNames().Contains(portName))
                throw new Exception("해당 포트가 존재하지 않습니다. 포트 : " + this.Port);

            this.Port = portName;
            Open();
        }


        public void Open()
        {
            serialPort.Open();
            if (serialPort.IsOpen)
            {
                GC.SuppressFinalize(serialPort.BaseStream);
                tokenSource = new CancellationTokenSource();
                ReadTask = Task.Run(() => ReadProc());
            }
        }

        public void Close()
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    GC.ReRegisterForFinalize(serialPort.BaseStream);
                    tokenSource.Cancel();
                    ReadTask.Wait();
                }
                catch (AggregateException)
                {
                    Debug.WriteLine("Port Closed");
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                tokenSource.Dispose();
            }
        }

        public bool IsOpen => serialPort.IsOpen;

        private async Task ReadProc()
        {
            int blockLimit = 4096;
            byte[] buffer = new byte[blockLimit];
            serialPort.BaseStream.ReadTimeout = 1000;
            tokenSource.Token.Register(() =>
            {
                serialPort.Close();
                Console.WriteLine("포트 Close");
            });

            while (true)
            {
                try
                {
                    int actualLength = await serialPort.BaseStream.ReadAsync(buffer, 0, buffer.Length);

                    byte[] received = new byte[actualLength];
                    Buffer.BlockCopy(buffer, 0, received, 0, actualLength);

                    if (ReadMode == ReadModes.SingleByte)
                    {
                        for (int i = 0; i < actualLength; i++)
                            _OnDataReceived?.Invoke(this, new OnDataReceivedEventArgs(received[i]));
                    }
                    else
                        _OnBlockReceived?.Invoke(this, new OnBlockReceivedEventArgs(received));
                }
                catch (OperationCanceledException)
                {
                    Debug.WriteLine("Cancelled Read Serial Task Task - OperationCanceledException");
                    return;
                }
                catch (IOException exc)
                {
                    if (tokenSource.IsCancellationRequested)
                        Debug.WriteLine("Cancelled Read Serial Task Task - IOException");
                    else
                        Debug.WriteLine(exc);
                    return;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    if (tokenSource.IsCancellationRequested)
                    {
                        Debug.WriteLine("Cancelled Read Serial Task Task - Exception");
                        return;
                    }
                }
            }
        }


        public void Send(byte[] bytes)
        {
            if (serialPort != null && serialPort.IsOpen)
                serialPort.Write(bytes, 0, bytes.Length);
        }

        public void Send(String str)
        {
            if (serialPort != null && serialPort.IsOpen)
                serialPort.Write(str);
        }

        public void Send(byte b)
        {
            Send(new byte[] { b });
        }

        public void Send(char c)
        {
            Send(new byte[] { (byte)c });
        }

        public event EventHandler<OnDataReceivedEventArgs> OnDataReceived
        {
            add { _OnDataReceived += value; }
            remove { _OnDataReceived -= value; }
        }

        private EventHandler<OnDataReceivedEventArgs> _OnDataReceived;

        public event EventHandler<OnBlockReceivedEventArgs> OnBlockReceived
        {
            add { _OnBlockReceived += value; }
            remove { _OnBlockReceived -= value; }
        }

        private EventHandler<OnBlockReceivedEventArgs> _OnBlockReceived;
    }

    public class OnDataReceivedEventArgs : System.EventArgs
    {
        public OnDataReceivedEventArgs(byte data)
        {
            this.Data = data;
        }

        public byte Data { get; private set; }
    }

    public class OnBlockReceivedEventArgs : System.EventArgs
    {
        public OnBlockReceivedEventArgs(byte[] block)
        {
            this.Block = block;
        }

        public byte[] Block { get; private set; }
    }
}
