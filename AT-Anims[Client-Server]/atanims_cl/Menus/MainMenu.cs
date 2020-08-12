using CitizenFX.Core;
using MenuAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atanims_cl.Menus
{
    class MainMenu
    {
        private static Menu mainMenu = new Menu(GetConfig.Langs["MainMenuTitle"], GetConfig.Langs["MainMenuSubTitle"]);
        private static bool setupDone = false;
        private static void SetupMenu()
        {
            if (setupDone) return;
            setupDone = true;
            MenuController.AddMenu(mainMenu);

            string keyPress = GetConfig.Config["KeyToOpenMenu"].ToString();
            int KeyInt = Convert.ToInt32(keyPress, 16);

            MenuController.EnableMenuToggleKeyOnController = false;
            MenuController.MenuToggleKey = (Control)KeyInt;



            // WalkStyleMenu
            MenuController.AddSubmenu(mainMenu, WalkStyleMenu.GetMenu());

            MenuItem subWalkStyleMenu = new MenuItem(GetConfig.Langs["WalkStyleMenuTitle"], GetConfig.Langs["WalkStyleMenuSubTitle"])
            {
                RightIcon = MenuItem.Icon.ARROW_RIGHT
            };

            mainMenu.AddMenuItem(subWalkStyleMenu);
            MenuController.BindMenuItem(mainMenu, WalkStyleMenu.GetMenu(), subWalkStyleMenu);




            // AnimationsMenu
            MenuController.AddSubmenu(mainMenu, AnimationsMenu.GetMenu());

            MenuItem subAnimationsMenu = new MenuItem(GetConfig.Langs["AnimationsMenuTitle"], GetConfig.Langs["AnimationsMenuSubTitle"])
            {
                RightIcon = MenuItem.Icon.ARROW_RIGHT
            };

            mainMenu.AddMenuItem(subAnimationsMenu);
            MenuController.BindMenuItem(mainMenu, AnimationsMenu.GetMenu(), subAnimationsMenu);





            // EmotesMenu
            MenuController.AddSubmenu(mainMenu, EmotesMenu.GetMenu());

            MenuItem subEmotesMenu = new MenuItem(GetConfig.Langs["EmotesMenuTitle"], GetConfig.Langs["EmotesMenuSubTitle"])
            {
                RightIcon = MenuItem.Icon.ARROW_RIGHT
            };

            mainMenu.AddMenuItem(subEmotesMenu);
            MenuController.BindMenuItem(mainMenu, EmotesMenu.GetMenu(), subEmotesMenu);




            //Nico Nico Ni nanananoe

            //mainMenu.OnMenuOpen += (_menu) => {

            //};

            //mainMenu.OnMenuClose += (_menu) =>
            //{

            //};

        }

        public static Menu GetMenu()
        {
            SetupMenu();
            return mainMenu;
        }
    }
}
