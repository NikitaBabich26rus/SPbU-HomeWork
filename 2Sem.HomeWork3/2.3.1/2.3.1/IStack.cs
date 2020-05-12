using System;
using System.Collections.Generic;
using System.Text;

namespace _2._3._1
{
    public interface IStack
    {
        void Push(int value);

        (int, bool) Pop();

        bool IsEmpty();

        void Clear();
    }
}