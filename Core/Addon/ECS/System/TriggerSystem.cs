//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
// 描述：触发式更新
//------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace LiteFrame.Core.ECS
{
    public abstract class TriggerSystem : System
    {
        private Dictionary<World, List<Entity>> triggerEntitys = new Dictionary<World, List<Entity>>();

        public override void OnAttach(World world)
        {
            base.OnAttach(world);
            triggerEntitys.Add(world, new List<Entity>());
        }

        public override void OnDetach(World world)
        {
            base.OnDetach(world);
            triggerEntitys.Remove(world);
        }

        public virtual void Trigger(World world, Entity entity)
        {
            triggerEntitys[world].Add(entity);
            world.AddtoTrigger(this);
        }

        public virtual void OnTrigger(World world)
        {

        }
    }
}
