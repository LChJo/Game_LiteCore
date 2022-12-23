//------------------------------------------------------------
// LiteCore
// Copyright © 2022 LoJo. All rights reserved.
// Email: 22771133@qq.com
//------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace LiteFrame.Core
{
    public abstract class TypeTable<T> where T : class
    {
        public static List<Object> instanceList = null;
        public static Object instance = null;
        public static Dictionary<int, Object> instanceDic = null;
    }
    
    public static class ClassSvc
    {
        private static Dictionary<Object, int> _objectId = new Dictionary<object, int>();

        public static T Build<T>(int index = -1) where T: class
        {
            if (TypeTable<T>.instance != null)
            {
                return (T) TypeTable<T>.instance;
            }

            Object newModel = Activator.CreateInstance<T>();
            Object instance = null;
            if (newModel is ISingle)
            {
                if (index > 0)
                {
                    throw new ClassException("Single Cannot Have Index");
                }

                TypeTable<T>.instance = newModel;
                return (T) newModel;
            }

            if (index > 0)
            {
                if (TypeTable<T>.instanceDic != null)
                {
                    if (TypeTable<T>.instanceDic.TryGetValue(index, out instance))
                    {
                        return (T) instance;
                    }

                    TypeTable<T>.instanceDic.Add(index, newModel);
                    return (T) newModel;
                }

                var idDic = new Dictionary<int, Object>();
                idDic.Add(index, newModel);
                TypeTable<T>.instanceDic = idDic;
                _objectId.Add(newModel, index);
                return (T) newModel;
            }

            if (TypeTable<T>.instanceList != null)
            {
                TypeTable<T>.instanceList.Add(newModel);
                _objectId.Add(newModel, TypeTable<T>.instanceList.Count - 1);
                return (T) newModel;
            }

            var instanceList = new List<Object>();
            instanceList.Add(newModel);
            _objectId.Add(newModel, instanceList.Count - 1);
            TypeTable<T>.instanceList = instanceList;
            return (T) newModel;
        }

        public static T Get<T>(int index = -1) where T: class
        {
            if (TypeTable<T>.instance != null)
            {
                return (T) TypeTable<T>.instance;
            }

            if (index > 0)
            {
                if (TypeTable<T>.instanceDic != null)
                {
                    if (TypeTable<T>.instanceDic.TryGetValue(index, out var instance))
                    {
                        return (T) instance;
                    }
                }
                
                if (TypeTable<T>.instanceList != null)
                {
                    if (TypeTable<T>.instanceList.Count > 0 && index < TypeTable<T>.instanceList.Count)
                    {
                        return (T) TypeTable<T>.instanceList[index];
                    }
                }
            }

            if (TypeTable<T>.instanceList != null)
            {
                if (TypeTable<T>.instanceList.Count > 0)
                {
                    return (T)TypeTable<T>.instanceList[TypeTable<T>.instanceList.Count - 1];
                }
            }

            return null;
        }

        public static void Remove<T>(int index = -1) where T: class
        {
            TypeTable<T>.instance = null;

            if (index > 0)
            {
                if (TypeTable<T>.instanceDic != null)
                {
                    if (TypeTable<T>.instanceDic.TryGetValue(index, out var instance))
                    {
                        _objectId.Remove(instance);
                        TypeTable<T>.instanceDic.Remove(index);
                    }
                }

                if (TypeTable<T>.instanceList != null)
                {
                    if (TypeTable<T>.instanceList.Count > 0 && index < TypeTable<T>.instanceList.Count)
                    {
                        _objectId.Remove(TypeTable<T>.instanceList[index]);
                        TypeTable<T>.instanceList.RemoveAt(index);
                    }
                }
            }

            if (TypeTable<T>.instanceList != null)
            {
                if (TypeTable<T>.instanceList.Count > 0)
                {
                    _objectId.Remove(TypeTable<T>.instanceList[TypeTable<T>.instanceList.Count - 1]);
                    TypeTable<T>.instanceList.RemoveAt(TypeTable<T>.instanceList.Count - 1);
                }
            }
        }

        public static int GetIndex(Object instance)
        {
            if (instance == null)
            {
                throw new ClassException("instance == null");
            }

            if (_objectId.TryGetValue(instance, out var id))
            {
                return id;
            }
            return -1;
        }

        public static void Remove<T>(T obj, int index = -1) where T : class
        {
            if (index == -1)
            {
                index = GetIndex(obj);
            }
            Remove<T>(index);
        }

        public static void Clear()
        {
            _objectId.Clear();
        }
    }
}