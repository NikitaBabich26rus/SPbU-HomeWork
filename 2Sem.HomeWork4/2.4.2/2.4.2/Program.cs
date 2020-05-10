using System;

namespace _2._4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var list = new List();
                list.Add(1, 1);
                list.SetElementOnPosition(2, 3);
            }
            catch (AddContainingValueException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DeletingAnElementThatIsNotInTheListException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidPositionException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
