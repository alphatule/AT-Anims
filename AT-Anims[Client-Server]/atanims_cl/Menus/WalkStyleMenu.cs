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

            foreach (var WalkStyle in GetConfig.Config["WalkStyleList"])
            {
                walkStyleMenu.AddMenuItem(new MenuItem(WalkStyle["Name"].ToString(), "")
                {
                    Enabled = true,
                });
            }



            walkStyleMenu.OnItemSelect += async (_menu, _item, _index) =>
            {

                if (_index <= GetConfig.Config["WalkStyleList"].Count())
                {
                    await Funciones.ResetWalk();
                    Funciones.SetWalk(GetConfig.Config["WalkStyleList"][_index]["Style"].ToString());
                }
            };

        }
        public static Menu GetMenu()
        {
            SetupMenu();
            return walkStyleMenu;
        }
    }
}
