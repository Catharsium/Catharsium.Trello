using Catharsium.Trello.Core.Filters;
using Catharsium.Trello.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Catharsium.Trello.Models.Interfaces.Core;
using NSubstitute;

namespace Catharsium.Trello.Core.Tests.Filters
{
    [TestClass]
    public class DateFilterTests : TestFixture<DateFilter>
    {
        #region Fixture


        #endregion


        [TestMethod]
        public void Includes_CreationDateBeforeFromDate_ReturnsFalse()
        {
            var card = new Card {Id = "My id"};
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.GetDependency<ICreationDateRetriever>().FindCreationDate(card.Id).Returns(fromDate.AddDays(-1));
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");

            var actual = this.Target.Includes(card);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Includes_CreationDateEqualToFromDate_ReturnsTrue()
        {
            var card = new Card {Id = "My id"};
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.GetDependency<ICreationDateRetriever>().FindCreationDate(card.Id).Returns(fromDate);
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");

            var actual = this.Target.Includes(card);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_CreationDateBetweenFromAndToDate_ReturnsTrue()
        {
            var card = new Card {Id = "My id"};
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.GetDependency<ICreationDateRetriever>().FindCreationDate(card.Id).Returns(fromDate.AddDays(1));
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");

            var actual = this.Target.Includes(card);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_CreationDateEqualToToDate_ReturnsFalse()
        {
            var card = new Card {Id = "My id"};
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.GetDependency<ICreationDateRetriever>().FindCreationDate(card.Id).Returns(toDate);
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");

            var actual = this.Target.Includes(card);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_CreationDateLargerThanToDate_ReturnsFalse()
        {
            var card = new Card {Id = "My id"};
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.GetDependency<ICreationDateRetriever>().FindCreationDate(card.Id).Returns(toDate.AddDays(1));
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");

            var actual = this.Target.Includes(card);
            Assert.IsFalse(actual);
        }
    }
}