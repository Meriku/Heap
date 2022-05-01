using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class Heap <T> : IEnumerable                     
           where T : IComparable<T>
    {

        private List<T> items = new List<T>();
        public int Count => items.Count;

        /// <summary>
        /// Get the biggest item (root) 
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (Count > 0)
            {
                return items[0];
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Add new item and sort the binary heap.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            items.Add(item);

            var currentIndex = Count - 1;
            var parrentIndex = GetParentIndex(currentIndex);

            while (items[currentIndex].CompareTo(items[parrentIndex]) >= 0)
            {         
                Swap(currentIndex, parrentIndex);
                            
                currentIndex = parrentIndex;
               
                if (currentIndex == 0)
                {
                    break;
                }

                parrentIndex = GetParentIndex(currentIndex);
            }
        }

        /// <summary>
        /// Add range of items. Sort all structure.
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(List<T> items)
        {
            items.AddRange(items);

            for (int i = Count; i >= 0; i--)
            {
                Sort(i);
            }
        }

        /// <summary>
        /// Get the biggest item (root) and delete it from the structure.
        /// </summary>
        /// <returns></returns>
        public T GetMax()
        {
            var result = items[0];

            items[0] = items[Count - 1];    // Перенесли последний элемент в голову
            items.RemoveAt(Count - 1);      // Удалили последний элемент

            Sort(0);

            return result;
        }

        /// <summary>
        /// Sort the structure.
        /// </summary>
        /// <param name="currentIndex"></param>
        private void Sort(int currentIndex)
        {
            int maxIndex;
            int leftIndex;
            int rightIndex;

            while (currentIndex < Count)
            {
                leftIndex = 2 * currentIndex + 1;
                rightIndex = 2 * currentIndex + 2;

                maxIndex = FindMax(currentIndex, leftIndex, rightIndex);

                if (maxIndex == currentIndex)
                {
                    break;
                }

                Swap(currentIndex, maxIndex);

                currentIndex = maxIndex;           
            }
        }


        private int FindMax(int index1, int index2, int index3)
        {
            T item1 = index1 < Count ? items[index1] : default(T);
            T item2 = index2 < Count ? items[index2] : default(T);
            T item3 = index3 < Count ? items[index3] : default(T);

            if (!item1.Equals(default(T)) && item1.CompareTo(item2) >= 0 && item1.CompareTo(item3) >= 0)
            {
                return index1;
            }
            
            if (!item2.Equals(default(T)) && item2.CompareTo(item1) >= 0 && item2.CompareTo(item3) >= 0)
            {
                return index2;
            }

            if (!item3.Equals(default(T)) && item3.CompareTo(item1) >= 0 && item3.CompareTo(item2) >= 0)
            {
                return index3;
            }

            return index1; // Если элементы равны
        }




        private void Swap(int currentIndex, int parrentIndex)
        {
            var temp = items[currentIndex];

            items[currentIndex] = items[parrentIndex];
            items[parrentIndex] = temp;
        }

        private int GetParentIndex(int index)
        {
            return ((index - 1) / 2);
        }

        public IEnumerator GetEnumerator()
        {
            while (Count > 0)
            {
                yield return GetMax();
            }
        }
    }
}
