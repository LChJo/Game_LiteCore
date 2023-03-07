//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
// 描述：由帧时间驱动更新
//------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace LiteFrame.Core.ECS
{
    public abstract class UpdateSystem : System
    {
        public virtual void OnUpdate(World world, float elapseSeconds, float realElapseSeconds)
        {

        }
    }
}
