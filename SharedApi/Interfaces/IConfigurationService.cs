using System;
using System.Collections.Generic;

namespace SharedApi.Interfaces
{
    public interface IConfigurationService
    {
        /// <summary>
        /// Gets a collection of types for a given group
        /// </summary>
        /// <param name="groupName">Name of the group that contains types.</param>
        /// <returns>A collection of full qualified class type names</returns>
        IEnumerable<string> GetTypes(string groupName);
    }
}
