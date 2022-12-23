//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
//------------------------------------------------------------

namespace LiteFrame.Core
{
    public interface IAddon
    {
        void Attach();
        void Detach();
        int Priority { get;}
    }
}
