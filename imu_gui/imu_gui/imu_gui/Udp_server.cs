using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace IMU_sensor_headtracker
{
    class Udp_server 
    {

        public UdpClient client;
        public IPEndPoint client_ip_address;

        public int open_conn(int listenPort)
        {

            try
            {
                client = new UdpClient(listenPort);
                client_ip_address = new IPEndPoint(IPAddress.Any, listenPort);
                return 0;
            }
                catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 1;
            }
        }

 
        public string[] receive_data()
        {
            try
            {
                byte[] received_bytes = client.Receive(ref client_ip_address);

                string received_data = Encoding.ASCII.GetString(received_bytes, 0, received_bytes.Length); //converte array de bytes em string
                string[] line_array = received_data.Split('#'); //end of line character (tira fora)
                return line_array[0].Split(','); //divide o CSV nas virgulas
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

    }
}
