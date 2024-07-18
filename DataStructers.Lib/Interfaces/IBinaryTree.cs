using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib.Interfaces
{
    public interface IBinaryTree<T> : ICollection<T> 
        where T : IComparable<T>
    {
        T? Root { get; }
    }
}
