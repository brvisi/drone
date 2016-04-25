using System;
using System.IO.Ports;
using System.Windows;

namespace IMU_module
{
    class SerialData
    {

        public SerialPort port;

        public int OpenConn(string S_port, int I_baudrate)
        {

            try
            {
                port = new SerialPort();
                port.BaudRate = I_baudrate;
                port.PortName = S_port;
                port.Open();
                return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 1;
            }
        }

        public string[] receive_serial_data()
        {
            try
            {
                string received_data = port.ReadLine();
                return received_data.Split(',');

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }


    }
}
