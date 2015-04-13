using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface MinMaxElement<T> where T : new()
{
    T MinElement();

    T MaxElement();
}

