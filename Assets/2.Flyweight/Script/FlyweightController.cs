using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flyweight
{
    public class FlyweightController : MonoBehaviour
    {
        private List<Heavy> heavyObjects = new List<Heavy>();
        private List<Flyweight> flyweightObjects = new List<Flyweight>();

        // Start is called before the first frame update
        void Start()
        {
            int numberOfObjects = 1000000;

            for (int i = 0; i < numberOfObjects; i++)
            {
                Heavy newHeavy = new Heavy();

                heavyObjects.Add(newHeavy);
            }

            // Data data = new Data();
            /*
            for (int i = 0; i < numberOfObjects; i++)
            {
                Flyweight newFlyweight = new Flyweight(data);

                flyweightObjects.Add(newFlyweight);
            }
            */
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


