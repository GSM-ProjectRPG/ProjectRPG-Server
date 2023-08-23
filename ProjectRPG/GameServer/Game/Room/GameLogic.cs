using System.Collections.Generic;
using ProjectRPG.Job;

namespace ProjectRPG.Game
{
    public class GameLogic : JobSerializer
    {
        public static GameLogic Instance { get; } = new GameLogic();

        private Dictionary<int, GameRoom> _rooms = new Dictionary<int, GameRoom>();
        private int _roomId = 1;

        public void Update()
        {
            Flush();

            foreach (var room in _rooms.Values)
                room.Update();
        }

        public GameRoom AddRoom()
        {
            var room = new GameRoom();
            // TODO : Init GameRoom

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
