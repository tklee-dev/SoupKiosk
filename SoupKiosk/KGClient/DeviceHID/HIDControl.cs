﻿using System;
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

        public bool HID_SerialOpen()
        {
            if (!serialPort.IsOpen)
            {
                serialPort.PortName = "COM4";
                serialPort.BaudRate = 9600;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.Parity = Parity.None;
                serialPort.DataReceived += new SerialDataReceivedEventHandler(serial_Received);
                serialPort.Open();


                if (serialPort.IsOpen)
                    return true;
                else
                    return false;
            }
            else
            {
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
            MessageBox.Show(getData);
        }
    }

}
