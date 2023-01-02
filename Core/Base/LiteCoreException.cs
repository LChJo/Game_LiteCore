//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
//------------------------------------------------------------
using System;

namespace LiteFrame.Core
{
    public class LiteCoreException : Exception
    {
        public LiteCoreException() : base()
        {
        }

        public LiteCoreException(string message) : base(message)
        {
        }

        public LiteCoreException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}