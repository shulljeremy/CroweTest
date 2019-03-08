using System;
using System.Threading.Tasks;
using SharedApi.Models;
using Xunit;

namespace SharedApi.Tests
{
    public class ConsoleModelPolicyTests
    {
        private ConsoleModelPolicy _target;

        private Model _validModel = Model.Example();

        public ConsoleModelPolicyTests()
        {
            _target = new ConsoleModelPolicy();
        }

        [Fact]
        public async Task ProcessModelAsync_WithValidModel_DoesNotThrowException()
        {
            var exception = await Record.ExceptionAsync(async  () => { await _target.ProcessModelAsync(_validModel); });

            Assert.Null(exception);
        }

        [Fact]
        public async Task ProcessModelAsync_WithNullModel_ThrowsArgumentNullException()
        {
            var exception = await Record.ExceptionAsync(async () => { await _target.ProcessModelAsync(null); });

            Assert.IsType<ArgumentNullException>(exception);
        }
    }
}
