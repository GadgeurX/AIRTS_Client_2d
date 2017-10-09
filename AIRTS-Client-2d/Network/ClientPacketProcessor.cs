using AIRTS_Client_2d.Scene;
using AiRTServer;
using AiRTServer.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRTS_Client_2d.Network
{
    public class ClientPacketProcessor
    {
        public delegate void ClientProcessFunction(Packet p_Packet);
        Dictionary<PacketType, ClientProcessFunction> m_Processor;

        public Dictionary<PacketType, ClientProcessFunction> Processor()
        {
            return m_Processor;
        }

        public ClientPacketProcessor()
        {
            m_Processor = new Dictionary<PacketType, ClientProcessFunction>
            {
                [PacketType.OK] = OkProcess,
                [PacketType.ERROR] = ErrorProcess,
            };
        }

        private void OkProcess(Packet p_Packet)
        {
            OkPacket l_Packet = (OkPacket)p_Packet;
            SceneManager.Instance().SetScene("Game");
        }

        private void ErrorProcess(Packet p_Packet)
        {
            ErrorPacket l_Packet = (ErrorPacket)p_Packet;

        }
    }
}
