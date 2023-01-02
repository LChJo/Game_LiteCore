//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
//------------------------------------------------------------
using System;
using System.Reflection;

namespace LiteFrame.Core.ECS
{
    public interface IIdGenerator
    {
        int FetchEntityId();
        int FetchWorldId();
        int InitComponentId();
    }

    public class IdGenerator : IIdGenerator
    {
        private int entityAcc = 0;
        public int FetchEntityId()
        {
            return entityAcc++;
        }

        public int FetchWorldId()
        {
            return TypeIdGenerator<World>.Inser<World>();
        }

        public int InitComponentId()
        {
            return ComponentTemplate.MakeTemplate();
        }

        public static int GetCompnentId<T>() where T : Component
        {
            return TypeIdGenerator<T>.id;
        }

        public static int GetCompnentId<T>(T com) where T : Component
        {
            return TypeIdGenerator<T>.id;
        }
    }

    public class TypeIdGenerator<T>
    {
        public static int id = 0;
        public static int nextId = 0;
        public static int Inser<BaseT>()
        {
            id = TypeIdGenerator<BaseT>.nextId++;
            return id;
        }
    }
}
