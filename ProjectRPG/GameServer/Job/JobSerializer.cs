using System;
using System.Collections.Generic;

namespace GameServer.Job
{
    public class JobSerializer
    {
        private JobTimer _jobTimer = new JobTimer();
        private Queue<BaseJob> _jobQueue = new Queue<BaseJob>();
        private readonly object _lock = new object();

        public BaseJob PushAfter(int tickAfter, Action action) => PushAfter(tickAfter, new Job(action));
        public BaseJob PushAfter<T1>(int tickAfter, Action<T1> action, T1 t1) => PushAfter(tickAfter, new Job<T1>(action, t1));
        public BaseJob PushAfter<T1, T2>(int tickAfter, Action<T1, T2> action, T1 t1, T2 t2) => PushAfter(tickAfter, new Job<T1, T2>(action, t1, t2));
        public BaseJob PushAfter<T1, T2, T3>(int tickAfter, Action<T1, T2, T3> action, T1 t1, T2 t2, T3 t3) => PushAfter(tickAfter, new Job<T1, T2, T3>(action, t1, t2, t3));

        public BaseJob PushAfter(int tickAfter, BaseJob job)
        {
            _jobTimer.Push(job, tickAfter);
            return job;
        }

        public void Push(Action action) => Push(new Job(action));
        public void Push<T1>(Action<T1> action, T1 t1) => Push(new Job<T1>(action, t1));
        public void Push<T1, T2>(Action<T1, T2> action, T1 t1, T2 t2) => Push(new Job<T1, T2>(action, t1, t2));
        public void Push<T1, T2, T3>(Action<T1, T2, T3> action, T1 t1, T2 t2, T3 t3) => Push(new Job<T1, T2, T3>(action, t1, t2, t3));

        public void Push(BaseJob job)
        {
            lock (_lock)
            {
                _jobQueue.Enqueue(job);
            }
        }

        public void Flush()
        {
            _jobTimer.Flush();

            while (true)
            {
                BaseJob job = Pop();
                if (job == null) return;
                job.Execute();
            }
        }

        private BaseJob Pop()
        {
            lock (_lock)
            {
                if (_jobQueue.Count == 0) return null;
                return _jobQueue.Dequeue();
            }
        }
    }
}