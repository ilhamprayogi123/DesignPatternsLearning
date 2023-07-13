using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class HelpMenu : _MenuState
    {
        //Specific for this state
        public override void InitState(MenuController menuController)
        {
            base.InitState(menuController);

            state = MenuController.MenuState.Help;
        }
    }
}


