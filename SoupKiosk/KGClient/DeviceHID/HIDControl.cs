using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KGClient
{
    public class HIDControl
    {
        SerialPort serialPort = new SerialPort();
        Queue data = new Queue();
        MainWindow mainWindow = null;
        public HIDControl(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public bool HID_SerialOpen(string port)
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.PortName = port;
                    serialPort.BaudRate = 9600;
                    serialPort.DataBits = 8;
                    serialPort.StopBits = StopBits.One;
                    serialPort.Parity = Parity.None;
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(serial_Received);
                    serialPort.Open();


                    if (serialPort.IsOpen)
                    {

                        return true;
                    }
                    else
                    {
                        serialPort.Close();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
                return false;
            }
        }

        public bool HID_SerialClose()
        {
            serialPort.Close();

            if (serialPort.IsOpen)
                return true;
            else
                return false;
        }

        private void serial_Received(object sender, SerialDataReceivedEventArgs e)
        {
            string getData = serialPort.ReadExisting();
            mainWindow.ReceivedHIDData(getData);
        }
    }

}
