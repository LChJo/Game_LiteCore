//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
//------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace LiteFrame.Core.ECS
{
    public sealed class World : IUpdate
    {
        public readonly int id = 0;
        public static int componentCount = 0;
        public IIdGenerator IdGenerator { get; private set; }

        public Dictionary<int, Entity> entityMap = new Dictionary<int, Entity>();

        private float frameTimer = 0.0f;
        private SortedSet<UpdateSystem> updateSystems = new SortedSet<UpdateSystem>(new ComparerSystem());
        private SortedSet<TriggerSystem> trigerSystems = new SortedSet<TriggerSystem>(new ComparerSystem());

        public World()
        {
            IdGenerator = new IdGenerator();
            id = IdGenerator.FetchWorldId();
            componentCount = IdGenerator.InitComponentId();
        }

        public void Update(float elapseSeconds, float realElapseSeconds)
        {
            foreach(UpdateSystem sys in updateSystems)
            {
                sys.OnUpdate(this, elapseSeconds, realElapseSeconds);
            }

            foreach (TriggerSystem sys in trigerSystems)
            {
                sys.OnTrigger(this);
            }
        }

        public void AddtoUpdate(UpdateSystem sys)
        {
            updateSystems.Add(sys);
        }

        public void RemoveFromUpdate(UpdateSystem sys)
        {
            updateSystems.Remove(sys);
        }

        public void AddtoTrigger(TriggerSystem sys)
        {
            trigerSystems.Add(sys);
        }
    }
}
