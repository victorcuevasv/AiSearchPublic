using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using EightPuzzleSearch;

namespace AiSearchPublic
{
    public class EightPuzzleTests
    {

        [Fact]
        public void StateEqualityTest()
        {
            State state1 = new State("0123456789");
            State state2 = new State("0123456789");
            Assert.Equal(state1, state2);
        }


        [Fact]
        public void NodeEqualityTest()
        {
            Node node1 = new Node(new State("0123456789"), null, EPAction.MoveDown, 3);
            Node node2 = new Node(new State("0123456789"), null, EPAction.MoveUp, 5);
            Assert.Equal(node1, node2);
        }

        [Fact]
        public void StateSetMembershipTest()
        {
            State state1 = new State("0123456789");
            State state2 = new State("0123456789");
            HashSet<State> set = new HashSet<State>();
            set.Add(state1);
            Assert.True(set.Contains(state2));
        }


        [Fact]
        public void NodeMembershipTest()
        {
            Node node1 = new Node(new State("0123456789"), null, EPAction.MoveDown, 3);
            Node node2 = new Node(new State("0123456789"), null, EPAction.MoveUp, 5);
            HashSet<Node> set = new HashSet<Node>();
            set.Add(node1);
            Assert.True(set.Contains(node2));
        }

        [Fact]
        public void NodeQueueTest()
        {
            Node node1 = new Node(new State("0123456789"), null, EPAction.MoveDown, 3);
            Node node2 = new Node(new State("9876543210"), null, EPAction.MoveUp, 5);
            Assert.NotEqual(node1, node2);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node1);
            queue.Enqueue(node2);
            Node retrieved = queue.Dequeue();
            Assert.Equal(retrieved, node1);
        }

        [Fact]
        public void NodeStackTest()
        {
            Node node1 = new Node(new State("0123456789"), null, EPAction.MoveDown, 3);
            Node node2 = new Node(new State("9876543210"), null, EPAction.MoveUp, 4);
            Assert.NotEqual(node1, node2);
            Stack<Node> stack = new Stack<Node>();
            stack.Push(node1);
            stack.Push(node2);
            Node retrieved = stack.Pop();
            Assert.Equal(retrieved, node2);
        }


    }


}
