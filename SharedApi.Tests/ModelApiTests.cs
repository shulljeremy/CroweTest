using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using SharedApi.Interfaces;
using SharedApi.Models;
using Xunit;

namespace SharedApi.Tests
{
    public class ModelApiTests
    {
        private ModelApi _target;
        private Mock<IModelPolicyFactory> _modelFactoryMoq = new Mock<IModelPolicyFactory>();
        private Mock<IModelPolicy> _policyMock = new Mock<IModelPolicy>();

        private List<IModelPolicy> _policyList = new List<IModelPolicy>();
        private Model _validModel = Model.Example();

        public ModelApiTests()
        {
            _modelFactoryMoq.Setup(x => x.GetModelPolicies())
                .Returns(_policyList);

            _target = new ModelApi(_modelFactoryMoq.Object);
        }

        [Fact]
        public async Task ProcessModelAsync_WithValidModel_CallsProcessOnPolicies()
        {
            _policyList.Add(_policyMock.Object);
            _policyList.Add(_policyMock.Object);
            _policyList.Add(_policyMock.Object);

            await _target.ProcessModelAsync(_validModel);

            _policyMock.Verify(x => x.ProcessModelAsync(It.Is<Model>(m => m == _validModel)), Times.Exactly(_policyList.Count));
        }

        [Fact]
        public async Task ProcessModelAsync_WithNullModel_ThrowsArgumentNullException()
        {
            var exception = await Record.ExceptionAsync(async () => await _target.ProcessModelAsync(null) );

            Assert.IsType<ArgumentNullException>(exception);
        }
    }
}
