using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class MenuController : MonoBehaviour
    {
        public _MenuState[] allMenus;

        public enum MenuState
        {
            Game, Main, Settings, Help
        }

        private Dictionary<MenuState, _MenuState> menuDictionary = new Dictionary<MenuState, _MenuState>();

        private _MenuState activeState;

        private Stack<MenuState> stateHistory = new Stack<MenuState>();

        // Start is called before the first frame update
        void Start()
        {//Put all menus into a dictionary
            foreach (_MenuState menu in allMenus)
            {
                if (menu == null)
                {
                    continue;
                }

                //Inject a reference to this script into all menus
                menu.InitState(menuController: this);

                //Check if this key already exists, because it means we have forgotten to give a menu its unique key
                if (menuDictionary.ContainsKey(menu.state))
                {
                    Debug.LogWarning($"The key <b>{menu.state}</b> already exists in the menu dictionary!");

                    continue;
                }

                menuDictionary.Add(menu.state, menu);
            }

            //Deactivate all menus
            foreach (MenuState state in menuDictionary.Keys)
            {
                menuDictionary[state].gameObject.SetActive(false);
            }

            //Activate the default menu
            SetActiveState(MenuState.Game);
        }

        // Update is called once per frame
        void Update()
        {
            //Jump back one menu step when we press escape
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                activeState.JumpBack();
            }
        }

        //Jump back one step = what happens when we press escape or one of the back buttons
        public void JumpBack()
        {
            //If we have just one item in the stack then, it means we are at the state we set at start, so we have to jump forward
            if (stateHistory.Count <= 1)
            {
                SetActiveState(MenuState.Main);
            }
            else
            {
                //Remove one from the stack
                stateHistory.Pop();

                //Activate the menu that's on the top of the stack
                SetActiveState(stateHistory.Peek(), isJumpingBack: true);
            }
        }

        //Activate a menu
        public void SetActiveState(MenuState newState, bool isJumpingBack = false)
        {
            //First check if this menu exists
            if (!menuDictionary.ContainsKey(newState))
            {
                Debug.LogWarning($"The key <b>{newState}</b> doesn't exist so you can't activate the menu!");

                return;
            }

            //Deactivate the old state
            if (activeState != null)
            {
                activeState.gameObject.SetActive(false);
            }

            //Activate the new state
            activeState = menuDictionary[newState];

            activeState.gameObject.SetActive(true);

            //If we are jumping back we shouldn't add to history because then we will get doubles
            if (!isJumpingBack)
            {
                stateHistory.Push(newState);
            }
        }

        //Quit game
        public void QuitGame()
        {
            Debug.Log("You quit game!");

            Application.Quit();
        }
    }
}


