//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
// 描述：Sytem必须是无状态的控制器，不允许存储临时变量，单个system可能复用到多个world
//------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace LiteFrame.Core.ECS
{
    public abstract class System : ISingle
    {
        public int Priority => 0;
        private int refcnt = 0;
        public int Refcnt => refcnt;

        public virtual void OnAttach(World world)
        {
            refcnt++;
        }

        public virtual void OnDetach(World world)
        {
            refcnt--;
        }
    }

    public class ComparerSystem : IComparer<System>
    {
        public int Compare(System x, System y)
        {
            return x.Priority - y.Priority;
        }
    }
}
