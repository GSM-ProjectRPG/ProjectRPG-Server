using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Session
{
    public class SessionManager
    {
        public static SessionManager Instance { get; } = new SessionManager();

        private Dictionary<int, ClientSession> _sessions = new Dictionary<int, ClientSession>();
        private int _sessionId = 0;
        private readonly object _lock = new object();

        public ClientSession Generate()
        {
            lock (_lock)
            {
                int sessionId = ++_sessionId;
                ClientSession session = new ClientSession();
                session.SessionId = sessionId;
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
