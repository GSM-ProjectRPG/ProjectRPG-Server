using System.Collections.Generic;
using System.Linq;

namespace ProjectRPG
{
    public class SessionManager
    {
        public static SessionManager Instance { get; } = new SessionManager();

        private Dictionary<int, ClientSession> _sessions = new Dictionary<int, ClientSession>();
        private int _sessionId = 0;
        private readonly object _lock = new object();

        public List<ClientSession> GetSessions()
        {
            var sessions = new List<ClientSession>();

            lock (_lock)
            {
                sessions = _sessions.Values.ToList();
            }

            return sessions;
        }

        public ClientSession Generate()
        {
            lock (_lock)
            {
                int sessionId = ++_sessionId;
                var session = new ClientSession() { SessionId = sessionId };
                _sessions.Add(sessionId, session);
                return session;
            }
        }

        public ClientSession Find(int id)
        {
            lock (_lock)
            {
                _sessions.TryGetValue(id, out ClientSession session);
                return session;
            }
        }

        public void Remove(ClientSession session)
        {
            lock (_lock)
            {
                _sessions.Remove(session.SessionId);
            }
        }
    }
}