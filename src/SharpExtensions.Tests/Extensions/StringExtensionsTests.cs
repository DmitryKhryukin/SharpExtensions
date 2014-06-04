using System;
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
                string content = "<b>Quentin</b> Tarantino";
                content.RemoveTags().Should().Be("Quentin Tarantino");
            }
        }

        public class CutContentMethod
        {
            [Test]
            public void NullString_ReturnEmptyString()
            {
                string content = null;
                content.CutContent(10, "").Should().Be(string.Empty);
            }

            [Test]
            public void EmptyString_ReturnEmptyString()
            {
                string content = string.Empty;
                content.CutContent(10, "").Should().Be(string.Empty);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Bound should be positive")]
            public void BoundIsNotPositive_ThrowExeption()
            {
                string content = "some string";
                content.CutContent(-5);
            }

            [Test]
            public void ContentMoreThanBound_AppendixIsAddedToTheEndOfResult()
            {
                string content = "some string";
                content.CutContent(5, "...").Should().Be("some..."); ;
            }

            [Test]
            public void ContentLessThanBound__ReturnAsIs()
            {
                string content = "some string";
                content.CutContent(100, "...").Should().Be("some string");
            }

            [Test]
            public void NonApphanumericSimbols_ShouldBeTrimmed()
            {
                string content = "some,  .: string";
                content.CutContent(8, "...").Should().Be("some...");
            }
        }

        public class ReverseMethod
        {
            [Test]
            public void NullString_ReturnNull()
            {
                string input = null;
                input.Reverse().Should().Be(null);
            }

            [Test]
            public void EmptyString_ReturnEmpty()
            {
                string input = "";
                input.Reverse().Should().Be("");
            }

            [Test]
            public void ReverseString()
            {
                string input = "abcd efg?!";
                input.Reverse().Should().Be("!?gfe dcba");
            }
        }
    }
}
