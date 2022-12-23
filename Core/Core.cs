//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace LiteFrame.Core
{
    public abstract class Core : IModelSign
    {
        IModel IModelSign.Model => Fetch<Model>();

        public void Update(float elapseSeconds, float realElapseSeconds)
        {
            foreach (IAddon item in _addons)
            {
                if (item is IUpdate)
                {
                    (item as IUpdate).Update(elapseSeconds, realElapseSeconds);
                }
            }
        }

        public void ShutDown()
        {
            foreach (IAddon item in _addons)
            {
                Remove(item);
            }
        }

        #region public methods

        public T Fetch<T>() where T : class, IAddon
        {
            if (CoreTypeDic<T>.instance != null)
            {
                return (T)CoreTypeDic<T>.instance;
            }

            if (CoreTypeDic<T>.destory)
            {
                return null;
            }

            T instance = Activator.CreateInstance<T>();
            CoreTypeDic<T>.instance = instance;

            _addons.AddLast(instance);
            Sort();
            instance.Attach();
           
            return instance;
        }

        public void Remove<T>() where T : class, IAddon
        {
            T instace = (T)CoreTypeDic<T>.instance;
            if (instace != null)
            {
                instace.Detach();
                _addons.Remove(instace);
                CoreTypeDic<T>.instance = null;
                CoreTypeDic<T>.destory = true;
            }
        }

        public void Remove<T>(T obj) where T : class, IAddon
        {
            Remove<T>();
        }

        /// <summary>
        /// Core的拥有者来调用Update接口。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        #endregion

        #region private

        private readonly LinkedList<IAddon> _addons = new LinkedList<IAddon>();

        private void Sort()
        {
            bool swapped;
            do
            {
                swapped = false;

                var node = _addons.First;
                while (node.Next != null)
                {
                    if (node.Value.Priority < node.Next.Value.Priority)
                    {
                        // 交换元素的值
                        var temp = node.Value;
                        node.Value = node.Next.Value;
                        node.Next.Value = temp;

                        swapped = true;
                    }

                    node = node.Next;
                }
            } while (swapped);
        }

        private abstract class CoreTypeDic<T> where T : class
        {
            public static bool destory = false;
            public static Object instance = null;
        }

        #endregion
    }
}
