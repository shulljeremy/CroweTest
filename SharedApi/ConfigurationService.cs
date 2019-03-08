using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using SharedApi.Interfaces;

namespace SharedApi
{
    public class ConfigurationService : IConfigurationService
    {
        /// <inheritdoc />
        public IEnumerable<string> GetTypes(string groupName)
        {
            var types = new List<string>();
            var policyTypes = (NameValueCollection)ConfigurationManager.GetSection(groupName);
            if (policyTypes != null)
            {
                foreach (var typeName in policyTypes.AllKeys)
                {
                    types.Add(typeName);
                }
            }

            return types;
        }
    }
}
