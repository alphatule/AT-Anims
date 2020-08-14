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

            // Stop Animations
            MenuItem stopAnim = new MenuItem(GetConfig.Langs["StopAnim"].ToString(), " ")
            {
                RightIcon = MenuItem.Icon.STAR
            };
            animationsMenu.AddMenuItem(stopAnim);

            //Animation list
            foreach (var k in GetConfig.Config["AnimationsList"])
            {
                MenuItem animName = new MenuItem(k["Name"].ToString(), " ")
                {
                    //RightIcon = MenuItem.Icon.CIRCLE
                };
                animationsMenu.AddMenuItem(animName);
            }

            animationsMenu.OnItemSelect += async (_menu, _item, _index) =>
            {
                if (_index == 0)
                {
                    Funciones.StopAnimation();
                }
                else
                {
                    Funciones.StartTypeAnim(animationsMenu.CurrentIndex - 1);
                }    
            };
        }

        public static Menu GetMenu()
        {
            SetupMenu();
            return animationsMenu;
        }
    }
}
