using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class Spawner
    {
        private _Enemy prototype;

        public Spawner(_Enemy prototype)
        {
            this.prototype = prototype;
        }

        public _Enemy SpawnMonster()
        {
            return prototype.Clone();
        }
    }
}


