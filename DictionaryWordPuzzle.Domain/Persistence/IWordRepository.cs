using DictionaryWordPuzzle.Domain.WordAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DictionaryWordPuzzle.Domain.Persistence
{
    public interface IWordRepository
    {
        IEnumerable<Word> Get(CancellationToken cancellationToken = default);

        void Add(IEnumerable<Word> wordListAggregateRoot, string outputFilePath = null);

    }
}
