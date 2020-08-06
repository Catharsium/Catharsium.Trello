using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Data.Repository
{
    public class TrelloRepository : ITrelloRepository
    {
        public string Location { get; }
        private readonly IFileFactory fileFactory;
        private readonly IJsonFileReader jsonFileReader;
        private readonly IJsonFileWriter jsonFileWriter;


        public TrelloRepository(string location, IFileFactory fileFactory, IJsonFileReader jsonFileReader, IJsonFileWriter jsonFileWriter)
        {
            this.Location = location;
            this.fileFactory = fileFactory;
            this.jsonFileReader = jsonFileReader;
            this.jsonFileWriter = jsonFileWriter;
        }


        public async Task<IEnumerable<Board>> GetBoards()
        {
            var directory = this.fileFactory.CreateDirectory(this.Location);
            if (!directory.Exists) {
                return await Task.FromResult(Array.Empty<Board>());
            }

            var result = directory.GetFiles("*.json").Select(f => this.jsonFileReader.ReadFrom<Board>(f)).ToList();
            return await Task.FromResult(result);
        }


        public async Task<Board> GetBoard(string idOrName)
        {
            var boards = await this.GetBoards();
            var result = boards.FirstOrDefault(b => b.Id == idOrName || b.Name == idOrName);
            return await Task.FromResult(result);
        }


        public async Task Store(Board board)
        {
            var directory = this.fileFactory.CreateDirectory(this.Location);
            if (!directory.Exists) {
                directory.Create();
            }

            var file = this.fileFactory.CreateFile($"{this.Location}/{board.Name} ({DateTime.Now:yyyy-MM-dd}).json");
            if (file.Exists) {
                file.Delete();
            }

            await Task.Run(() => this.jsonFileWriter.Write(board, file));
        }
    }
}