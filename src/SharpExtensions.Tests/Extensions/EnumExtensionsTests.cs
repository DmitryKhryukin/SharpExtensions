using FluentAssertions;
using NUnit.Framework;
using SharpExtensions.Extensions;

namespace SharpExtensions.Tests.Extensions
{
    [TestFixture]  
    public class EnumExtensionsTests
    {
        public class GetDescriptionMethod
        {
            private enum SomeEnum
            {
                [System.ComponentModel.Description("The first option")]
                FirstOption,

                SecondOption
            }

            [Test]
            public void EnumElement_HasDescription_ReturnDescription()
            {
                SomeEnum.FirstOption.GetDescription().Should().Be("The first option");
            }

            [Test]
            public void EnumElement_DoesNotHaveDescription_ReturnEnumElementToString()
            {
                SomeEnum.SecondOption.GetDescription().Should().Be("SecondOption");
            }
        }
    }
}