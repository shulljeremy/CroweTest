using System;
using System.Threading.Tasks;
using SharedApi.Interfaces;
using SharedApi.Models;

namespace SharedApi
{
    public class ConsoleModelPolicy : IModelPolicy
    {
        /// <inheritdoc />
        public Task ProcessModelAsync(Model model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Model cannot be null.");
            }

            Console.WriteLine(model.Text);

            return Task.CompletedTask;
        }
    }
}
