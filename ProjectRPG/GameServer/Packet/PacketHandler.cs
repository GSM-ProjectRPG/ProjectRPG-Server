using ACore;
using Google.Protobuf;
using Google.Protobuf.Protocol;
using ProjectRPG;

public class PacketHandler
{
    public static void C_LoginHandler(PacketSession session, IMessage packet)
    {
        var loginPacket = (C_Login)packet;
        var clientSession = (ClientSession)session;
        clientSession.HandleLogin(loginPacket);
    }

    public static void C_CreatePlayerHandler(PacketSession session, IMessage packet)
    {

    }

    public static void C_EnterGameHandler(PacketSession session, IMessage packet)
    {

    }

    public static void C_MoveHandler(PacketSession session, IMessage packet)
    {

    }

    public static void C_SkillHandler(PacketSession session, IMessage packet)
    {

    }

    public static void C_EquipItemHandler(PacketSession session, IMessage packet)
    {

    }

    public static void C_ChatHandler(PacketSession session, IMessage packet)
    {

    }

    public static void C_PingHandler(PacketSession session, IMessage packet)
    {

    }
}