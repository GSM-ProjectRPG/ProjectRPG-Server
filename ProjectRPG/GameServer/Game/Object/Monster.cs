using System;
using Google.Protobuf.Protocol;
using GameServer.Data;
using GameServer.Job;

namespace GameServer.Game
{
    public class Monster : GameObject
    {
        public int TemplateId { get; set; }

        public Monster()
        {
            Type = GameObjectType.Monster;
        }

        public void Init(int templateId)
        {
            TemplateId = templateId;

            if (DataManager.MonsterDict.TryGetValue(TemplateId, out MonsterData monsterData))
            {
                Stat.MergeFrom(monsterData.stat);
                Stat.Hp = monsterData.stat.MaxHp;
                State = CreatureState.Idle;
            }
        }

        private BaseJob _job;
        public override void Update()
        {
            switch (State)
            {
                case CreatureState.Idle:
                    UpdateIdle();
                    break;
                case CreatureState.Move:
                    UpdateMoving();
                    break;
                case CreatureState.Skill:
                    UpdateSkill();
                    break;
                case CreatureState.Dead:
                    UpdateDead();
                    break;
            }

            if (CurrentRoom != null)
                _job = CurrentRoom.PushAfter(200, Update);
        }

        private Player _target;
        private int _searchCellDist = 10;
        private int _chaseCellDist = 20;
        private long _nextSearchTick = 0;
        protected virtual void UpdateIdle()
        {
            if (_nextSearchTick > Environment.TickCount64) return;
            _nextSearchTick = Environment.TickCount64 + 1000;

            var target = CurrentRoom.FindClosestPlayer(CellPos, _searchCellDist);
            if (target != null)
            {
                _target = target;
                State = CreatureState.Move;
            }
        }

        private int _skillRange = 1;
        private long _nextMoveTick = 0;
        protected virtual void UpdateMoving()
        {
            if (_nextMoveTick > Environment.TickCount64)
                return;
            int moveTick = (int)(1000 / Speed);
            _nextMoveTick = Environment.TickCount64 + moveTick;

            // TODO : Attackable Check

            // TODO : Move Logic
        }

        private void BroadcastMove()
        {
            // TODO : Broadcast Logic
        }

        private long _skillCoolDownTick = 0;
        protected virtual void UpdateSkill()
        {
            if (_skillCoolDownTick == 0)
            {
                // TODO : Target Check

                // TODO : Skill Check

                // TODO : Look At Target

                // TODO : Load Skill Data (TEMP)
                DataManager.SkillDict.TryGetValue(1, out Skill skillData);

                // TODO : Take Damage

                // TODO : Skill Broadcast

                // TODO : CoolDown Logic
                int coolTick = (int)(1000 * skillData.cooldown);
                _skillCoolDownTick = Environment.TickCount64 + coolTick;
            }
        }

        protected virtual void UpdateDead()
        {

        }

        public override void OnDead(GameObject killer)
        {
            if (_job != null)
            {
                _job.Cancel = true;
                _job = null;
            }

            base.OnDead(killer);

            var gameObject = killer.GetBase();
            if (gameObject.Type == GameObjectType.Player)
            {
                var reward = GetRandomReward();
                if (reward != null)
                {
                    var player = (Player)gameObject;
                    // TODO : Reward DB Logic
                }
            }
        }

        private RewardData GetRandomReward()
        {
            DataManager.MonsterDict.TryGetValue(TemplateId, out MonsterData monsterData);

            // TODO : Reward Logic (TEMP)
            int rand = new Random().Next(0, 101);

            int sum = 0;
            foreach (RewardData rewardData in monsterData.rewards)
            {
                sum += rewardData.probability;

                if (rand <= sum)
                {
                    return rewardData;
                }
            }

            return null;
        }
    }
}