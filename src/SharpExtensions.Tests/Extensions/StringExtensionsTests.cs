using NUnit.Framework;
using FluentAssertions;
using SharpExtensions.Extensions;

namespace SharpExtensions.Tests.Extensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        public class RemoveTagsMethod
        {
            [Test]
            public void NullString_ReturnEmptyString()
            {
                string content = null;
                content.RemoveTags().Should().Be(string.Empty);
            }

            [Test]
            public void EmptyString_ReturnEmptyString()
            {
                string content = "";
                content.RemoveTags().Should().Be(string.Empty);
            }

            [Test]
            public void WiteSpaceString_ReturnEmptyString()
            {
                string content = "   ";
                content.RemoveTags().Should().Be(string.Empty);
            }

            [Test]
            public void StringWithTags_RemoveTags()
            {
                string content = "<b>Kventin</b> Tarantino";
                content.RemoveTags().Should().Be("Kventin Tarantino");
            }
        }
    }
}