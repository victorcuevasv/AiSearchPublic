using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PriorityQueue
{
    public class TestPriorityQueue
    {
        [Fact]
        public void InversePriorityQueueTest()
        {
            int n = 1000000;
            int coincidences = 0;
            PriorityQueue<IntWrapper> pq = new PriorityQueue<IntWrapper>();
            for (int i = n; i >= 0; i--)
                pq.Insert(new IntWrapper(i));
            for (int i = 0; i <= n; i++)
            {
                IntWrapper intw = pq.DeleteMin();
                if (intw.Value == i)
                    coincidences++;
            }
            Assert.Equal(coincidences, n+1);
        }

        [Fact]
        public void ShufflePriorityQueueTest()
        {
            int n = 1000000;
            int coincidences = 0;
            PriorityQueue<IntWrapper> pq = new PriorityQueue<IntWrapper>();
            List<IntWrapper> list = new List<IntWrapper>();
            //Create the list to shuffle
            for (int i = n; i >= 0; i--)
                list.Add(new IntWrapper(i));
            //Shuffle the list
            Random rand = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                int pos = rand.Next(0, list.Count);
                IntWrapper temp = list[i];
                list[i] = list[pos];
                list[pos] = temp;
            }
            //Insert elements of the shuffled list in the priority queue
            for (int i = 0; i < list.Count; i++)
                pq.Insert(list[i]);
            for (int i = 0; i <= n; i++)
            {
                IntWrapper intw = pq.DeleteMin();
                if (intw.Value == i)
                    coincidences++;
            }
            Assert.Equal(coincidences, n + 1);
        }

        [Fact]
        public void StraightPriorityQueueTest()
        {
            int n = 1000000;
            int coincidences = 0;
            PriorityQueue<IntWrapper> pq = new PriorityQueue<IntWrapper>();
            for (int i = 0; i <= n; i++)
                pq.Insert(new IntWrapper(i));
            for (int i = 0; i <= n; i++)
            {
                IntWrapper intw = pq.DeleteMin();
                if (intw.Value == i)
                    coincidences++;
            }
            Assert.Equal(coincidences, n + 1);
        }

        [Fact]
        public void ReplacePriorityQueueTest()
        {
            int n = 10000;
            int coincidences = 0;
            PriorityQueue<IntWrapperCost> pq = new PriorityQueue<IntWrapperCost>();
            List<IntWrapperCost> list = new List<IntWrapperCost>();
            for (int i = 0; i <= n; i++)
            {
                IntWrapperCost wrapper = new IntWrapperCost(i, i);
                pq.Insert(wrapper);
                list.Add(wrapper);
            }
            for (int i = 0; i <= n; i++)
            {
                IntWrapperCost oldWrapper = list[i];
                IntWrapperCost newWrapper = new IntWrapperCost(n+i+1, -(i+1));
                pq.ReplaceWithLower(oldWrapper, newWrapper);
            }
            for (int i = 0; i <= n; i++)
            {
                IntWrapperCost wrapper = pq.DeleteMin();
                if (wrapper.Cost == -(n+1)+i && wrapper.Value == (2*n+1-i))
                    coincidences++;
            }
            Assert.Equal(coincidences, n + 1);
        }

    }

}
