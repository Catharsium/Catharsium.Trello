using Catharsium.Trello.Core.Filters;
using Catharsium.Trello.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Trello.Core.Tests.Filters
{
    [TestClass]
    public class DueDateFilterTests : TestFixture<DueDateFilter>
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
        public void Includes_NoDueDate_ReturnsFalse()
        {
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");
            this.Card.Due = null;

            var actual = this.Target.Includes(this.Card);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Includes_DueDateBeforeFromDate_ReturnsFalse()
        {
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");
            this.Card.Due = fromDate.AddDays(-1);

            var actual = this.Target.Includes(this.Card);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Includes_DueDateEqualToFromDate_ReturnsTrue()
        {
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");
            this.Card.Due = fromDate;

            var actual = this.Target.Includes(this.Card);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_CreationDateBetweenFromAndToDate_ReturnsTrue()
        {
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");
            this.Card.Due = fromDate.AddDays(1);

            var actual = this.Target.Includes(this.Card);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_DueDateEqualToToDate_ReturnsTrue()
        {
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");
            this.Card.Due = toDate;

            var actual = this.Target.Includes(this.Card);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_DueDateLargerThanToDate_ReturnsFalse()
        {
            var fromDate = DateTime.Now.AddDays(-1);
            var toDate = DateTime.Now.AddDays(1);
            this.SetDependency(fromDate, "fromDate");
            this.SetDependency(toDate, "toDate");
            this.Card.Due = toDate.AddDays(1);

            var actual = this.Target.Includes(this.Card);
            Assert.IsFalse(actual);
        }

        #endregion
    }
}