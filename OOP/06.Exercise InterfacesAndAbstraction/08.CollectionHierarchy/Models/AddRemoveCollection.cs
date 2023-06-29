using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    using Interfaces;
    using System.Linq;

    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private readonly IList<T> data;

        public AddRemoveCollection()
        {
            this.data = new List<T>();
        }

        public int Add(T item)
        {
            this.data.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            T lastItem = this.data.LastOrDefault();

            if (lastItem != null)
            {
                this.data.Remove(lastItem);
            }

            return lastItem;
        }
    }
}
