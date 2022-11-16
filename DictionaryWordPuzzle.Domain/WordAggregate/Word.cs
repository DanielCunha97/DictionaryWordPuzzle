using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryWordPuzzle.Domain.WordAggregate
{
    public class Word : IAggregateRoot
    {
        public Word(string value)
        {
        
        }

        protected Word(IWordStoreObject storeObject)
        {
            LoadFromStore(storeObject);
        }

        public string Value { get; protected set; }

        public static Word LoadFrom(IWordStoreObject storeObject)
        {
            if (storeObject == null)
                throw new ArgumentNullException(nameof(storeObject));

            return new Word(storeObject);
        }

        protected virtual void LoadFromStore(IWordStoreObject storeObject)
        {
            Value = storeObject.Value;
        }
    }
}
