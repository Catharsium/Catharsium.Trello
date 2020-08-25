using Catharsium.Trello.Data.Repository;
using Catharsium.Trello.Models;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Data.Tests.Repository
{
    [TestClass]
    public class TrelloRepositoryTests : TestFixture<TrelloRepository>
    {
        #region Fixture

        private static string Folder => "My folder";


        [TestInitialize]
        public void Initialize()
        {
            this.SetDependency(Folder, "folder");
        }

        #endregion

        #region GetAll

        [TestMethod]
        public async Task GetBoards_ValidFolder_ReturnsBoardsFromAllFiles()
        {
            var files = new[] {Substitute.For<IFile>(), Substitute.For<IFile>()};
            var expected = new Board();
            var directory = Substitute.For<IDirectory>();
            directory.Exists.Returns(true);
            directory.GetFiles("*.json").Returns(files);
            this.GetDependency<IFileFactory>().CreateDirectory(Folder).Returns(directory);
            this.GetDependency<IJsonFileReader>().ReadFrom<Board>(Arg.Is<IFile>(f => files.Contains(f))).Returns(expected);

            var actual = (await this.Target.GetBoards()).ToArray();
            Assert.AreEqual(1, actual.Length);
            foreach (var board in actual) {
                Assert.AreEqual(expected, board);
            }
        }

        #endregion

        #region GetBoard

        [TestMethod]
        public async Task GetBoard_ValidId_ReturnsBoardWithId()
        {
            var id = "My id";
            var files = new[] {Substitute.For<IFile>(), Substitute.For<IFile>()};
            var expected = new Board {Id = id};
            var directory = Substitute.For<IDirectory>();
            directory.Exists.Returns(true);
            directory.GetFiles("*.json").Returns(files);
            this.GetDependency<IFileFactory>().CreateDirectory(Folder).Returns(directory);
            this.GetDependency<IJsonFileReader>().ReadFrom<Board>(Arg.Is<IFile>(f => files.Contains(f))).Returns(expected);

            var actual = await this.Target.GetBoard(id);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public async Task GetBoard_ValidName_ReturnsBoardWithName()
        {
            var name = "My name";
            var files = new[] {Substitute.For<IFile>(), Substitute.For<IFile>()};
            var expected = new Board {Name = name};
            var directory = Substitute.For<IDirectory>();
            directory.Exists.Returns(true);
            directory.GetFiles("*.json").Returns(files);
            this.GetDependency<IFileFactory>().CreateDirectory(Folder).Returns(directory);
            this.GetDependency<IJsonFileReader>().ReadFrom<Board>(Arg.Is<IFile>(f => files.Contains(f))).Returns(expected);

            var actual = await this.Target.GetBoard(name);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Store

        [TestMethod]
        public async Task Store_ExistingFile_DeletesAndWritesToFile()
        {
            var board = new Board();
            var directory = Substitute.For<IDirectory>();
            directory.Exists.Returns(true);
            var file = Substitute.For<IFile>();
            file.Exists.Returns(true);
            this.GetDependency<IFileFactory>().CreateDirectory(Folder).Returns(directory);
            this.GetDependency<IFileFactory>().CreateFile($"{Folder}/{board.Name} ({DateTime.Now:yyyy-MM-dd}).json").Returns(file);

            await this.Target.Store(board);
            file.Received().Delete();
            this.GetDependency<IJsonFileWriter>().Received().Write(board, file);
        }


        [TestMethod]
        public async Task Store_NewFile_WritesToFile()
        {
            var board = new Board();
            var directory = Substitute.For<IDirectory>();
            directory.Exists.Returns(true);
            var file = Substitute.For<IFile>();
            file.Exists.Returns(false);
            this.GetDependency<IFileFactory>().CreateDirectory(Folder).Returns(directory);
            this.GetDependency<IFileFactory>().CreateFile($"{Folder}/{board.Name} ({DateTime.Now:yyyy-MM-dd}).json").Returns(file);

            await this.Target.Store(board);
            file.DidNotReceive().Delete();
            this.GetDependency<IJsonFileWriter>().Received().Write(board, file);
        }


        [TestMethod]
        public async Task Store_NewFolder_CreatesFolder()
        {
            var board = new Board();
            var directory = Substitute.For<IDirectory>();
            directory.Exists.Returns(false);
            var file = Substitute.For<IFile>();
            file.Exists.Returns(false);
            this.GetDependency<IFileFactory>().CreateDirectory(Folder).Returns(directory);
            this.GetDependency<IFileFactory>().CreateFile($"{Folder}/{board.Name} ({DateTime.Now:yyyy-MM-dd}).json").Returns(file);

            await this.Target.Store(board);
            directory.Received().Create();
            this.GetDependency<IJsonFileWriter>().Received().Write(board, file);
        }

        #endregion
    }
}