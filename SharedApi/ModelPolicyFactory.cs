using System.Collections.Generic;
using SharedApi.Interfaces;

namespace SharedApi
{
    public class ModelPolicyFactory : ClassFactory<IModelPolicy>, IModelPolicyFactory
    {
        private IConfigurationService _configurationService;

        public ModelPolicyFactory(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        /// <inheritdoc />
        public IEnumerable<IModelPolicy> GetModelPolicies()
        {
            var policyTypes = _configurationService.GetTypes("modelPolicies");
            return CreateClasses(policyTypes);
        }
    }
}
