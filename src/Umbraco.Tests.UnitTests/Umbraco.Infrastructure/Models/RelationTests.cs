﻿using System;
using System.Diagnostics;
using Newtonsoft.Json;
using NUnit.Framework;
using Umbraco.Core.Models;
using Umbraco.Tests.Common.Builders;
using Umbraco.Tests.Common.Builders.Extensions;

namespace Umbraco.Tests.UnitTests.Umbraco.Infrastructure.Models
{
    [TestFixture]
    public class RelationTests
    {
        private readonly RelationBuilder _builder = new RelationBuilder();

        [Test]
        public void Can_Deep_Clone()
        {
            var relation = BuildRelation();

            var clone = (Relation) relation.DeepClone();

            Assert.AreNotSame(clone, relation);
            Assert.AreEqual(clone, relation);
            Assert.AreEqual(clone.ChildId, relation.ChildId);
            Assert.AreEqual(clone.Comment, relation.Comment);
            Assert.AreEqual(clone.CreateDate, relation.CreateDate);
            Assert.AreEqual(clone.Id, relation.Id);
            Assert.AreEqual(clone.Key, relation.Key);
            Assert.AreEqual(clone.ParentId, relation.ParentId);
            Assert.AreNotSame(clone.RelationType, relation.RelationType);
            Assert.AreEqual(clone.RelationType, relation.RelationType);
            Assert.AreEqual(clone.RelationTypeId, relation.RelationTypeId);
            Assert.AreEqual(clone.UpdateDate, relation.UpdateDate);

            //This double verifies by reflection
            var allProps = clone.GetType().GetProperties();
            foreach (var propertyInfo in allProps)
            {
                Assert.AreEqual(propertyInfo.GetValue(clone, null), propertyInfo.GetValue(relation, null));
            }
        }

        [Test]
        public void Can_Serialize_Without_Error()
        {
            var relation = BuildRelation();

            var json = JsonConvert.SerializeObject(relation);
            Debug.Print(json);
        }

        private Relation BuildRelation()
        {
            return _builder
                .BetweenIds(9, 8)
                .WithId(4)
                .WithComment("test comment")
                .WithCreateDate(DateTime.Now)
                .WithUpdateDate(DateTime.Now)
                .WithKey(Guid.NewGuid())
                .AddRelationType()
                    .WithId(66)
                    .WithAlias("test")
                    .WithName("Test")
                    .WithIsBidirectional(false)
                    .WithParentObjectType(Guid.NewGuid())
                    .WithChildObjectType(Guid.NewGuid())
                    .Done()
                .Build();
        }
    }
}
