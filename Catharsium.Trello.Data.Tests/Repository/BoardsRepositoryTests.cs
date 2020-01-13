using Catharsium.Trello.Data.Repository;
using Catharsium.Trello.Models;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;

namespace Catharsium.Trello.Data.Tests.Repository
{
    [TestClass]
    public class BoardsRepositoryTests : TestFixture<BoardsRepository>
    {
        #region Fixture

        private string Folder => "My folder";

        #endregion

        [TestMethod]
        public void Get_ValidFolder_ReturnsBoardsFromAllFiles()
        {
            var files = new[] { Substitute.For<IFile>(), Substitute.For<IFile>() };
            var expected = new Board();
            var directory = Substitute.For<IDirectory>();
            directory.Exists.Returns(true);
            directory.GetFiles("*.json").Returns(files);
            this.GetDependency<IFileFactory>().CreateDirectory(this.Folder).Returns(directory);
            this.GetDependency<IJsonFileReader>().ReadFrom<Board>(Arg.Is<IFile>(f => files.Contains(f))).Returns(expected);

            var actual = this.Target.GetAll(this.Folder);
            Assert.AreEqual(files.Length, actual.Count());
            foreach (var board in actual) {
                Assert.AreEqual(expected, board);
            }
        }
    }
}