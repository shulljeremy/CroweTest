using System.Threading.Tasks;
using SharedApi.Interfaces;
using SharedApi.Models;

namespace SharedApi.Tests.TestClass
{
    public class TestModelPolicy : IModelPolicy
    {
        public Task ProcessModelAsync(Model model)
        {
            return Task.CompletedTask;
        }
    }
}
