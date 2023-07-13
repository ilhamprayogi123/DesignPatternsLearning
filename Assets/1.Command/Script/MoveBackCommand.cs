using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComandPattern
{
    public class MoveBackCommand : Command
    {
        private MoveObject moveObject;

        public MoveBackCommand(MoveObject moveObject)
        {
            this.moveObject = moveObject;
        }

        public override void Execute()
        {
            moveObject.MoveBack();
        }


        //Undo is just the opposite
        public override void Undo()
        {
            moveObject.MoveForward();
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


