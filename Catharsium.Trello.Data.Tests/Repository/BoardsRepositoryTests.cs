using System;
using Catharsium.Trello.Data.Repository;
using Catharsium.Trello.Models;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Data.Tests.Repository
{
    [TestClass]
    public class BoardsRepositoryTests : TestFixture<BoardsRepository>
    {
        #region Fixture

        private static string Folder => "My folder";

        #endregion

        #region GetAll

        [TestMethod]
        public void GetAll_ValidFolder_ReturnsBoardsFromAllFiles()
        {
            var files = new[] {Substitute.For<IFile>(), Substitute.For<IFile>()};
            var expected = new Board();
            var directory = Substitute.For<IDirectory>();
            directory.Exists.Returns(true);
            directory.GetFiles("*.json").Returns(files);
            this.GetDependency<IFileFactory>().CreateDirectory(Folder).Returns(directory);
            this.GetDependency<IJsonFileReader>().ReadFrom<Board>(Arg.Is<IFile>(f => files.Contains(f))).Returns(expected);

            var actual = this.Target.GetAll(Folder).ToArray();
            Assert.AreEqual(files.Length, actual.Length);
            foreach (var board in actual) {
                Assert.AreEqual(expected, board);
            }
        }

        #endregion

        #region Store

        [TestMethod]
        public void Store_ExistingFile_DeletesAndWritesToFile()
        {
            var board = new Board();
            var directory = Substitute.For<IDirectory>();
            directory.Exists.Returns(true);
            var file = Substitute.For<IFile>();
            file.Exists.Returns(true);
            this.GetDependency<IFileFactory>().CreateDirectory(Folder).Returns(directory);
            this.GetDependency<IFileFactory>().CreateFile($"{Folder}/{board.Name} ({DateTime.Now:yyyy-MM-dd}).json").Returns(file);

            this.Target.Store(board, Folder);
            file.Received().Delete();
            this.GetDependency<IJsonFileWriter>().Received().Write(board, file);
        }


        [TestMethod]
        public void Store_NewFile_WritesToFile()
        {
            var board = new Board();
            var directory = Substitute.For<IDirectory>();
            directory.Exists.Returns(true);
            var file = Substitute.For<IFile>();
            file.Exists.Returns(false);
            this.GetDependency<IFileFactory>().CreateDirectory(Folder).Returns(directory);
            this.GetDependency<IFileFactory>().CreateFile($"{Folder}/{board.Name} ({DateTime.Now:yyyy-MM-dd}).json").Returns(file);

            this.Target.Store(board, Folder);
            file.DidNotReceive().Delete();
            this.GetDependency<IJsonFileWriter>().Received().Write(board, file);
        }



        [TestMethod]
        public void Store_NewFolder_CreatesFolder()
        {
            var board = new Board();
            var directory = Substitute.For<IDirectory>();
            directory.Exists.Returns(false);
            var file = Substitute.For<IFile>();
            file.Exists.Returns(false);
            this.GetDependency<IFileFactory>().CreateDirectory(Folder).Returns(directory);
            this.GetDependency<IFileFactory>().CreateFile($"{Folder}/{board.Name} ({DateTime.Now:yyyy-MM-dd}).json").Returns(file);

            this.Target.Store(board, Folder);
            directory.Received().Create();
            this.GetDependency<IJsonFileWriter>().Received().Write(board, file);
        }

        #endregion
    }
}