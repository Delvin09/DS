using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib.Interfaces
{
    public interface ILinkedList<T> : ICollection<T>
    {
        T? First { get; }
        T? Last { get; }

        void Insert(int index, T value);

        void AddFirst(T value);
    }
}
