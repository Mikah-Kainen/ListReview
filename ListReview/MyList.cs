using System;
using System.Collections.Generic;
using System.Text;

namespace ListReview
{
    public class MyList<T>
    {

        private const int initialCapacity = 10;
        private T[] List = new T[initialCapacity];
        public int Size = 0;

        public void Add(T thingToAdd)
        {
            List[Size] = thingToAdd;
            Size++;
            InsureCapacity();
        }

        private void InsureCapacity()
        {
            int listCapacity = List.Length;
            if (Size < listCapacity)
            {
                return;
            }
            
            T[] tempList = new T[Size * 2];
            for(int i = 0; i < Size; i ++)
            {
                tempList[i] = List[i];
            }
            List = tempList;
        }

        public T FindIndex(int targetIndex)
        {
            return List[targetIndex];
        }

        public void ChangeValue(int indexToChange, T newValue)
        {
            List[indexToChange] = newValue;
        }

        public void Sub(T targetValue)
        {
            int targetIndex = FindValue(targetValue);
            for(int i = targetIndex; i < Size; i ++)
            {
                List[i] = List[i + 1];
            }
        }

        private int FindValue(T targetValue)
        {
            for(int i = 0; i < Size; i ++)
            {
                if(List[i].Equals(targetValue))
                {
                    return i;
                }
            }
            throw new IndexOutOfRangeException("that number wasn't found");
        }
    }
}
