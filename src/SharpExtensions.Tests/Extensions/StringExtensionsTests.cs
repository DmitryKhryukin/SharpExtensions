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
                string content = "<b>Kventin</b> Tarantino";
                content.RemoveTags().Should().Be("Kventin Tarantino");
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
                content.CutContent(5, "...").Should().EndWith("...");
            }

            [Test]
            public void ContentLessThanBound_AppendixIsNotAddedToTheEndOfResult()
            {
                string content = "some string";
                content.CutContent(5, "...").Should().Be("some...");
            }
        }
    }
}