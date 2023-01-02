//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
//------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace LiteFrame.Core.ECS
{
    public abstract class Archetype<T> where T : IKeyCom
    {
        public static HashSet<Entity>[] enities = new HashSet<Entity>[8];

        public static void AddEntity(Entity entity, int worldId)
        {
            if (worldId > enities.Length)
            {
                throw new LiteCoreException("WorldId error when AddEntity, try use WorldBuilder!");
            }

            if (worldId == enities.Length)
            {
                var temp = enities;
                enities = new HashSet<Entity>[temp.Length * 2];
                for (int i = 0; i < temp.Length; ++i)
                {
                    enities[i] = temp[i];
                }
                temp = null;
            }
            enities[worldId].Add(entity);
        }

        public static void RemoveEntity(Entity entity, int worldId)
        {
            if (worldId >= enities.Length)
            {
                throw new LiteCoreException("WorldId error when RemoveEntity, try use WorldBuilder!");
            }
            enities[worldId].Remove(entity);
        }

        public static HashSet<Entity> GetEntities(int worldId)
        {
            if (worldId >= enities.Length)
            {
                throw new LiteCoreException("WorldId error when RemoveEntity, try use WorldBuilder!");
            }
            return enities[worldId];
        }
    }
}
