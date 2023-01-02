//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
//------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace LiteFrame.Core.ECS
{
    public sealed class Entity : IEquatable<Entity>
    {
        public readonly int Id;
        public bool Dirty = false;
        private readonly World world;
        private Component[] components = null;
        private List<IKeyCom> componentList = new List<IKeyCom>(6);

        public Entity(World _world)
        {
            Id = _world.IdGenerator.FetchEntityId();
            components = new Component[World.componentCount];
            world = _world;
            world.entityMap.Add(Id, this);
        }

        #region Operator
        public bool Equals(Entity other) => this.Id == other.Id;
        public override bool Equals(object obj) => obj is Entity other && this.Equals(other);
        public override int GetHashCode() => base.GetHashCode();
        public static bool operator ==(Entity left, Entity right) => left.Equals(right);
        public static bool operator !=(Entity left, Entity right) => !left.Equals(right);
        #endregion

        #region public methods
        public void AddComponent<T>(T com) where T : Component
        {
            if(components == null)
            {
                components = new Component[World.componentCount];
            }

            components[TypeIdGenerator<T>.id] = com;

            if(com is IKeyCom)
            {
                componentList.Add((IKeyCom)com);
                componentList.Sort();

                Builder.UpdateArcheType(world, this, componentList, (IKeyCom)com);
            }
        }

        public void RemoveComponent<T>(T com) where T : Component
        {
            components[TypeIdGenerator<T>.id] = null;

            if (com is IKeyCom)
            {
                Builder.RemoveFromArcheType(world, this, componentList, (IKeyCom)com);
                componentList.Remove((IKeyCom)com);
            }
        }

        public void RemoveAllComponent()
        {
            Builder.RemoveFromArcheType(world, this, componentList);
            components = null;
            componentList.Clear();
        }

        public Component GetComponent<T>(T com) where T : Component
        {
            if (components == null)
            {
                return null;
            }

            return components[TypeIdGenerator<T>.id];
        }

        public bool HasComponent<T>() where T : Component
        {
            if (components == null)
            {
                return false;
            }

            return components[TypeIdGenerator<T>.id] != null;
        }
        #endregion
    }
}
