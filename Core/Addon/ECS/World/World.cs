//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
//------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace LiteFrame.Core.ECS
{
    public sealed class World
    {
        public readonly int id = 0;
        public static int componentCount = 0;
        public IIdGenerator IdGenerator { get; private set; }

        public Dictionary<int, Entity> entityMap = new Dictionary<int, Entity>();

        public World()
        {
            IdGenerator = new IdGenerator();
            id = IdGenerator.FetchWorldId();
            componentCount = IdGenerator.InitComponentId();
        }
    }
}
