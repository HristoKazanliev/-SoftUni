using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models.Interfaces
{
    public interface IAddCollection<T>
    {
        int Add(T item);
    }
}
