using System.Collections.Generic;
using GameServer.Job;

namespace GameServer.Game
{
    public class GameLogic : JobSerializer
    {
        public static GameLogic Instance { get; } = new GameLogic();
        public ChatRoom ChatRoom { get; set; } = new ChatRoom();

        private Dictionary<int, GameRoom> _rooms = new Dictionary<int, GameRoom>();
        private int _roomId = 1;

        public void Update()
        {
            Flush();

            foreach (var room in _rooms.Values)
                room.Update();
        }

        public GameRoom AddRoom(int mapId)
        {
            var room = new GameRoom();
            room.Push(room.Init, mapId, 1);

            room.RoomId = _roomId;
            _rooms.Add(_roomId, room);
            _roomId++;

            return room;
        }

        public bool RemoveRoom(int roomId)
        {
            return _rooms.Remove(roomId);
        }

        public GameRoom FindRoom(int roomId)
        {
            if (_rooms.TryGetValue(roomId, out GameRoom room))
                return room;

            return null;
        }
    }
}