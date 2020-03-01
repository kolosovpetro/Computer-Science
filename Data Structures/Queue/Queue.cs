using Queue.Auxiliaries;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    class Queue<T> : IQueue<T>, IEnumerable<T>
    {
        public int Size { get; private set; }
        public List<T> QueueBase { get; private set; }
        public Queue(int newSize)
        {
            Size = newSize;
            QueueBase = new List<T>();
        }
        public bool IsEmpty()
        {
            if (QueueBase == null)
                return true;
            return false;
        }
        public bool IsFull()
        {
            if (this.QueueBase.Count >= Size)
                return true;
            return false;
        }
        public T Peek()
        {
            try
            {
                int Last = QueueBase.Count - 1;
                return QueueBase[Last];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
        public void Enqueue(T Data)
        {
            if (IsFull()) Dequeue();

            if (IsEmpty()) QueueBase.Add(Data);

            if (!IsFull() && !IsEmpty())
            {
                int t = 1;
                int Last = QueueBase.Count;
                QueueBase.Add(Data);

                while (true)
                {
                    try
                    {
                        Swap<T>.GenericSwap(QueueBase, Last - t - 1, Last - t);
                        t++;
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }

        }
        public void Dequeue()
        {
            try
            {
                int Last = QueueBase.Count - 1;
                QueueBase.RemoveAt(Last);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return QueueBase.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                return QueueBase[index];
            }
        }
    }
}
