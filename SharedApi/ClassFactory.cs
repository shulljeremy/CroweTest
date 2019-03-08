using System;
using System.Collections.Generic;
using SharedApi.Exceptions;
using SharedApi.Interfaces;

namespace SharedApi
{
    public class ClassFactory<T> : IClassFactory<T>
    {
        public ClassFactory()
        {
        }

        /// <inheritdoc />
        public IEnumerable<T> CreateClasses(IEnumerable<string> classTypeNames)
        {
            if (classTypeNames == null)
            {
                throw new ArgumentNullException("Class type collection cannot be null.");
            }

            var classes = new List<T>();

            foreach (var className in classTypeNames)
            {
                var type = Type.GetType(className);
                if (type == null)
                {
                    throw new UnknownTypeException($"Unknown type {className}");
                }

                var instance = Activator.CreateInstance(type);
                if (instance is T)
                {
                    classes.Add((T)instance);
                }
                else
                {
                    throw new InvalidTypeException($"Type {type} is not a {typeof(T)}");
                }
            }

            return classes;
        }
    }
}
