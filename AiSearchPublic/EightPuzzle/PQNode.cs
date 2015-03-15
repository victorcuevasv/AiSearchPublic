using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightPuzzleSearch
{

    class PQNode : Node, IComparable<PQNode>
    {

        public PQNode(State _state, Node _parent, EPAction _action, int _pathCost) :
            base(_state, _parent, _action, _pathCost)
        {
            
        }

        public int CompareTo(PQNode other)
        {
            int retVal = 0;
            if (this.PathCost > other.PathCost)
                retVal = 1;
            else if (this.PathCost < other.PathCost)
                retVal = -1;
            return retVal;
        }

    }

}
