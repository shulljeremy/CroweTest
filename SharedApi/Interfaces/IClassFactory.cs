using System.Collections.Generic;

namespace SharedApi.Interfaces
{
    public interface IClassFactory<T>
    {
        /// <summary>
        /// Creates a collection of classes from their fully qualified class name
        /// </summary>
        /// <returns>A collection of non-null class instances/></returns>
        /// <exception cref="ArgumentNullException">Thrown if class type collection is null/>
        /// <exception cref="UnknownTypeException">Thrown if a type is unknown</exception>
        /// <exception cref="InvalidTypeException">Thrown if a type is not a <see cref="T"/>
        IEnumerable<T> CreateClasses(IEnumerable<string> classTypeNames);
    }
}
