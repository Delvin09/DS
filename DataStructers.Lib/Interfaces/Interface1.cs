using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib.Interfaces
{
    public interface ILinkedList : ICollection
    {
        object? First { get; }
        object? Last { get; }

        void Insert(int index, object value);

        void AddFirst(object value);
    }
}
