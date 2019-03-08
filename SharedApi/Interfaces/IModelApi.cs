using System.Threading.Tasks;
using SharedApi.Models;

namespace SharedApi.Interfaces
{
    public interface IModelApi
    {
        /// <summary>
        /// Processes the model
        /// </summary>
        /// <param name="model">The model to process</param>
        /// <returns>A <see cref="Task"/> to await</returns>
        /// <exception cref="ArgumentNullException">Thrown if a null model is passed in</exception>
        Task ProcessModelAsync(Model model);
    }
}
