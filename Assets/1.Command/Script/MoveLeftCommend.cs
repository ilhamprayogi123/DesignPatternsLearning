using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComandPattern
{
    public class MoveLeftCommend : Command
    {
        private MoveObject moveObject;

        public MoveLeftCommend(MoveObject moveObject)
        {
            this.moveObject = moveObject;
        }

        public override void Execute()
        {
            moveObject.TurnLeft();
        }


        //Undo is just the opposite
        public override void Undo()
        {
            moveObject.TurnRight();
        }
    }
}


