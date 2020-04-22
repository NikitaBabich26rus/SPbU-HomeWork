using System;

namespace _2._4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var list = new UniqueList();
                list.Delete(1);
                Console.WriteLine(list.IsContain(5));
            }
            catch (AddContainingValueException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DeletingAnElementThatIsNotInTheListException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
