using System;
using System.Collections.Generic;

namespace LiteFrame.Core.ECS
{
    public static class Builder
    {
        public static Entity MakeEntity<T1>(this World world) where T1 : Component
        {
            Component[] components = new Component[]
            {
                Activator.CreateInstance<T1>()
            };

            MakeEntity(world, components);
            return null;
        }

        public static Entity MakeEntity<T1, T2>(this World world) where T1 : Component where T2 : Component
        {
            Component[] components = new Component[]
            {
                Activator.CreateInstance<T1>(),
                Activator.CreateInstance<T2>()
            };

            MakeEntity(world, components);
            return null;
        }

        public static Entity MakeEntity<T1, T2, T3>(this World world) where T1 : Component where T2 : Component where T3 : Component
        {
            Component[] components = new Component[]
            {
                Activator.CreateInstance<T1>(),
                Activator.CreateInstance<T2>(),
                Activator.CreateInstance<T3>()
            };

            MakeEntity(world, components);
            return null;
        }

        public static Entity MakeEntity<T1, T2, T3, T4>(this World world) where T1 : Component where T2 : Component where T3 : Component where T4 : Component
        {
            Component[] components = new Component[]
            {
                Activator.CreateInstance<T1>(),
                Activator.CreateInstance<T2>(),
                Activator.CreateInstance<T3>(),
                Activator.CreateInstance<T4>()
            };

            MakeEntity(world, components);
            return null;
        }

        public static Entity MakeEntity<T1, T2, T3, T4, T5>(this World world) where T1 : Component where T2 : Component where T3 : Component where T4 : Component where T5 : Component
        {
            Component[] components = new Component[]
            {
                Activator.CreateInstance<T1>(),
                Activator.CreateInstance<T2>(),
                Activator.CreateInstance<T3>(),
                Activator.CreateInstance<T4>(),
                Activator.CreateInstance<T5>()
            };

            MakeEntity(world, components);
            return null;
        }

        public static Entity MakeEntity<T1, T2, T3, T4, T5, T6>(this World world) where T1 : Component where T2 : Component where T3 : Component where T4 : Component where T5 : Component where T6 : Component
        {
            Component[] components = new Component[]
            {
                Activator.CreateInstance<T1>(),
                Activator.CreateInstance<T2>(),
                Activator.CreateInstance<T3>(),
                Activator.CreateInstance<T4>(),
                Activator.CreateInstance<T5>(),
                Activator.CreateInstance<T6>(),
            };

            MakeEntity(world, components);
            return null;
        }

        public static Entity MakeEntity<T1, T2, T3, T4, T5, T6, T7>(this World world) where T1 : Component where T2 : Component where T3 : Component where T4 : Component where T5 : Component where T6 : Component where T7 : Component
        {
            Component[] components = new Component[]
            {
                Activator.CreateInstance<T1>(),
                Activator.CreateInstance<T2>(),
                Activator.CreateInstance<T3>(),
                Activator.CreateInstance<T4>(),
                Activator.CreateInstance<T5>(),
                Activator.CreateInstance<T6>(),
                Activator.CreateInstance<T7>()
            };

            MakeEntity(world, components);
            return null;
        }

        public static HashSet<Entity> GetEntitys<T1>(this World world) where T1 : Component, IKeyCom
        {
            return EntityArchetype<T1>.GetEntities(world.id);
        }

        public static HashSet<Entity> GetEntitys<T1, T2>(this World world) where T1 : Component, IKeyCom where T2 : Component, IKeyCom
        {
            if (TypeIdGenerator<T1>.id > TypeIdGenerator<T2>.id)
            {
                return EntityArchetype<T2, T1>.GetEntities(world.id);
            }
            else
            {
                return EntityArchetype<T1, T2>.GetEntities(world.id);
            }
        }

        public static HashSet<Entity> GetEntitys<T1, T2, T3>(this World world) where T1 : Component, IKeyCom where T2 : Component, IKeyCom where T3 : Component, IKeyCom
        {
            return GetEntities(world, ComponentTemplate.GetTemplate<T1>(), ComponentTemplate.GetTemplate<T2>(), ComponentTemplate.GetTemplate<T3>());
        }

        public static HashSet<Entity> GetEntitys<T1, T2, T3, T4>(this World world) where T1 : Component, IKeyCom where T2 : Component, IKeyCom where T3 : Component, IKeyCom where T4 : Component, IKeyCom
        {
            return GetEntities(world, ComponentTemplate.GetTemplate<T1>(), ComponentTemplate.GetTemplate<T2>(), ComponentTemplate.GetTemplate<T3>(),
                ComponentTemplate.GetTemplate<T4>());
        }

        public static HashSet<Entity> GetEntitys<T1, T2, T3, T4, T5>(this World world) where T1 : Component, IKeyCom where T2 : Component, IKeyCom where T3 : Component, IKeyCom where T4 : Component, IKeyCom where T5 : Component, IKeyCom
        {
            return GetEntities(world, ComponentTemplate.GetTemplate<T1>(), ComponentTemplate.GetTemplate<T2>(), ComponentTemplate.GetTemplate<T3>(),
                ComponentTemplate.GetTemplate<T4>(), ComponentTemplate.GetTemplate<T5>());
        }

        public static HashSet<Entity> GetEntitys<T1, T2, T3, T4, T5, T6>(this World world) where T1 : Component, IKeyCom where T2 : Component, IKeyCom where T3 : Component, IKeyCom where T4 : Component, IKeyCom where T5 : Component, IKeyCom where T6 : Component, IKeyCom
        {
            return GetEntities(world, ComponentTemplate.GetTemplate<T1>(), ComponentTemplate.GetTemplate<T2>(), ComponentTemplate.GetTemplate<T3>(),
                ComponentTemplate.GetTemplate<T4>(), ComponentTemplate.GetTemplate<T5>(), ComponentTemplate.GetTemplate<T6>());
        }

        public static HashSet<Entity> GetEntitys<T1, T2, T3, T4, T5, T6, T7>(this World world) where T1 : Component where T2 : Component where T3 : Component where T4 : Component where T5 : Component where T6 : Component where T7 : Component
        {
            return GetEntities(world, ComponentTemplate.GetTemplate<T1>(), ComponentTemplate.GetTemplate<T2>(), ComponentTemplate.GetTemplate<T3>(),
                ComponentTemplate.GetTemplate<T4>(), ComponentTemplate.GetTemplate<T5>(), ComponentTemplate.GetTemplate<T6>(), ComponentTemplate.GetTemplate<T7>());
        }

        public static Entity FetchEntity(this World world, int id)
        {
            if (world.entityMap.TryGetValue(id, out var entity))
            {
                return entity;
            }
            return null;
        }

        public static void RemoveEntity(this World world, int id)
        {
            if (world.entityMap.TryGetValue(id, out var entity))
            {
                entity.RemoveAllComponent();
                world.entityMap.Remove(id);
            }
        }

        public static void UpdateArcheType(World world, Entity entity, List<IKeyCom> keyList, IKeyCom markCom = null)
        {
            int count = keyList.Count;
            bool unMake = (markCom == null);

            if (count > 1)
            {
                List<IKeyCom> tempList = new List<IKeyCom>();

                for (int n = 1; n <= count; ++n)
                {
                    for (int i = 0; i < count - n; ++i)
                    {
                        bool needUpdate = unMake;
                        for (int j = i; j < n; ++j)
                        {
                            if (markCom != null && (markCom == keyList[i])) needUpdate = true;
                            tempList.Add(keyList[i]);
                        }

                        if (needUpdate)
                            AddListToType(world, entity, tempList);

                        tempList.Clear();
                    }
                }
            }
            else if (count > 0)
            {
                SetToArchetype(true, world, entity, keyList[0]);
            }
            else
            {
                return;
            }
        }

        public static void RemoveFromArcheType(World world, Entity entity, List<IKeyCom> keyList, IKeyCom markCom = null)
        {
            int count = keyList.Count;
            bool unMake = (markCom == null);

            if (count > 1)
            {
                List<IKeyCom> tempList = new List<IKeyCom>();

                for (int n = 1; n <= count; ++n)
                {
                    for (int i = 0; i < count - n; ++i)
                    {
                        bool needUpdate = unMake;
                        for (int j = i; j < n; ++j)
                        {
                            if (markCom != null && (markCom == keyList[i])) needUpdate = true;
                            tempList.Add(keyList[i]);
                        }

                        if (needUpdate)
                            RemoveListFromType(world, entity, tempList);

                        tempList.Clear();
                    }
                }
            }
            else if (count > 0)
            {
                SetToArchetype(false, world, entity, keyList[0]);
            }
            else
            {
                return;
            }
        }

        #region private
        private static void SetToArchetype<T1>(bool addOrRemove, World world, Entity entity, T1 com) where T1 : IKeyCom
        {
            if (addOrRemove)
                EntityArchetype<T1>.AddEntity(entity, world.id);
            else
                EntityArchetype<T1>.RemoveEntity(entity, world.id);
        }

        private static void SetToArchetype<T1, T2>(bool addOrRemove, World world, Entity entity, T1 com1, T2 com2) where T1 : IKeyCom where T2 : IKeyCom
        {
            if (addOrRemove)
                EntityArchetype<T1, T2>.AddEntity(entity, world.id);
            else
                EntityArchetype<T1, T2>.RemoveEntity(entity, world.id);
        }

        private static void SetToArchetype<T1, T2, T3>(bool addOrRemove, World world, Entity entity, T1 com1, T2 com2, T3 com3) where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom
        {
            if (addOrRemove)
                EntityArchetype<T1, T2, T3>.AddEntity(entity, world.id);
            else
                EntityArchetype<T1, T2, T3>.RemoveEntity(entity, world.id);
        }

        private static void SetToArchetype<T1, T2, T3, T4>(bool addOrRemove, World world, Entity entity, T1 com1, T2 com2, T3 com3, T4 com4) where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom where T4 : IKeyCom
        {
            if (addOrRemove)
                EntityArchetype<T1, T2, T3, T4>.AddEntity(entity, world.id);
            else
                EntityArchetype<T1, T2, T3, T4>.RemoveEntity(entity, world.id);
        }

        private static void SetToArchetype<T1, T2, T3, T4, T5>(bool addOrRemove, World world, Entity entity, T1 com1, T2 com2, T3 com3, T4 com4, T5 com5) where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom where T4 : IKeyCom where T5 : IKeyCom
        {
            if (addOrRemove)
                EntityArchetype<T1, T2, T3, T4, T5>.AddEntity(entity, world.id);
            else
                EntityArchetype<T1, T2, T3, T4, T5>.RemoveEntity(entity, world.id);
        }

        private static void SetToArchetype<T1, T2, T3, T4, T5, T6>(bool addOrRemove, World world, Entity entity, T1 com1, T2 com2, T3 com3, T4 com4, T5 com5, T6 com6) where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom where T4 : IKeyCom where T5 : IKeyCom where T6 : IKeyCom
        {
            if (addOrRemove)
                EntityArchetype<T1, T2, T3, T4, T5, T6>.AddEntity(entity, world.id);
            else
                EntityArchetype<T1, T2, T3, T4, T5, T6>.RemoveEntity(entity, world.id);
        }

        private static void SetToArchetype<T1, T2, T3, T4, T5, T6, T7>(bool addOrRemove, World world, Entity entity, T1 com1, T2 com2, T3 com3, T4 com4, T5 com5, T6 com6, T7 com7) where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom where T4 : IKeyCom where T5 : IKeyCom where T6 : IKeyCom where T7 : IKeyCom
        {
            if (addOrRemove)
                EntityArchetype<T1, T2, T3, T4, T5, T6, T7>.AddEntity(entity, world.id);
            else
                EntityArchetype<T1, T2, T3, T4, T5, T6, T7>.RemoveEntity(entity, world.id);
        }

        private static HashSet<Entity> GetFromArchetype<T1>(World world, T1 com) where T1 : IKeyCom
        {
            return EntityArchetype<T1>.enities[world.id];
        }

        private static HashSet<Entity> GetFromArchetype<T1, T2>(World world, T1 com1, T2 com2) where T1 : IKeyCom where T2 : IKeyCom
        {
            return EntityArchetype<T1, T2>.enities[world.id];
        }

        private static HashSet<Entity> GetFromArchetype<T1, T2, T3>(World world, T1 com1, T2 com2, T3 com3) where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom
        {
            return EntityArchetype<T1, T2, T3>.enities[world.id];
        }

        private static HashSet<Entity> GetFromArchetype<T1, T2, T3, T4>(World world, T1 com1, T2 com2, T3 com3, T4 com4) where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom where T4 : IKeyCom
        {
            return EntityArchetype<T1, T2, T3, T4>.enities[world.id];
        }

        private static HashSet<Entity> GetFromArchetype<T1, T2, T3, T4, T5>(World world, T1 com1, T2 com2, T3 com3, T4 com4, T5 com5) where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom where T4 : IKeyCom where T5 : IKeyCom
        {
            return EntityArchetype<T1, T2, T3, T4, T5>.enities[world.id];
        }

        private static HashSet<Entity> GetFromArchetype<T1, T2, T3, T4, T5, T6>(World world, T1 com1, T2 com2, T3 com3, T4 com4, T5 com5, T6 com6) where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom where T4 : IKeyCom where T5 : IKeyCom where T6 : IKeyCom
        {
            return EntityArchetype<T1, T2, T3, T4, T5, T6>.enities[world.id];
        }

        private static HashSet<Entity> GetFromArchetype<T1, T2, T3, T4, T5, T6, T7>(World world, T1 com1, T2 com2, T3 com3, T4 com4, T5 com5, T6 com6, T7 com7) where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom where T4 : IKeyCom where T5 : IKeyCom where T6 : IKeyCom where T7 : IKeyCom
        {
            return EntityArchetype<T1, T2, T3, T4, T5, T6, T7>.enities[world.id];
        }

        private static Entity MakeEntity(World world, Component[] components)
        {
            Entity entity = new Entity(world);

            List<IKeyCom> keyList = new List<IKeyCom>();
            for (int i = 0; i < components.Length; ++i)
            {
                if (components[i] is IKeyCom)
                {
                    keyList.Add((IKeyCom)components[i]);
                }
            }
            keyList.Sort();
            UpdateArcheType(world, entity, keyList);
            return entity;
        }

        private static void AddListToType(World world, Entity entity, List<IKeyCom> list)
        {
            int n = list.Count;
            switch (n)
            {
                case 1:
                    {
                        SetToArchetype(true, world, entity, list[0]);
                        break;
                    }
                case 2:
                    {
                        SetToArchetype(true, world, entity, list[0], list[1]);
                        break;
                    }
                case 3:
                    {
                        SetToArchetype(true, world, entity, list[0], list[1], list[2]);
                        break;
                    }
                case 4:
                    {
                        SetToArchetype(true, world, entity, list[0], list[1], list[2], list[3]);
                        break;
                    }
                case 5:
                    {
                        SetToArchetype(true, world, entity, list[0], list[1], list[2], list[3], list[4]);
                        break;
                    }
                case 6:
                    {
                        SetToArchetype(true, world, entity, list[0], list[1], list[2], list[3], list[4], list[5]);
                        break;
                    }
                case 7:
                    {
                        SetToArchetype(true, world, entity, list[0], list[1], list[2], list[3], list[4], list[5], list[6]);
                        break;
                    }
            }
        }
        private static void RemoveListFromType(World world, Entity entity, List<IKeyCom> list)
        {
            int n = list.Count;
            switch (n)
            {
                case 1:
                    {
                        SetToArchetype(false, world, entity, list[0]);
                        break;
                    }
                case 2:
                    {
                        SetToArchetype(false, world, entity, list[0], list[1]);
                        break;
                    }
                case 3:
                    {
                        SetToArchetype(false, world, entity, list[0], list[1], list[2]);
                        break;
                    }
                case 4:
                    {
                        SetToArchetype(false, world, entity, list[0], list[1], list[2], list[3]);
                        break;
                    }
                case 5:
                    {
                        SetToArchetype(false, world, entity, list[0], list[1], list[2], list[3], list[4]);
                        break;
                    }
                case 6:
                    {
                        SetToArchetype(false, world, entity, list[0], list[1], list[2], list[3], list[4], list[5]);
                        break;
                    }
                case 7:
                    {
                        SetToArchetype(false, world, entity, list[0], list[1], list[2], list[3], list[4], list[5], list[6]);
                        break;
                    }
            }
        }

        private static HashSet<Entity> GetEntities<T>(World world, params T[] args) where T : Component
        {
            List<IKeyCom> keyList = new List<IKeyCom>();
            for (int i = 0; i < args.Length; ++i)
            {
                if (args[i] is IKeyCom)
                {
                    keyList.Add((IKeyCom)args[i]);
                }
            }
            keyList.Sort();
            int n = keyList.Count;
            switch (n)
            {
                case 1:
                    {
                        return GetFromArchetype(world, keyList[0]);
                    }
                case 2:
                    {
                        return GetFromArchetype(world, keyList[0], keyList[1]);
                    }
                case 3:
                    {
                        return GetFromArchetype(world, keyList[0], keyList[1], keyList[2]);
                    }
                case 4:
                    {
                        return GetFromArchetype(world, keyList[0], keyList[1], keyList[2], keyList[3]);
                    }
                case 5:
                    {
                        return GetFromArchetype(world, keyList[0], keyList[1], keyList[2], keyList[3], keyList[4]);
                    }
                case 6:
                    {
                        return GetFromArchetype(world, keyList[0], keyList[1], keyList[2], keyList[3], keyList[4], keyList[5]);
                    }
                case 7:
                    {
                        return GetFromArchetype(world, keyList[0], keyList[1], keyList[2], keyList[3], keyList[4], keyList[5], keyList[6]);
                    }
            }
            return null;

        }
        #endregion

        #region EntityArchetypes
        private abstract class EntityArchetype<T> : Archetype<T> where T : IKeyCom
        {

        }

        private abstract class EntityArchetype<T1, T2> : Archetype<T1> where T1 : IKeyCom where T2 : IKeyCom
        {

        }

        private abstract class EntityArchetype<T1, T2, T3> : Archetype<T1> where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom
        {

        }

        private abstract class EntityArchetype<T1, T2, T3, T4> : Archetype<T1> where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom where T4 : IKeyCom
        {

        }

        private abstract class EntityArchetype<T1, T2, T3, T4, T5> : Archetype<T1> where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom where T4 : IKeyCom where T5 : IKeyCom
        {

        }

        private abstract class EntityArchetype<T1, T2, T3, T4, T5, T6> : Archetype<T1> where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom where T4 : IKeyCom where T5 : IKeyCom where T6 : IKeyCom
        {

        }

        private abstract class EntityArchetype<T1, T2, T3, T4, T5, T6, T7> : Archetype<T1> where T1 : IKeyCom where T2 : IKeyCom where T3 : IKeyCom where T4 : IKeyCom where T5 : IKeyCom where T6 : IKeyCom where T7 : IKeyCom
        {

        }
        #endregion
    }
}
