using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.IO.Interfaces;
using System;
using System.Collections.Generic;

namespace Catharsium.Trello.Data.Repository
{
    public class BoardsRepository : IBoardsRepository
    {
        private readonly IFileFactory fileFactory;
        private readonly IJsonFileReader jsonFileReader;


        public BoardsRepository(IFileFactory fileFactory, IJsonFileReader jsonFileReader)
        {
            this.fileFactory = fileFactory;
            this.jsonFileReader = jsonFileReader;
        }


        public IEnumerable<Board> GetAll(string folder)
        {
            var directory = this.fileFactory.CreateDirectory(folder);
            if (directory.Exists) {
                var result = new List<Board>();
                foreach (var file in directory.GetFiles("*.json")) {
                    result.Add(this.jsonFileReader.ReadFrom<Board>(file));
                }

                return result;
            }

            return Array.Empty<Board>();
        }
    }
}