using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComandPattern
{
    public class GameController : MonoBehaviour
    {
        public MoveObject objectThatMoves;

        private Command buttonW;
        private Command buttonA;
        private Command buttonS;
        private Command buttonD;

        private Stack<Command> undoCommands = new Stack<Command>();
        private Stack<Command> redoCommands = new Stack<Command>();

        private bool isReplaying = false;

        private Vector3 startPos;

        private const float REPLAY_PAUSE_TIMER = 0.5f;

        // Start is called before the first frame update
        void Start()
        {
            buttonW = new MoveForwardCommend(objectThatMoves);
            buttonA = new MoveLeftCommend(objectThatMoves);
            buttonS = new MoveBackCommand(objectThatMoves);
            buttonD = new MoveRightCommand(objectThatMoves);

            startPos = objectThatMoves.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (isReplaying)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                ExecuteNewCommand(buttonW);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                ExecuteNewCommand(buttonA);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                ExecuteNewCommand(buttonS);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                ExecuteNewCommand(buttonD);
            }

            else if (Input.GetKeyDown(KeyCode.U))
            {
                if (undoCommands.Count == 0)
                {
                    Debug.Log("Can't undo because we are back where we started");
                }
                else
                {
                    Command lastCommand = undoCommands.Pop();

                    lastCommand.Undo();

                    //Add this to redo if we want to redo the undo
                    redoCommands.Push(lastCommand);
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (redoCommands.Count == 0)
                {
                    Debug.Log("Can't redo because we are at the end");
                }
                else
                {
                    Command nextCommand = redoCommands.Pop();

                    nextCommand.Execute();

                    //Add to undo if we want to undo the redo
                    undoCommands.Push(nextCommand);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //ref is important or the keys will not be swapped
                SwapKeys(ref buttonA, ref buttonD);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine(Replay());

                isReplaying = true;
            }
        }

        private IEnumerator Replay()
        {
            //Move the object back to where it started
            objectThatMoves.transform.position = startPos;

            //Pause so we can see that it has started at the start position
            yield return new WaitForSeconds(REPLAY_PAUSE_TIMER);

            //Convert the undo stack to an array
            Command[] oldCommands = undoCommands.ToArray();

            //This array is inverted so we iterate from the back
            for (int i = oldCommands.Length - 1; i >= 0; i--)
            {
                Command currentCommand = oldCommands[i];

                currentCommand.Execute();

                yield return new WaitForSeconds(REPLAY_PAUSE_TIMER);
            }

            isReplaying = false;
        }

        private void ExecuteNewCommand(Command commandButton)
        {
            commandButton.Execute();

            //Add the new command to the last position in the list
            undoCommands.Push(commandButton);

            //Remove all redo commands because redo is not defined when we have add a new command
            redoCommands.Clear();
        }

        private void SwapKeys(ref Command key1, ref Command key2)
        {
            Command temp = key1;

            key1 = key2;

            key2 = temp;
        }
    }
}


