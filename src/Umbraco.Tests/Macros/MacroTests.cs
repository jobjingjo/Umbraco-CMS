﻿using Moq;
using NUnit.Framework;
using Umbraco.Core;
using Umbraco.Core.Cache;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Tests.TestHelpers;
using Umbraco.Web.Macros;

namespace Umbraco.Tests.Macros
{
    [TestFixture]
    public class MacroTests
    {

        [SetUp]
        public void Setup()
        {
            var typeFinder = TestHelper.GetTypeFinder();
            //we DO want cache enabled for these tests
            var cacheHelper = new AppCaches(
                new ObjectCacheAppCache(typeFinder),
                NoAppCache.Instance,
                new IsolatedCaches(type => new ObjectCacheAppCache(typeFinder)));
        }

        [TestCase("anything", true)]
        [TestCase("", false)]
        public void Macro_Is_File_Based(string macroSource, bool expectedNonNull)
        {
            var model = new MacroModel
            {
                MacroSource = macroSource
            };
            var filename = MacroRenderer.GetMacroFileName(model);
            if (expectedNonNull)
                Assert.IsNotNull(filename);
            else
                Assert.IsNull(filename);
        }

        //[TestCase(-5, true)] //the cache DateTime will be older than the file date
        //[TestCase(5, false)] //the cache DateTime will be newer than the file date
        public void Macro_Needs_Removing_Based_On_Macro_File(int minutesToNow, bool expectedNull)
        {
            // macro has been refactored, and macro.GetMacroContentFromCache() will
            // take care of the macro file, if any. It requires a web environment,
            // so we cannot really test this anymore.
        }

        public void Get_Macro_Cache_Identifier()
        {
            //var asdf  = macro.GetCacheIdentifier()
        }
    }
}
