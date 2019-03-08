using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedApi.Interfaces;
using SharedApi.Models;

namespace SharedApi
{
    public class ModelApi : IModelApi
    {
        private IEnumerable<IModelPolicy> _modelPolicies;
        
        public ModelApi(IModelPolicyFactory modelPolicyFactory)
        {
            _modelPolicies = modelPolicyFactory.GetModelPolicies();
        }

        /// <inheritdoc />
        public async Task ProcessModelAsync(Model model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Model cannot be null.");
            }

            var tasks = new List<Task>();
            foreach (var policy in _modelPolicies)
            {
                tasks.Add(policy.ProcessModelAsync(model));
            }
            await Task.WhenAll(tasks);
        }
    }
}
