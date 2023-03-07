//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
//------------------------------------------------------------
using System.Collections.Generic;

namespace LiteFrame.Core.ECS
{
    class ECS : IECS, IAddon, IUpdate
    {
        public int Priority => 999;

        private List<World> worlds = new List<World>();

        public void Attach()
        {
            
        }

        public void Detach()
        {
           
        }

        public void Update(float elapseSeconds, float realElapseSeconds)
        {
            foreach(World v in worlds)
            {
                v.Update(elapseSeconds, realElapseSeconds);
            }
        }

        public World MakeWorld()
        {
            World world = new World();
            worlds.Add(world);
            return world;
        }

        public bool RemoveWorld(World world)
        {
            for(int i = 0; i < worlds.Count; ++i)
            {
                if(world == worlds[i])
                {
                    worlds.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
