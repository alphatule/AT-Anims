using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using MenuAPI;

namespace atanims_cl.Menus
{
    class EmotesMenu
    {
        private static Menu EmotesMenuInstance = new Menu(GetConfig.Langs["EmotesMenuTitle"], GetConfig.Langs["EmotesMenuSubTitle"]);
        private static bool setupDone = false;
        private static void SetupMenu()
        {
            if (setupDone) return;
            setupDone = true;
            MenuController.AddMenu(EmotesMenuInstance);
            MenuController.EnableMenuToggleKeyOnController = false; 
            MenuController.MenuToggleKey = (Control)0;


            EmotesMenuInstance.OnMenuOpen += (_menu) => {
                
            };

            EmotesMenuInstance.OnMenuClose += (_menu) =>
            {

            };
        }
        public static Menu GetMenu()
        {
            SetupMenu();
            return EmotesMenuInstance;
        }

    }
}
