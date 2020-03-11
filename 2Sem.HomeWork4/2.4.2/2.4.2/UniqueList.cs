using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._2
{
    class UniqueList : List
    {
        ListElement head { get; set; }

        public override void Add(int value)
        {
            if (IsContain(value))
            {
                throw new AddContainingValueException($"Error : {value} is contained in the list"); 
            }
            base.Add(value);
        }

        public override void Delete(int value)
        {
            if (!IsContain(value))
            {
                throw new DeletingAnElementThatIsNotInTheListException($"Error : {value} is not contained in the list");
            }
            base.Delete(value);
        }
    }
}
