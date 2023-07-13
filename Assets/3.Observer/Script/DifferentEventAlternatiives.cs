using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Observer
{
    public class DifferentEventAlternatiives : MonoBehaviour
    {
        public event EventHandler myCoolEvent;

        public event EventHandler<MyName> myCoolEventWithParameters;

        public event Action<MyName, MyAge> myCoolEventAction;

        public UnityEvent coolUnityEvent = new UnityEvent();

        public MyCustomUnityEvent coolCustomUnityEvent = new MyCustomUnityEvent();

        public delegate void MyEventHandler(object sender, EventArgs e);
        public delegate void MyEventHandlerEmpty();
        public event MyEventHandlerEmpty MyCoolCustomEvent;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //What the event will trigger
        private void DisplayStuff(object sender, EventArgs args)
        {
            Debug.Log("Hello this is DisplayStuff");
        }

        private void DisplayStuffCustomArgs(object sender, MyName args)
        {
            Debug.Log($"Hello my name is {args.name}");
        }

        private void DisplayStuffCustomParameters(MyName myName, MyAge myAge)
        {
            Debug.Log($"Hello my name is {myName.name} and my age is {myAge.age}");
        }

        private void DisplayStuffEmpty()
        {
            Debug.Log("Hello this is empty");
        }
    }

    public class MyName : EventArgs
    {
        public string name;

        public MyName(string name)
        {
            this.name = name;
        }
    }

    public class MyAge
    {
        public int age;

        public MyAge(int age)
        {
            this.age = age;
        }
    }

    //To make parameters work with UnityEvents
    public class MyCustomUnityEvent : UnityEvent<MyName, MyAge>
    {
        //Should be empty
    }
}


