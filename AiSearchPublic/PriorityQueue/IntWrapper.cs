using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriorityQueue
{
    class IntWrapper : IComparable, MinMaxElement<IntWrapper>
    {

        protected int _val;

        public IntWrapper()
        { 
        
        }

        public IntWrapper(int val)
        {
            this._val = val;
        }

        public int Value { get { return _val; } set { _val = value; } }

        IntWrapper MinMaxElement<IntWrapper>.MinElement()
        {
            return new IntWrapper(Int32.MinValue);
        }

        IntWrapper MinMaxElement<IntWrapper>.MaxElement()
        {
            return new IntWrapper(Int32.MaxValue);
        }

        public int CompareTo(Object obj)
        {
            IntWrapper other = (IntWrapper)obj;
            return this.Value.CompareTo(other.Value);
        }

        public override bool Equals(Object obj)
        {
            IntWrapper wrapperObj = obj as IntWrapper;
            if (wrapperObj == null)
                return false;
            else
                return _val == wrapperObj.Value;
        }

        public override int GetHashCode()
        {
            return this._val.GetHashCode();
        }
        
        public override string ToString()
        {
            return this.Value.ToString();
        }

    }
}
