using SharedApi;
using SharedApi.Interfaces;
using SharedApi.Models;
using System;

namespace CroweTest
{
    class Program
    {
        private static IModelApi _modelApi;

        static void Main(string[] args)
        {
            try
            {
                InitializeDependencies();
                DoWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while initializing dependencies:\n{ex.Message}\n");
            }

            WaitToExit();
        }

        private static async void DoWork()
        {
            var model = new Model { Text = "Hello World" };
            await _modelApi.ProcessModelAsync(model);
        }

        private static void WaitToExit()
        {
            Console.WriteLine("\nPress any key to exit");
            Console.ReadLine();
        }

        private static void InitializeDependencies()
        {
            var configurationService = new ConfigurationService();
            var modelPolicyFactory = new ModelPolicyFactory(configurationService);
            _modelApi = new ModelApi(modelPolicyFactory);
        }
    }
}
