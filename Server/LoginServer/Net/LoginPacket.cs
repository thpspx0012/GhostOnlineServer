using Server.Common.Constants;
using Server.Common.IO.Packet;
using Server.Common.Net;
using Server.Interoperability;

namespace Server.Ghost
{
    public static class LoginPacket
    {
        
        public static void Login_Ack(Client c, ServerState.LoginState state, short encryptKey = 0, bool netCafe = false)
        {
            using (var plew = new OutPacket(LoginServerOpcode.LOGIN_ACK))
            {
                plew.WriteByte((byte)state);
                plew.WriteBool(netCafe);
                plew.WriteShort(encryptKey);

                c.Send(plew);
            }
        }

        public static void ServerList_Ack(Client c)
        {
            using (var plew = new OutPacket(LoginServerOpcode.SERVERLIST_ACK))
            {
                //for (int i = 0; i < 12; i++)
                //{
                //    plew.WriteByte(0xFF);
                //}
                //plew.WriteInt(LoginServer.Worlds.Count); // 伺服器數量
                //foreach (World world in LoginServer.Worlds)
                //{
                //    plew.WriteShort(world.ID); // 伺服器順序
                //    plew.WriteInt(world.Channel); // 頻道數量

                //    for (int i = 0; i < 12; i++)
                //    {
                //        plew.WriteShort(i + 1);
                //        plew.WriteShort(i + 1);
                //        plew.WriteString(ServerConstants.SERVER_IP);
                //        plew.WriteInt(15101 + i);
                //        plew.WriteInt(i < world.Count ? world[i].LoadProportion : 0); // 玩家數量
                //        plew.WriteInt(ServerConstants.CHANNEL_LOAD); // 頻道人數上限
                //        plew.WriteInt(12); // 標章類型
                //        plew.WriteInt(0);
                //        plew.WriteByte(i < world.Count ? 1 : 2);
                //        plew.WriteInt(15199);
                //    }
                //}
                plew.WriteHexString("AA5538033300D0CFCFCFCFCFCFCFCFCFCFCF01000000000001000000010001000E003230332E3134342E3133302E3434C932000053020000200300000C0000000000000001AF360000020002000E003230332E3134342E3133302E3331CA320000F0000000900100000C0000000000000001AE360000030003000E003230332E3134342E3133302E3331CB3200009C000000900100000C0000000000000001AD360000040004000E003230332E3134342E3133302E3331C93200005F000000900100000C0000000000000001AF360000050005000E003230332E3134342E3133302E3332CA32000050000000900100000C0000000000000001AE360000060006000E003230332E3134342E3133302E3332CB32000086000000200300000C0000000000000001AD360000070007000E003230332E3134342E3133302E3333C93200004B000000900100000C0000000000000001AF360000080008000E003230332E3134342E3133302E3333CA3200003E000000900100000C0000000000000001AE360000090009000E003230332E3134342E3133302E3333CB32000031000000900100000C0000000000000001AD3600000A000A000E003230332E3134342E3133302E3334C932000039000000900100000C0000000000000001AF3600000B000B000E003230332E3134342E3133302E3334CA32000046000000900100000C0000000000000001AE3600000C000C000E003230332E3134342E3133302E3334CB32000047000000900100000C0000000000000001AD3600000D000D000D003231382E35352E3132302E3137C932000000000000640000000C0000000000000002AF3600000E000E000D003139322E3136382E31302E3634C932000000000000640000000C0000000000000002AF3600000F000F000C003139322E3136382E31302E30C932000000000000640000000C0000000000000002AF360000100010000C003139322E3136382E31302E30CA32000000000000640000000C0000000000000002AD360000110011000C003139322E3136382E31302E30C932000000000000640000000C0000000000000000AF360000120012000C003139322E3136382E31302E30CA32000000000000640000000C0000000000000000AE36000055AA");


                c.SendCustom(plew);
            }

        }

        public static void Game_Ack(Client c, ServerState.ChannelState state)
        {
            using (var plew = new OutPacket(LoginServerOpcode.GAME_ACK))
            {
                plew.WriteByte((byte)state);
                plew.WriteString(ServerConstants.SERVER_IP);
                plew.WriteInt(15123);
                plew.WriteInt(15199);

                c.Send(plew);
            }
        }
    }
}
