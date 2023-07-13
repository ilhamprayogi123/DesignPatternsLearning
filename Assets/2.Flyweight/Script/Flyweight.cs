using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flyweight
{
    public class Flyweight
    {
        private float health;
        private Data data;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public Flyweight(Data data)
        {
            health = Random.Range(10f, 100f);

            this.data = data;
        }
    }
}


