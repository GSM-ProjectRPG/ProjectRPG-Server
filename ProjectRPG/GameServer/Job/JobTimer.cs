using System;
using ACore;

namespace ProjectRPG.Job
{
    struct JobTimerElem : IComparable<JobTimerElem>
    {
        public int execTick;
        public BaseJob Job;

        public int CompareTo(JobTimerElem other)
        {
            return other.execTick - execTick;
        }
    }

    public class JobTimer
    {
        private PriorityQueue<JobTimerElem> _pq = new PriorityQueue<JobTimerElem>();
        private readonly object _lock = new object();

        public void Push(BaseJob job, int tickAfter = 0)
        {
            JobTimerElem jobElement;
            jobElement.execTick = Environment.TickCount + tickAfter;
            jobElement.Job = job;

            lock (_lock)
            {
                _pq.Push(jobElement);
            }
        }

        public void Flush()
        {
            while (true)
            {
                int now = Environment.TickCount;

                JobTimerElem jobElement;

                lock (_lock)
                {
                    if (_pq.Count == 0)
                        break;

                    jobElement = _pq.Peek();
                    if (jobElement.execTick > now)
                        break;

                    _pq.Pop();
                }

                jobElement.Job.Execute();
            }
        }
    }
}