using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComandPattern
{
    public class MoveForwardCommend : Command
    {
        private MoveObject moveObject;

        public MoveForwardCommend(MoveObject moveObject)
        {
            this.moveObject = moveObject;
        }

        public override void Execute()
        {
            moveObject.MoveForward();
        }


        //Undo is just the opposite
        public override void Undo()
        {
            moveObject.MoveBack();
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


