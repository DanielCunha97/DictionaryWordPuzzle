using DictionaryWordPuzzle.Domain.Persistence;
using DictionaryWordPuzzle.Domain.WordAggregate;
using DictionaryWordPuzzle.Persistence.Entities;
using DictionaryWordPuzzle.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace DictionaryWordPuzzle.Persistence.Repositories
{
    public class WordRepository : IWordRepository
    {
        private readonly IRepositoryContext _repositoryContext;

        public WordRepository(IRepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }

        public IEnumerable<Word> Get(CancellationToken cancellationToken = default)
        {
            List<Word> words = new List<Word>();
            var wordsEntity = this._repositoryContext.Words;
            if (!wordsEntity.Any())
                return null;
            foreach (var wordEntity in wordsEntity)
            {
                words.Add(Word.LoadFrom(wordEntity));
            }
            return words;
        }

        public void Add(IEnumerable<Word> wordListAggregateRoot, string outputFilePath = null)
        {
            List<WordEntity> wordEntityList = new List<WordEntity>();
            foreach (Word word in wordListAggregateRoot)
            {
                wordEntityList.Add(word.ToEntity());
            }
            this._repositoryContext.SaveOutputFileAsync(wordEntityList, outputFilePath);
        }
    }
}
