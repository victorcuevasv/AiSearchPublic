using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EightPuzzleSearch
{

    class DLSNode : Node
    {

        public DLSNode(State _state, Node _parent, EPAction _action, int _pathCost) :
            base(_state, _parent, _action, _pathCost)
        {
            
        }

        public bool IsCutoff()
        {
            return _state.Data == "CUTOFF";
        }

        public bool IsFailure()
        {
            return _state.Data == "FAILURE";
        }


    }


}
