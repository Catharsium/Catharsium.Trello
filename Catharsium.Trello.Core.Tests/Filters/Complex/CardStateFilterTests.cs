using Catharsium.Trello.Core.Filters.Complex;
using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Enums;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Trello.Core.Tests.Filters.Complex
{
    [TestClass]
    public class CardStateFilterTests : TestFixture<CardStateFilter>
    {
        #region Includes (Unplanned)

        [TestMethod]
        public void Includes_Unplanned_CardWithoutDueDate_ReturnsTrue()
        {
            var card = new Card {
                Due = null
            };
            this.SetDependency(CardState.Unplanned);

            var actual = this.Target.Includes(card);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_Unplanned_CardWithDueDate_ReturnsFalse()
        {
            var card = new Card {
                Due = DateTime.Now
            };
            this.SetDependency(CardState.Unplanned);

            var actual = this.Target.Includes(card);
            Assert.IsFalse(actual);
        }

        #endregion

        #region Includes (Planned)

        [TestMethod]
        public void Includes_Planned_CardWithDueDate_ReturnsTrue()
        {
            var card = new Card {
                Due = DateTime.Now
            };
            this.SetDependency(CardState.Planned);

            var actual = this.Target.Includes(card);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_Planned_CardWithoutDueDate_ReturnsFalse()
        {
            var card = new Card {
                Due = null
            };
            this.SetDependency(CardState.Planned);

            var actual = this.Target.Includes(card);
            Assert.IsFalse(actual);
        }

        #endregion

        #region Open

        [TestMethod]
        public void Includes_Open_CardWithoutDueDate_ReturnsTrue()
        {
            var card = new Card {
                Due = null,
                DueComplete = false
            };
            this.SetDependency(CardState.Open);

            var actual = this.Target.Includes(card);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_Open_NonCompletedCardWithDueDate_ReturnsTrue()
        {
            var card = new Card {
                Due = DateTime.Now,
                DueComplete = false
            };
            this.SetDependency(CardState.Open);

            var actual = this.Target.Includes(card);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_Open_CompletedCardWithDueDate_ReturnsFalse()
        {
            var card = new Card {
                Due = DateTime.Now,
                DueComplete = true
            };
            this.SetDependency(CardState.Open);

            var actual = this.Target.Includes(card);
            Assert.IsFalse(actual);
        }

        #endregion

        #region Includes (Completed)

        [TestMethod]
        public void Includes_Completed_CompletedCard_ReturnsTrue()
        {
            var card = new Card {
                DueComplete = true
            };
            this.SetDependency(CardState.Completed);

            var actual = this.Target.Includes(card);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Includes_Completed_NonCompletedCard_ReturnsFalse()
        {
            var card = new Card {
                DueComplete = false
            };
            this.SetDependency(CardState.Completed);

            var actual = this.Target.Includes(card);
            Assert.IsFalse(actual);
        }

        #endregion
    }
}