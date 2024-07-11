using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructers.Lib.Interfaces
{
    public interface IBinaryTree : ICollection
    {
        object? Root { get; }
    }
}
