using AutoMapper;
using Catharsium.Trello.Api.Client.Clients;
using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Api.Client.Models;
using Catharsium.Trello.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace Catharsium.Trello.Api.Client.Tests.Clients
{
    [TestClass]
    public class CardsClientTests : TestFixture<CardsClient>
    {
        #region Fixture

        private static string BoardId => "My board id";
        private static string ListId => "My list id";

        #endregion

        #region CreateNew

        [TestMethod]
        public async Task CreateNew_ValidRequiredFields_PostsData()
        {
            var name = "My name";
            var expected = new Card();
            var apiCard = new ApiCard();
            this.GetDependency<ITrelloRestClient>().Post<ApiCard>("cards", Arg.Is<Dictionary<string, object>>(p =>
                    p.ContainsKey("name") &&
                    (string)p["name"] == HttpUtility.UrlEncode(name) &&
                    p.ContainsKey("idBoard") &&
                    (string)p["idBoard"] == BoardId &&
                    p.ContainsKey("idList") &&
                    (string)p["idList"] == ListId &&
                    !p.ContainsKey("pos") &&
                    !p.ContainsKey("idLabels") &&
                    !p.ContainsKey("due") &&
                    !p.ContainsKey("dueComplete")
                ))
                .Returns(apiCard);
            this.GetDependency<IMapper>().Map<Card>(apiCard).Returns(expected);

            var actual = await this.Target.CreateNew(name, BoardId, ListId);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public async Task CreateNew_ValidOptionalFields_PostsData()
        {
            var name = "My name";
            var sourceListId = "My source list id";
            var position = "My position";
            var labels = new[] { "My label" };
            var due = DateTime.Now;
            var expected = new Card();
            var apiCard = new ApiCard();
            this.GetDependency<ITrelloRestClient>().Post<ApiCard>("cards", Arg.Is<Dictionary<string, object>>(p =>
                    p.ContainsKey("pos") &&
                    (string)p["pos"] == position &&
                    p.ContainsKey("idLabels") &&
                    (string)p["idLabels"] == string.Join(",", labels) &&
                    p.ContainsKey("due") &&
                    (string)p["due"] == HttpUtility.UrlEncode($"{due:YYYY-MM-ddTHH:mm:ssZ}") &&
                    p.ContainsKey("dueComplete") &&
                    (string)p["dueComplete"] == "1"
                ))
                .Returns(apiCard);
            this.GetDependency<IMapper>().Map<Card>(apiCard).Returns(expected);

            var actual = await this.Target.CreateNew(name, BoardId, sourceListId, position, labels, due, true);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Update

        [TestMethod]
        public async Task Update_ValidRequiredFields_PostsData()
        {
            var id = "My id";
            var expected = new Card();
            var apiCard = new ApiCard();
            this.GetDependency<ITrelloRestClient>().Put<ApiCard>($"cards/{id}", Arg.Is<Dictionary<string, object>>(p =>
                    p.ContainsKey("idBoard") &&
                    (string)p["idBoard"] == BoardId &&
                    p.ContainsKey("idList") &&
                    (string)p["idList"] == ListId &&
                    !p.ContainsKey("name") &&
                    !p.ContainsKey("pos") &&
                    !p.ContainsKey("idLabels") &&
                    !p.ContainsKey("due") &&
                    !p.ContainsKey("dueComplete")
                ))
                .Returns(apiCard);
            this.GetDependency<IMapper>().Map<Card>(apiCard).Returns(expected);

            var actual = await this.Target.Update(id, BoardId, ListId);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public async Task Update_ValidOptionalFields_PostsData()
        {
            var id = "My id";
            var name = "My name";
            var sourceListId = "My source list id";
            var position = "My position";
            var labels = new[] { "My label" };
            var due = DateTime.Now;
            var expected = new Card();
            var apiCard = new ApiCard();
            this.GetDependency<ITrelloRestClient>().Put<ApiCard>($"cards/{id}", Arg.Is<Dictionary<string, object>>(p =>
                    p.ContainsKey("pos") &&
                    (string)p["pos"] == position &&
                    p.ContainsKey("idLabels") &&
                    (string)p["idLabels"] == string.Join(",", labels) &&
                    p.ContainsKey("due") &&
                    (string)p["due"] == $"{due.ToUniversalTime():yyyy-MM-ddTHH:mm:ssZ}" &&
                    p.ContainsKey("dueComplete") &&
                    (bool)p["dueComplete"]
                ))
                .Returns(apiCard);
            this.GetDependency<IMapper>().Map<Card>(apiCard).Returns(expected);

            var actual = await this.Target.Update(id, BoardId, sourceListId, name, position, labels, due, true);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}