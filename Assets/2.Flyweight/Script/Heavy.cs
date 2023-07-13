using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flyweight
{
    public class Heavy
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

        public Heavy()
        {
            health = Random.Range(10f, 100f);

            data = new Data();
        }
    }
}


