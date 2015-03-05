using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jugs
{
    class Problem
    {

        int _ca;
        int _cb;
        int _n;

        public Problem(int ca, int cb, int n)
        {
            this._ca = ca;
            this._cb = cb;
            this._n = n;
        }

        public int CA { get { return _ca; } set { _ca = value; } }

        public int CB { get { return _cb; } set { _cb = value; } }

        public int N { get { return _n; } set { _n = value; } }

        public bool IsGoalState(State s)
        {
            return s.QB == _n;
        }


    }

}
