using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace IMU_sensor_headtracker
{
    class Udp_server_client 
    {

        public UdpClient client;
        public IPEndPoint endpoint_ip;
        public Socket sending_socket;

        public int open_conn(int listenPort)
        {

            try
            {
                client = new UdpClient(listenPort);
                endpoint_ip = new IPEndPoint(IPAddress.Any, listenPort);
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
                byte[] received_bytes = client.Receive(ref endpoint_ip);

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


        public int client_conn(string ip_address, int sendPort)
        {
            try
            {
                sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPAddress send_to_address = IPAddress.Parse(ip_address); //###.###.###.### format
                endpoint_ip = new IPEndPoint(send_to_address, sendPort);
                return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 1;
            }

        }

        public int send_data(double[] data)
        {


            //Não usa Encoding - BlockCopy
            byte[] send_buffer = new byte[data.Length * sizeof(double)];
            System.Buffer.BlockCopy(data, 0, send_buffer, 0, send_buffer.Length);

            //byte[] send_buffer = Encoding.ASCII.GetBytes(data); //USAR ENCODING

            try
            {
                sending_socket.SendTo(send_buffer, endpoint_ip);
                return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 1;
            }
        }

    }
}
