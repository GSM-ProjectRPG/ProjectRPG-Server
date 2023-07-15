protoc.exe -I=./ --csharp_out=./ ./Protocol.proto 
IF ERRORLEVEL 1 PAUSE

START ../../../ProjectRPG/PacketGenerator/bin/Debug/net6.0/PacketGenerator.exe ./Protocol.proto
XCOPY /Y Protocol.cs "../../../ProjectRPG/GameServer/Packet"
XCOPY /Y Protocol.cs "../../../../ProjectRPG-Client/Assets/ProjectRPG/Scripts/Network/Packet"
XCOPY /Y ServerPacketManager.cs "../../../ProjectRPG/GameServer/Packet"
XCOPY /Y ClientPacketManager.cs "../../../../ProjectRPG-Client/Assets/ProjectRPG/Scripts/Network/Packet"