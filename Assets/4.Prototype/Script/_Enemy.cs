using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public abstract class _Enemy
    {
        //This method implements the Prototype design pattern
        public abstract _Enemy Clone();

        public abstract void Talk();
    }
}


