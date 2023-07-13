using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SingletonPattern
{
    public class GameController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            TestCSharpSingleton();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void TestCSharpSingleton()
        {
            SingletonCSharp instance = SingletonCSharp.Instance;

            instance.TestSingleton();

            SingletonCSharp instance2 = SingletonCSharp.Instance;

            instance2.TestSingleton();
        }

        private void TestUnitySingleton()
        {
            SingletonUnity instance = SingletonUnity.Instance;

            instance.TestSingleton();

            SingletonUnity instance2 = SingletonUnity.Instance;

            instance2.TestSingleton();
        }
    }
}


