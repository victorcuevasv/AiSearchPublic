using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class IntWrapperCost : IntWrapper, MinMaxElement<IntWrapperCost>, IComparable
    {
        int _cost;

        public IntWrapperCost()
        { 
        
        }

        public IntWrapperCost(int val, int cost)
        {
            this._val = val;
            this._cost = cost;
        }

        public int Cost { get { return _cost; } set { _cost = value; } }

        IntWrapperCost MinMaxElement<IntWrapperCost>.MinElement()
        {
            return new IntWrapperCost(Int32.MinValue, Int32.MinValue);
        }

        IntWrapperCost MinMaxElement<IntWrapperCost>.MaxElement()
        {
            return new IntWrapperCost(Int32.MaxValue, Int32.MaxValue);
        }

        public int CompareTo(Object obj)
        {
            IntWrapperCost other = (IntWrapperCost)obj;
            return this.Cost.CompareTo(other.Cost);
        }

        public override string ToString()
        {
            return this.Value.ToString() + ":" + this.Cost.ToString();
        }

    }
}
