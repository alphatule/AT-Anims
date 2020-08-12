using CitizenFX.Core;
using MenuAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atanims_cl.Menus
{
    class AnimationsMenu
    {
        private static Menu animationsMenu = new Menu(GetConfig.Langs["AnimationsMenuTitle"], GetConfig.Langs["AnimationsMenuSubTitle"]);
        private static bool setupDone = false;

        private static void SetupMenu()
        {
            if (setupDone) return;
            setupDone = true;
            MenuController.AddMenu(animationsMenu);
            MenuController.EnableMenuToggleKeyOnController = false;
            MenuController.MenuToggleKey = (Control)0;


            animationsMenu.OnMenuOpen += (_menu) => {

            };

            animationsMenu.OnMenuClose += (_menu) =>
            {

            };
        }
        public static Menu GetMenu()
        {
            SetupMenu();
            return animationsMenu;
        }
    }
}
