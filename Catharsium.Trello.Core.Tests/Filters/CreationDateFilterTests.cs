using Catharsium.Trello.Core.Filters;
using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Core;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace Catharsium.Trello.Core.Tests.Filters
{
    [TestClass]
    public class CreationDateFilterTests : TestFixture<CreationDateFilter>
    {
        #region Fixture

        private Card Card { get; set; }


        [TestInitialize]
        public void SetupProperties()
        {
            this.Card = new Card {Id = "My id"};
        }

        #endregion

        #region Includes

        [TestMethod]
        public void Includes_CreationDateBeforeFromDate_ReturnsFalse()
        {
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.GetDependency<ICreationDateRetriever>().FindCreationDate(this.Card.Id).Returns(fromDate.AddDays(-1));
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");

            var actual = this.Target.Includes(this.Card);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Includes_CreationDateEqualToFromDate_ReturnsTrue()
        {
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.GetDependency<ICreationDateRetriever>().FindCreationDate(this.Card.Id).Returns(fromDate);
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");

            var actual = this.Target.Includes(this.Card);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_CreationDateBetweenFromAndToDate_ReturnsTrue()
        {
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.GetDependency<ICreationDateRetriever>().FindCreationDate(this.Card.Id).Returns(fromDate.AddDays(1));
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");

            var actual = this.Target.Includes(this.Card);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_CreationDateEqualToToDate_ReturnsTrue()
        {
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.GetDependency<ICreationDateRetriever>().FindCreationDate(this.Card.Id).Returns(toDate);
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");

            var actual = this.Target.Includes(this.Card);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_CreationDateLargerThanToDate_ReturnsFalse()
        {
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.GetDependency<ICreationDateRetriever>().FindCreationDate(this.Card.Id).Returns(toDate.AddDays(1));
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");

            var actual = this.Target.Includes(this.Card);
            Assert.IsFalse(actual);
        }

        #endregion
    }
}