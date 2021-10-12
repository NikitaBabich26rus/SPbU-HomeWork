using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2._3
{
    interface IStack
    {
        void Push(int value);

        int Pop();

        bool IsEmpty();
    }
}
