﻿using NUnit.Framework;
using Projbook.Core.Snippet;
using Projbook.Extension;
using Projbook.Extension.CSharpExtractor;
using Projbook.Tests.Utilities;

namespace Projbook.Tests.Core.Snippet
{
    /// <summary>
    /// Tests <see cref="SnippetExtractorFactory"/>.
    /// </summary>
    [TestFixture]
    public class SnippetExtractorFactoryTests
    {
        /// <summary>
        /// The tested extractor factory.
        /// </summary>
        public SnippetExtractorFactory SnippetExtractorFactory { get; private set; }

        /// <summary>
        /// Initializes the test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Initialize extractor
            this.SnippetExtractorFactory = new SnippetExtractorFactory(TestsUtilities.EnsureExtensionsDeployed());
        }

        /// <summary>
        /// Tests extract CreateExstractor.
        /// </summary>
        [Test]
        public void CreateEmpty()
        {
            Assert.IsNull(this.SnippetExtractorFactory.CreateExtractor(null));
        }

        /// <summary>
        /// Tests extract CreateExstractor.
        /// </summary>
        [Test]
        [TestCase]
        public void CreateExtractorUnknownLanguage()
        {
            // Process
            DefaultSnippetExtractor extractor = this.SnippetExtractorFactory.CreateExtractor(SnippetExtractionRule.Parse("foo [File.cs]")) as DefaultSnippetExtractor;
            Assert.IsNotNull(extractor);
            Assert.IsTrue(extractor is DefaultSnippetExtractor);
        }

        /// <summary>
        /// Tests extract CreateExstractor.
        /// </summary>
        [Test]
        [TestCase]
        public void CreateExtractorKnownLanguageNoSnippet()
        {
            // Process
            Assert.IsNull(this.SnippetExtractorFactory.CreateExtractor(SnippetExtractionRule.Parse("csharp")));
        }

        /// <summary>
        /// Tests extract CreateExstractor.
        /// </summary>
        [Test]
        [TestCase]
        public void CreateExtractorKnownLanguageCSharpEmptySnippet()
        {
            // Process
            Assert.IsNull(this.SnippetExtractorFactory.CreateExtractor(SnippetExtractionRule.Parse("csharp []")));
        }

        /// <summary>
        /// Tests extract CreateExstractor.
        /// </summary>
        [Test]
        [TestCase]
        public void CreateExtractorKnownLanguageCSharpSnippet()
        {
            // Process
            CSharpSnippetExtractor extractor = this.SnippetExtractorFactory.CreateExtractor(SnippetExtractionRule.Parse("csharp [File.cs]")) as CSharpSnippetExtractor;
            Assert.IsNotNull(extractor);
        }
    }
}