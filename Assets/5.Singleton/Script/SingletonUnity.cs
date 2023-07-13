using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SingletonPattern
{
    public class SingletonUnity : MonoBehaviour
    {
        private static SingletonUnity instance = null;

        private float randomNumber;

        public static SingletonUnity Instance
        {
            get
            {
                if (instance == null)
                {
                    var instance = GameObject.FindObjectOfType<SingletonUnity>();

                    if (instance == null)
                    {
                        GameObject obj = new GameObject("Unity Singleton");
                        instance = obj.AddComponent<SingletonUnity>();

                        instance.FakeConstructor();

                        DontDestroyOnLoad(obj);
                    }
                }

                return instance;
            }
        }

        void Awake()
        {
            if (instance == null)
            {
                instance = this;

                instance.FakeConstructor();

                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void FakeConstructor()
        {
            randomNumber = Random.Range(0f, 1f);
        }

        public void TestSingleton()
        {
            Debug.Log($"Hello this is Singleton, my random number is: {randomNumber}");
        }
    }
}


