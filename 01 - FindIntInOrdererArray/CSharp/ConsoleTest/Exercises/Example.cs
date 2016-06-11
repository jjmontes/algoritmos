using ConsoleTest.Core;

namespace ConsoleTest
{
    public class Example : IExercise
    {
        public int FindIntInOrdererArray(int[] vector, int number)
        {
            var pos = -1;
            var cont = 0;
            foreach (var item in vector)
            {
                if (item == number)
                {
                    pos = cont;
                    break;
                }
                cont++;
            }
            return pos;
        }
    }
}
