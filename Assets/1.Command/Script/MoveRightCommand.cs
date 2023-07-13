using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComandPattern
{
    public class MoveRightCommand : Command
    {
        private MoveObject moveObject;

        public MoveRightCommand(MoveObject moveObject)
        {
            this.moveObject = moveObject;  
        }

        public override void Execute()
        {
            moveObject.TurnRight();
        }


        //Undo is just the opposite
        public override void Undo()
        {
            moveObject.TurnLeft();
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


