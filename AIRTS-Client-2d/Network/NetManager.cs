using AiRTServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AIRTS_Client_2d.Network
{
    class NetManager
    {
        private static NetManager m_Instance;
        private Socket m_Socket;
        private ClientPacketProcessor m_PacketProcessor;

        public Socket Socket { get => m_Socket; set => m_Socket = value; }

        public NetManager()
        {
            m_Instance = this;
            m_PacketProcessor = new ClientPacketProcessor();
        }

        public bool Connect(String p_Ip, int p_Port)
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(p_Ip);
                IPEndPoint endPoint = new IPEndPoint(ipAddress, p_Port);

                m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                m_Socket.Connect(endPoint);
                Console.WriteLine("[INFO] Network connected to " + endPoint.Address.ToString() + ":" + p_Port);
            } catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void Update()
        {
            if (m_Socket == null)
                return;
            List<Socket> l_ReadClients = new List<Socket>
            {
                m_Socket
            };

            Socket.Select(l_ReadClients, null, null, 5000000);

            foreach (Socket l_Socket in l_ReadClients)
            {
                Packet l_Packet = Packet.Receive(l_Socket);
                if (l_Packet == null)
                {
                    l_Socket.Close();
                }
                else
                    Task.Run(() => { if (m_PacketProcessor.Processor().ContainsKey(l_Packet.Type)) { m_PacketProcessor.Processor()[l_Packet.Type](l_Packet); } });
            }
        }

        public static NetManager Instance()
        {
            return m_Instance ?? new NetManager();
        }
    }
}
