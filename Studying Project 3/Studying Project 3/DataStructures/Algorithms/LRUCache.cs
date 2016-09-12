using System.Collections.Generic;

namespace StudyingProject3.Algorithms
{
    public class LRUCache
    {
        private Dictionary<int, int> Dictionary { get; set; }

        private LinkedList<int> PriorityList { get; set; }

        private int Counter { get; set; }

        private int Capacity { get; set; }

        public LRUCache(int capacity)
        {
            Capacity = capacity;

            Dictionary = new Dictionary<int, int>(capacity);

            PriorityList = new LinkedList<int>();
        }

        public int Get(int key)
        {
            if (!Dictionary.ContainsKey(key))
            {
                return -1;
            }

            UpdatePriorityList(key);

            return Dictionary[key];
        }

        public void Set(int key, int value)
        {
            if (Dictionary.ContainsKey(key))
            {
                Dictionary[key] = value;
            }
            else
            {
                AddNewItem(key, value);
            }

            UpdatePriorityList(key);
        }

        private void AddNewItem(int key, int value)
        {
            Counter++;

            if (Counter > Capacity)
            {
                RemoveLeastUsedItem();
            }

            Dictionary.Add(key, value);
        }

        private void RemoveLeastUsedItem()
        {
            Dictionary.Remove(PriorityList.First.Value);

            PriorityList.RemoveFirst();

            Counter--;
        }

        private void UpdatePriorityList(int key)
        {
            PriorityList.Remove(key);

            PriorityList.AddLast(key);
        }
    }
}
