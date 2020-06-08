using System;

namespace ListReview
{
    class Program
    {
        static MyList<int> BubbleSort(MyList<int> numbersToSort)
        {
            int tempHolder;
            int numberOfSwitches;

            for (int i = 0; i < numbersToSort.Size - 1; i ++)
            {
                numberOfSwitches = numbersToSort.Size;
                for (int x = 0; x < numbersToSort.Size - 1; x++)
                {
                    if (numbersToSort.FindIndex(x) > numbersToSort.FindIndex(x + 1))
                    {
                        tempHolder = numbersToSort.FindIndex(x);
                        numbersToSort.ChangeValue(x, numbersToSort.FindIndex(x + 1));
                        numbersToSort.ChangeValue(x + 1, tempHolder);
                    }
                    else
                    {
                        numberOfSwitches--;
                    }
                }

                if (numberOfSwitches == 0)
                {
                    return numbersToSort;
                }
            }
    
            return numbersToSort;
        }

        static void Main(string[] args)
        {
            MyList<int> numbers = new MyList<int>();
            Random random = new Random();

            for(int i = 0; i < 10; i ++)
            {
                numbers.Add(random.Next(0, 30));
                Console.WriteLine($"{numbers.FindIndex(i)}");
            }
            Console.WriteLine();
            numbers = BubbleSort(numbers);
            for(int i = 0; i < 10; i ++)
            {
                Console.WriteLine($"{numbers.FindIndex(i)}");
            }
        }
    }
}
