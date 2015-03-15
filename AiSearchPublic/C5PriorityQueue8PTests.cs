using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using EightPuzzleSearch;
using C5;

namespace AiSearchPublic
{
    public class C5PriorityQueue8PTests
    {

        [Fact]
        public void SimplePriorityQueueTest()
        {
            //Create three nodes with different path costs and add them to the
            //priority queue. They should be retrieved in an order congruent to
            //their path costs.
            int v1 = 8;
            State state1 = new State("0729465183");
            PQNode node1 = new PQNode(state1, null, EPAction.MoveDown, v1);
            int v2 = 3;
            State state2 = new State("0846253719");
            PQNode node2 = new PQNode(state2, null, EPAction.MoveLeft, v2);
            int v3 = 7;
            State state3 = new State("0174358269");
            PQNode node3 = new PQNode(state3, null, EPAction.MoveLeft, v3);
            IntervalHeap<PQNode> pq = new IntervalHeap<PQNode>();
            pq.Add(node1);
            pq.Add(node2);
            pq.Add(node3);
            PQNode t = pq.DeleteMin();
            Assert.Equal(t.PathCost, v2);
            t = pq.DeleteMin();
            Assert.Equal(t.PathCost, v3);
            t = pq.DeleteMin();
            Assert.Equal(t.PathCost, v1);
        }

        [Fact]
        public void EmptyPriorityQueueTest()
        {
            //Create a new priority queue with just one node and check that it is
            //empty. Add a single node and check that it is not empty. Remove the node
            //and check that the queue is then empty.
            int v1 = 8;
            State state1 = new State("0729465183");
            PQNode node1 = new PQNode(state1, null, EPAction.MoveDown, v1);
            IntervalHeap<PQNode> pq = new IntervalHeap<PQNode>();
            Assert.Equal(pq.Count, 0);
            pq.Add(node1);
            Assert.NotEqual(pq.Count, 0);
            PQNode t = pq.DeleteMin();
            Assert.Equal(pq.Count, 0);
        }

        [Fact]
        public void PriorityQueueSimpleFindTest()
        {
            //Create a priority queue with just one node using a handle.
            //Then find the node through the handle. Compare the retrieved
            //node with a new second node.
            int v1 = 8;
            State state1 = new State("0729465183");
            PQNode node1 = new PQNode(state1, null, EPAction.MoveDown, v1);
            IntervalHeap<PQNode> pq = new IntervalHeap<PQNode>();
            IPriorityQueueHandle<PQNode> h = null;
            pq.Add(ref h, node1);
            PQNode outVal;
            bool retVal = pq.Find(h, out outVal);
            Assert.Equal(outVal, node1);
            Assert.True(retVal);
            int v2 = 3;
            State state2 = new State("0846253719");
            PQNode node2 = new PQNode(state2, null, EPAction.MoveLeft, v2);
            Assert.NotEqual(outVal, node2);
        }

        [Fact]
        public void PriorityQueueFindTest()
        {
            //Create a priority queue with two new nodes using handles. 
            //Store the handles in a dictionary. Find both nodes using 
            //their handles, then try to find a node that was not added
            //to the priority queue. Then find a new node that has the 
            //same state as the first added node.
            int v1 = 8;
            State state1 = new State("0729465183");
            PQNode node1 = new PQNode(state1, null, EPAction.MoveDown, v1);
            int v2 = 3;
            State state2 = new State("0846253719");
            PQNode node2 = new PQNode(state2, null, EPAction.MoveLeft, v2);
            IntervalHeap<PQNode> pq = new IntervalHeap<PQNode>();
            HashDictionary<PQNode, IPriorityQueueHandle<PQNode>> handles =
                new HashDictionary<PQNode, IPriorityQueueHandle<PQNode>>();
            AddPQNode(node1, pq, handles);
            AddPQNode(node2, pq, handles);
            IPriorityQueueHandle<PQNode> h = null;
            bool retVal = handles.Find(ref node1, out h);
            PQNode outVal;
            retVal = pq.Find(h, out outVal);
            Assert.Equal(outVal, node1);
            Assert.True(retVal);
            retVal = handles.Find(ref node2, out h);
            retVal = pq.Find(h, out outVal);
            Assert.Equal(outVal, node2);
            Assert.True(retVal);
            int v3 = 7;
            State state3 = new State("0174358269");
            PQNode node3 = new PQNode(state3, null, EPAction.MoveLeft, v3);
            retVal = handles.Find(ref node3, out h);
            retVal = pq.Find(h, out outVal);
            Assert.NotEqual(outVal, node3);
            Assert.False(retVal);
            int v4 = 5;
            State state4 = new State("0729465183");
            PQNode node4 = new PQNode(state4, null, EPAction.MoveRight, v4);
            retVal = handles.Find(ref node4, out h);
            retVal = pq.Find(h, out outVal);
            Assert.Equal(outVal, node4);
            Assert.True(retVal);
        }

        [Fact]
        public void PriorityQueueReplaceTest()
        {
            //Create a priority queue with just one node using a handle.
            //Then find the node through the handle. Create a new node with
            //the same state but a lower cost and replace the stored node.
            //Then find the new stored node and compare it in equality with
            //the newly created node, but also compare equality for the costs,
            //thus verifying that the node was actually replaced by one with
            //the same state but a lower cost.
            int v1 = 8;
            State state1 = new State("0729465183");
            PQNode node1 = new PQNode(state1, null, EPAction.MoveDown, v1);
            IntervalHeap<PQNode> pq = new IntervalHeap<PQNode>();
            IPriorityQueueHandle<PQNode> h = null;
            pq.Add(ref h, node1);
            PQNode outVal;
            bool retVal = pq.Find(h, out outVal);
            Assert.Equal(outVal, node1);
            Assert.True(retVal);
            int v2 = 5;
            State state2 = new State("0729465183");
            PQNode node2 = new PQNode(state2, null, EPAction.MoveUp, v2);
            pq.Replace(h, node2);
            retVal = pq.Find(h, out outVal);
            Assert.Equal(outVal, node2);
            Assert.True(retVal);
            Assert.Equal(outVal.PathCost, node2.PathCost);
        }

        //This method enables to add a node to a priority queue using a handle,
        //the handle is added to a dictionary. It is necessary to define a method
        //since a handle variable cannot be reused.
        private void AddPQNode(PQNode node, IntervalHeap<PQNode> pq,
            HashDictionary<PQNode, IPriorityQueueHandle<PQNode>> handles)
        {
            IPriorityQueueHandle<PQNode> h = null;
            pq.Add(ref h, node);
            handles.Add(node, h);
        }

    }

}
