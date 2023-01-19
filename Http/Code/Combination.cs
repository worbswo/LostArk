using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.Code
{
    public class Combination<T>
    {
        readonly List<T> _sourceList;
        readonly ulong _startElem;
        readonly ulong _endElem;
        readonly int _choose;

        List<T> _caseIndex;

        public Combination(List<T> elems, int choose)
        {
            _choose = choose;
            _sourceList = elems;

            _startElem = (ulong)((1 << choose) - 1);
            _endElem = _startElem << (elems.Count - choose);
            _caseIndex = new List<T>(choose);
        }

        public IEnumerable<List<T>> Successor()
        {
            ulong start = _startElem;

            while (true)
            {
                int index = 0;

                for (int c = 0; c < _sourceList.Count; c++)
                {
                    ulong mask = (ulong)1 << c;
                    if ((start & mask) == mask)
                    {
                        _caseIndex[index++] = _sourceList[c];
                    }
                }

                yield return _caseIndex;

                if (start == _endElem)
                {
                    yield break;
                }

                start = snoob(start);
            }
        }

        ulong snoob(ulong x)
        {
            ulong smallest;
            ulong ripple;
            ulong ones;

            smallest = x & (ulong)-(long)x;
            ripple = x + smallest;
            ones = x ^ ripple;
            ones = (ones >> 2) / smallest;

            return ripple | ones;
        }


    }
}
