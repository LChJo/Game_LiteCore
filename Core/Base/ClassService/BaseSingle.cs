//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
//------------------------------------------------------------

using System;

namespace LiteFrame.Core
{
    public abstract class BaseSingle<T> where T : class, new()
    {
        private static readonly Lazy<T> mLazyInstance = new Lazy<T>((Func<T>) (() => new T()));

        public static T Instance => BaseSingle<T>.mLazyInstance.Value;
    }
}
