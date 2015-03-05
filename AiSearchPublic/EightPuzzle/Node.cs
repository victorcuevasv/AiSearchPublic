using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EightPuzzleSearch
{

    public enum EPAction
    { 
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight,
        NumMoves,
        NullAction
    }


    class Node
    {

        protected State _state;
        Node _parent;
        EPAction _action;
        int _pathCost;


        public Node(State _state, Node _parent, EPAction _action, int _pathCost)
        {
            this._state = _state;
            this._parent = _parent;
            this._action = _action;
            this._pathCost = _pathCost;
        }


        public State State { get { return _state; } set { _state = value; } }
        public Node Parent { get { return _parent; } set { _parent = value; } }
        public EPAction Action { get { return _action; } set { _action = value; } }
        public int PathCost { get { return _pathCost; } set { _pathCost = value; } }

        public override bool Equals(Object obj)
        {
            Node nodeObj = obj as Node;
            if (nodeObj == null)
                return false;
            else
                return State.Data == nodeObj.State.Data;
        }

        public override int GetHashCode()
        {
            return this.State.GetHashCode();
        }

        public override string ToString()
        {
            return _state.Data + " " + GetStrFromEPAction(_action) + " Path Cost: " + _pathCost;
        }

        protected string GetStrFromEPAction(EPAction action)
        {
            switch (action)
            {
                case EPAction.MoveUp: return "MOVE UP";
                case EPAction.MoveDown: return "MOVE DOWN";
                case EPAction.MoveLeft: return "MOVE LEFT";
                case EPAction.MoveRight: return "MOVE RIGHT";
                default: return "<UNKNOWN>";
            }
        }


    }


    class State
    {

        string _data;


        public State(string _data)
        {
            this._data = _data;
        }

        public string Data { get { return _data; } set { _data = value; } }

        public override bool Equals(Object obj)
        {
            State stateObj = obj as State;
            if (stateObj == null)
                return false;
            else
                return _data == stateObj.Data;
        }

        public override int GetHashCode()
        {
            return this._data.GetHashCode();
        }


    }


}
