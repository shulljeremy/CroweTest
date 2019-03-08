using System.Collections.Generic;

namespace SharedApi.Interfaces
{
    public interface IModelPolicyFactory
    {
        /// <summary>
        /// Gets a collection of model policies
        /// </summary>
        /// <returns>A collection of non-null <see cref="IModelPolicy"/></returns>
        /// <exception cref="InvalidTypeException">Thrown if a type in the group is not a <see cref="IModelPolicy"/></exception>
        /// <exception cref="UnknownTypeException">Thrown if a type in the group is unknown</exception>
        IEnumerable<IModelPolicy> GetModelPolicies();
    }
}
