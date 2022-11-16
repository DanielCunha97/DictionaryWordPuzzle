using DictionaryWordPuzzle.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryWordPuzzle.Persistence
{
    public interface IRepositoryContext
    {
        IEnumerable<WordEntity> Words { get; }
        void SaveOutputFileAsync(IEnumerable<WordEntity> resultList, string outputFilePath = null);
    }
}
