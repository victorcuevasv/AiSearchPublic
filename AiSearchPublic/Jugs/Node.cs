using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Jugs
{

    public enum JugsAction
    {
        FillA,
        FillB,
        EmptyA,
        EmptyB,
        PourAB,
        PourBA,
        NumActions,
        NullAction
    }


    class Node
    {

        protected State _state;
        Node _parent;
        JugsAction _action;
        int _pathCost;


        public Node(State _state, Node _parent, JugsAction _action, int _pathCost)
        {
            this._state = _state;
            this._parent = _parent;
            this._action = _action;
            this._pathCost = _pathCost;
        }


        public State State { get { return _state; } set { _state = value; } }
        public Node Parent { get { return _parent; } set { _parent = value; } }
        public JugsAction Action { get { return _action; } set { _action = value; } }
        public int PathCost { get { return _pathCost; } set { _pathCost = value; } }

        public override bool Equals(Object obj)
        {
            Node nodeObj = obj as Node;
            if (nodeObj == null)
                return false;
            else
                return this.State.Equals(nodeObj.State);
        }

        public override int GetHashCode()
        {
            return this.State.GetHashCode();
        }

        public override string ToString()
        {
            return _state.ToString() + "  " + GetStrFromJugsAction(_action) + "  Path Cost: " + _pathCost;
        }

        protected string GetStrFromJugsAction(JugsAction action)
        {
            switch (action)
            {
                case JugsAction.FillA: return "fill A";
                case JugsAction.FillB: return "fill B";
                case JugsAction.EmptyA: return "empty A";
                case JugsAction.EmptyB: return "empty B";
                case JugsAction.PourAB: return "pour A B";
                case JugsAction.PourBA: return "pour B A";
                default: return "<UNKNOWN>";
            }
        }


    }


    class State
    {

        int _qa;
        int _qb;
        string _data;


        public State(int qa, int qb, string _data = "")
        {
            this._qa = qa;
            this._qb = qb;
            this._data = _data;
        }

        public int QA { get { return _qa; } set { _qa = value; } }

        public int QB { get { return _qb; } set { _qb = value; } }

        public string Data { get { return _data; } set { _data = value; } }

        public override bool Equals(Object obj)
        {
            State stateObj = obj as State;
            if (stateObj == null)
                return false;
            else
                return _qa == stateObj.QA && _qb == stateObj.QB;
        }


        public override string ToString()
        {
            return "(" + _qa.ToString() + "," + _qb.ToString() + ")";
        }


        //Explained in: https://msdn.microsoft.com/en-us/library/system.object.gethashcode(v=vs.110).aspx
        public override int GetHashCode()
        {
            return this._qa.GetHashCode() ^ this._qb.GetHashCode();
        }


    }


}


