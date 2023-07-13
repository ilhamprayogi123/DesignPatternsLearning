using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class Ghost : _Enemy
    {
        private int health;
        private int speed;

        private static int ghostCounter = 0;

        public Ghost(int health, int speed)
        {
            this.health = health;
            this.speed = speed;

            ghostCounter += 1;
        }

        public override _Enemy Clone()
        {
            return new Ghost(health, speed);
        }

        public override void Talk()
        {
            Debug.Log($"Hello this is Ghost number {ghostCounter}. My health is {health} and my speed is {speed}");
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


