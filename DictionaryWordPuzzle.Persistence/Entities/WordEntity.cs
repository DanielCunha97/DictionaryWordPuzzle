using DictionaryWordPuzzle.Domain.WordAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryWordPuzzle.Persistence.Entities
{
    public class WordEntity : IWordStoreObject
    {
        public string Value { get; set; }
    }
}
