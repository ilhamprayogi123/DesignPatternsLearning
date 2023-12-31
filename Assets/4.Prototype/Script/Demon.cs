using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class Demon : _Enemy
    {
        private int health;
        private int speed;

        private static int demonCounter = 0;

        public Demon(int health, int speed)
        {
            this.health = health;
            this.speed = speed;

            demonCounter += 1;
        }

        public override _Enemy Clone()
        {
            return new Demon(health, speed);
        }

        public override void Talk()
        {
            Debug.Log($"Hello this is Demon number {demonCounter}. My health is {health} and my speed is {speed}");
        }
    }
}


