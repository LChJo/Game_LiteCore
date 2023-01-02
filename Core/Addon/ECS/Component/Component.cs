//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
//------------------------------------------------------------
using System;
using System.Collections;

namespace LiteFrame.Core.ECS
{
    public abstract class Component : IComparer
    {
        public bool Dirty = false;
        public int Index { private set; get; }

        public Component()
        {
            Index = IdGenerator.GetCompnentId(this);
        }

        public int Compare(object x, object y)
        {
            return ((Component)x).Index - ((Component)y).Index;
        }
    }
}
