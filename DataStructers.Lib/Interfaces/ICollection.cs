using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib.Interfaces
{
    public interface ICollection<T>
    {
        int Count { get; }

        void Clear();

        T[] ToArray();
    }
}
