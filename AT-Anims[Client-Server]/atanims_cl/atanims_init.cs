using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atanims_cl
{
    class atanims_init : BaseScript
    {
        public static uint KeyToOpen = 0;

        public atanims_init()
        {
            Tick += OpenMenu;
        }

        public static async Task OpenMenu()
        {
            if (API.IsControlJustPressed(0, KeyToOpen))
            {
                Menus.MainMenu.GetMenu().OpenMenu();
            }
        }
    }
}
