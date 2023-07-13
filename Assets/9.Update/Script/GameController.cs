using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatePart
{
    public class GameController : MonoBehaviour
    {
        //The list with all objects with a custom update method
        //Is static to make it easier to illustrate the example, but you could maybe use the Observer pattern to register methods
        private static List<IUpdateable> updateableObjects = new List<IUpdateable>();

        private bool isPaused = false;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Run all custom update methods
            if (!isPaused && updateableObjects != null)
            {
                float dt = Time.deltaTime;

                //Iterate through all objects backwards in case one object decides to destroy itself
                for (int i = updateableObjects.Count - 1; i >= 0; i--)
                {
                    IUpdateable updateableObj = updateableObjects[i];

                    updateableObj.OnUpdate(dt);
                }
            }

            //Pause-unpause
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isPaused = !isPaused;
            }
        }

        //Register new object
        public static void RegisterUpdateableObject(IUpdateable obj)
        {
            if (!updateableObjects.Contains(obj))
            {
                updateableObjects.Add(obj);
            }
            else
            {
                MonoBehaviour mb = (MonoBehaviour)obj;

                Debug.Log($"{mb.gameObject.name} has already been registered");
            }
        }

        //Unregister
        public static void UnregisterUpdateableObject(IUpdateable obj)
        {
            if (updateableObjects.Contains(obj))
            {
                updateableObjects.Remove(obj);
            }
        }
    }
}


