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
        private static Menu emotesMenu = new Menu(GetConfig.Langs["EmotesMenuTitle"], GetConfig.Langs["EmotesMenuSubTitle"]);
        private static bool setupDone = false;
        private static void SetupMenu()
        {
            if (setupDone) return;
            setupDone = true;
            MenuController.AddMenu(emotesMenu);

            // Emote List
            foreach (var k in GetConfig.Config["EmotesList"])
            {
                emotesMenu.AddMenuItem(new MenuItem(k["Name"].ToString(), "")
                {
                    Enabled = true
                });
            }

            emotesMenu.OnItemSelect += async (_menu, _item, _index) =>
            {
                if (_index <= GetConfig.Config["EmotesList"].Count())
                {
                    Funciones.StartTypeEmote(GetConfig.Config["EmotesList"][_index]["Emote"].ToObject<int>());
                }
            };

        }
        public static Menu GetMenu()
        {
            SetupMenu();
            return emotesMenu;
        }

    }
} 
