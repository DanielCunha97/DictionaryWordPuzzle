using DictionaryWordPuzzle.Domain.Persistence;
using DictionaryWordPuzzle.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryWordPuzzle.Persistence
{
    // trying to implement a DbContext of Entity Framework. Words-english file acts as database
    public class RepositoryContext : IRepositoryContext
    {
        private readonly string inputFilePath;

        public RepositoryContext()
        {
            this.inputFilePath = $"{Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"))}Resources\\words-english.txt";
            this.LoadWords();
        }

        public RepositoryContext(string inputFilePath)
        {
            this.inputFilePath = inputFilePath ??
                $"{Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"))}Resources\\words-english.txt";
            this.LoadWords();
        }

        public virtual IEnumerable<WordEntity> Words { get; private set; }

        public virtual async void SaveOutputFileAsync(IEnumerable<WordEntity> resultList, string outputFilePath = null)
        {
            try
            {
                // path to result file
                var pathToSave = this.inputFilePath.Replace("words-english.txt", $"Results\\{outputFilePath}");
                var file = new FileInfo(pathToSave);
                file.Directory.Create();
                await File.WriteAllLinesAsync(pathToSave, resultList.Select(w => w.Value).ToList());

                Console.WriteLine($"Results saved at: {pathToSave}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving the result list on: {outputFilePath}. Error message: {ex.Message} \nInner message: {ex.InnerException}");
            }
        }

        private async void LoadWords()
        {
            try
            {
                var result = await File.ReadAllLinesAsync(this.inputFilePath);
                var words = result.ToList().Select(w => w.Trim().ToLower()).Distinct();
                this.Words = words.Select(word => new WordEntity(word));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading the file. \nError message: {ex.Message} \nInner message: {ex.InnerException}");
            }
        }
    }
}
