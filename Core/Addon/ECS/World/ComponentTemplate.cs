using System;
using System.Reflection;

namespace LiteFrame.Core.ECS
{
    public abstract class ComponentTemplate
    {
        private static Component[] components = null;
        public static int MakeTemplate()
        {
            if(components == null)
            {
                Type baseType = typeof(Component);
                TypeInfo baseTypeInfo = baseType.GetTypeInfo();
                Type[] types = baseType.Assembly.GetTypes();
                if(types.Length > 0)
                {
                    components = new Component[baseType.Assembly.GetTypes().Length];
                    for (int i = 0; i < types.Length; ++i)
                    {
                        TypeInfo typeInfo = types[i].GetTypeInfo();
                        if (typeInfo.IsSubclassOf(baseType))
                        {
                            components[i] = (Component)Activator.CreateInstance(types[i]);
                            MakeComponentId(components[i]);
                        }
                    }
                }
                return types.Length;
            }
            return components.Length;
        }

        private static void MakeComponentId<T>(T com) where T : Component
        {
            StoreTemplate<T>.component = com;
            TypeIdGenerator<T>.Inser<Component>();
        }

        public static Component GetTemplate<T>() where T : Component
        {
            return StoreTemplate<T>.component;
        }

        private abstract class StoreTemplate<T>
        {
            public static Component component = null;
        }
    }
}
