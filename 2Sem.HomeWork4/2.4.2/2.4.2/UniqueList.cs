using System.Threading.Tasks;

namespace _2._4._2
{
    /// <summary>
    /// List class without duplicate elements. 
    /// </summary>
    public class UniqueList : List
    {
        /// <summary>
        /// Add element, element is not contained in UniqueList.
        /// </summary>
        /// <param name="value">Element`s position</param>
        /// <param name="position">Element`s position</param>
        public override void Add(int value, int position)
        {
            if (IsContain(value))
            {
                if (GetPositionByElementsValue(value) == position)
                {
                    return;
                }
                throw new AddContainingValueException($"Error : {value} is contained in the list"); 
            }
            base.Add(value, position);
        }

        /// <summary>
        /// Set element on position, element is not contained in UniqueList.
        /// </summary>
        /// <param name="value">Element`s value</param>
        /// <param name="position">Element`s position</param>
        public override void SetElementOnPosition(int value, int position)
        {
            if (IsContain(value))
            {
                throw new AddContainingValueException($"Error : {value} is contained in the list");
            }
            base.SetElementOnPosition(value, position);
        }
    }
}
