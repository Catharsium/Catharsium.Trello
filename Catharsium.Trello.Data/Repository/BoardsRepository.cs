using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Trello.Data.Repository
{
    public class BoardsRepository : IBoardsRepository
    {
        private readonly IFileFactory fileFactory;
        private readonly IJsonFileReader jsonFileReader;
        private readonly IJsonFileWriter jsonFileWriter;


        public BoardsRepository(IFileFactory fileFactory, IJsonFileReader jsonFileReader, IJsonFileWriter jsonFileWriter)
        {
            this.fileFactory = fileFactory;
            this.jsonFileReader = jsonFileReader;
            this.jsonFileWriter = jsonFileWriter;
        }


        public IEnumerable<Board> GetAll(string folder)
        {
            var directory = this.fileFactory.CreateDirectory(folder);
            if (directory.Exists) {
                return directory.GetFiles("*.json").Select(f => this.jsonFileReader.ReadFrom<Board>(f)).ToList();
            }

            return Array.Empty<Board>();
        }


        public void Store(Board board, string folder)
        {
            var directory = this.fileFactory.CreateDirectory(folder);
            if (!directory.Exists) {
                directory.Create();
            }

            var file = this.fileFactory.CreateFile($"{folder}/{board.Name} ({DateTime.Now:yyyy-MM-dd}).json");
            if (file.Exists) {
                file.Delete();
            }

            this.jsonFileWriter.Write(board, file);
        }
    }
}