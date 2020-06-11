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

        static int[] MergeSort(int[] numbers)
        {
            if(numbers.Length < 2)
            {
                return numbers;
            }

            int splitSize = numbers.Length / 2;
            int[] leftArray = new int[splitSize];
            int[] rightArray = new int[splitSize + (numbers.Length%2)];
            for(int i = 0; i < splitSize; i ++)
            {
                leftArray[i] = numbers[i];
            }
            for(int i = splitSize; i < numbers.Length; i ++)
            {
                rightArray[i - splitSize] = numbers[i];
            }
            return Merge(MergeSort(leftArray), MergeSort(rightArray));
        }

        static int[] Merge(int[] numbers1, int[] numbers2)
        {
            if(numbers1.Length == 0 || numbers2.Length == 0)
            {
                throw new Exception("numbers array is empty");
            }
            int[] mergedNumbers = new int[numbers1.Length + numbers2.Length];
            int numbers1Count = 0;
            int numbers2Count = 0;
            for(int i = 0; i < mergedNumbers.Length; i ++)
            {
                if(numbers1Count > numbers1.Length - 1)
                {
                    mergedNumbers[i] = numbers2[numbers2Count];
                    numbers2Count++;
                }
                else if(numbers2Count > numbers2.Length - 1)
                {
                    mergedNumbers[i] = numbers1[numbers1Count];
                    numbers1Count++;
                }
                else if(numbers2[numbers2Count] <= numbers1[numbers1Count])
                {
                    mergedNumbers[i] = numbers2[numbers2Count];
                    numbers2Count++;
                }
                else
                {
                    mergedNumbers[i] = numbers1[numbers1Count];
                    numbers1Count++;
                }
            }
            return mergedNumbers;
        }

        static void Main(string[] args)
        {
            int[] numbers = new int[10];
            Random random = new Random();

            for(int i = 0; i < 10; i ++)
            {
                numbers[i] = random.Next(0, 30);
                Console.WriteLine($"{numbers[i]}");
            }
            Console.WriteLine();
            numbers = MergeSort(numbers);
            for(int i = 0; i < 10; i ++)
            {
                Console.WriteLine($"{numbers[i]}");
            }
        }
    }
}
