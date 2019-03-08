using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SharedApi.Exceptions;
using SharedApi.Interfaces;
using SharedApi.Tests.TestClass;
using Xunit;

namespace SharedApi.Tests
{
    public class ModelPolicyFactoryTests
    {
        private ModelPolicyFactory _target;
        private Mock<IConfigurationService> _configurationServiceMock = new Mock<IConfigurationService>();

        private List<string> _types = new List<string>(); 

        public ModelPolicyFactoryTests()
        {
            _configurationServiceMock.Setup(x => x.GetTypes(It.IsAny<string>()))
                .Returns(_types);

            _target = new ModelPolicyFactory(_configurationServiceMock.Object);
        }

        [Fact]
        public void GetModelPolicies_ForNonIModelPolicyType_ThrowsInvalidTypeException()
        {
            _types.Add(typeof(ModelPolicyFactoryTests).AssemblyQualifiedName);

            var exception = Record.Exception(() => { _target.GetModelPolicies(); });

            Assert.IsType<InvalidTypeException>(exception);
        }

        [Fact]
        public void GetModelPolicies_ForNonIModelPolicyType_ThrowsUnknownTypeException()
        {
            _types.Add("FakeClassType");

            var exception = Record.Exception(() => { _target.GetModelPolicies(); });

            Assert.IsType<UnknownTypeException>(exception);
        }

        [Fact]
        public void GetModelPolicies_ForNoPolicyTypes_ReturnsEmptyPolicyCollection()
        {
            var policies = _target.GetModelPolicies();

            Assert.False(policies.Any());
        }

        [Fact]
        public void GetModelPolicies_ForValidTypes_ReturnsPolicies()
        {
            _types.Add(typeof(TestModelPolicy).AssemblyQualifiedName);
            _types.Add(typeof(TestModelPolicy).AssemblyQualifiedName);

            var policies = _target.GetModelPolicies();

            Assert.Equal(_types.Count, policies.Count());
        }
    }
}
