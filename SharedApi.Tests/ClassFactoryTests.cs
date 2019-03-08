using System;
using System.Collections.Generic;
using System.Linq;
using SharedApi.Exceptions;
using SharedApi.Tests.TestClass;
using Xunit;

namespace SharedApi.Tests
{
    public class ClassFactoryTests
    {
        private ClassFactory<TestModelPolicy> _target;

        public ClassFactoryTests()
        {
            _target = new ClassFactory<TestModelPolicy>();
        }

        [Fact]
        public void CreateClasses_ForNonIModelPolicyType_ThrowsArgumentNullException()
        {
            var exception = Record.Exception(() => { _target.CreateClasses(null); });

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void CreateClasses_ForNonIModelPolicyType_ThrowsInvalidTypeException()
        {
            var types = new List<string> { typeof(ModelPolicyFactoryTests).AssemblyQualifiedName };
            
            var exception = Record.Exception(() => { _target.CreateClasses(types); });

            Assert.IsType<InvalidTypeException>(exception);
        }

        [Fact]
        public void CreateClasses_ForNonIModelPolicyType_ThrowsUnknownTypeException()
        {
            var types = new List<string> { "FakeClassType" };

            var exception = Record.Exception(() => { _target.CreateClasses(types); });

            Assert.IsType<UnknownTypeException>(exception);
        }

        [Fact]
        public void CreateClasses_ForNoPolicyTypes_ReturnsEmptyCollection()
        {
            var types = new List<string>();

            var classes = _target.CreateClasses(types);

            Assert.False(classes.Any());
        }

        [Fact]
        public void CreateClasses_ForValidTypes_ReturnsClasses()
        {
            var types = new List<string>
            {
                typeof(TestModelPolicy).AssemblyQualifiedName,
                typeof(TestModelPolicy).AssemblyQualifiedName
            };

            var classes = _target.CreateClasses(types);

            Assert.Equal(types.Count, classes.Count());
        }
    }
}
