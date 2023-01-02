//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
//------------------------------------------------------------

using System.Collections;

namespace LiteFrame.Core.ECS
{
    public interface IKeyCom : IComparer
    {
        int Index { set; get; }
    }
}
