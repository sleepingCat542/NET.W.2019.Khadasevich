using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeLib.Tests
{
    interface IComparer<T>
    {
        int Compare(T firstelem, T secondElem);
    }
}
