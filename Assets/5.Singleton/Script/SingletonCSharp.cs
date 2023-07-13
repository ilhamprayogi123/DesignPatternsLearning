using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SingletonPattern
{
    public class SingletonCSharp
    {
        private static SingletonCSharp instance = null;

        private float randomNumber;

        public static SingletonCSharp Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new SingletonCSharp();
                }

                return instance;
            }
        }

        private SingletonCSharp()
        {
            randomNumber = Random.Range(0f, 1f);
        }

        public void TestSingleton()
        {
            Debug.Log($"Hello this is Singleton, my random number is: {randomNumber}");
        }
    }
}


