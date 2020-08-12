using CitizenFX.Core;
using MenuAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atanims_cl.Menus
{
    class WalkStyleMenu
    {
        private static Menu walkStyleMenu = new Menu(GetConfig.Langs["WalkStyleMenuTitle"], GetConfig.Langs["WalkStyleMenuSubTitle"]);
        private static bool setupDone = false;

        private static void SetupMenu()
        {
            if (setupDone) return;
            setupDone = true;
            MenuController.AddMenu(walkStyleMenu);
            MenuController.EnableMenuToggleKeyOnController = false;
            MenuController.MenuToggleKey = (Control)0;


            walkStyleMenu.OnMenuOpen += (_menu) => {

            };

            walkStyleMenu.OnMenuClose += (_menu) =>
            {

            };
        }
        public static Menu GetMenu()
        {
            SetupMenu();
                return walkStyleMenu;
        }
    }
}
