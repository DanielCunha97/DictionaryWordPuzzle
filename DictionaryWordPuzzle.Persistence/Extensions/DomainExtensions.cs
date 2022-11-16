using DictionaryWordPuzzle.Domain.WordAggregate;
using DictionaryWordPuzzle.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DictionaryWordPuzzle.Persistence.Extensions
{
    public static class DomainExtensions
    {
        public static WordEntity ToEntity(this Word value)
        {
            if (value == null)
                return null;

            return new WordEntity
            {
                Value = value.Value
            };
        }
    }
}
