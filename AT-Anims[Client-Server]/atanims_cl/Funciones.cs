﻿using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace atanims_cl
{
    public class Funciones : BaseScript
    {
        public static async void ResetWalk(){
            Function.Call((Hash)0xCB9401F918CB0F75, API.PlayerPedId(), "MP_Style_Default", 0, -1);
            await Delay(20);
            Function.Call((Hash)0xCB9401F918CB0F75, API.PlayerPedId(), "MP_Style_Casual", 0, -1);
            await Delay(20);
            Function.Call((Hash)0xCB9401F918CB0F75, API.PlayerPedId(), "MP_Style_Crazy", 0, -1);
            await Delay(20);
            Function.Call((Hash)0xCB9401F918CB0F75, API.PlayerPedId(), "MP_Style_Flamboyant", 0, -1);
            await Delay(20);
            Function.Call((Hash)0xCB9401F918CB0F75, API.PlayerPedId(), "MP_Style_Gunslinger", 0, -1);
            await Delay(20);
            Function.Call((Hash)0xCB9401F918CB0F75, API.PlayerPedId(), "MP_Style_Refined", 0, -1);
            await Delay(20);
            Function.Call((Hash)0xCB9401F918CB0F75, API.PlayerPedId(), "MP_Style_SilentType", 0, -1);
            await Delay(20);
            Function.Call((Hash)0xCB9401F918CB0F75, API.PlayerPedId(), "MP_Style_Greenhorn", 0, -1);
            await Delay(20);
            Function.Call((Hash)0xCB9401F918CB0F75, API.PlayerPedId(), "MP_Style_Veteran", 0, -1);
            await Delay(20);
            Function.Call((Hash)0xCB9401F918CB0F75, API.PlayerPedId(), "MP_Style_EasyRider", 0, -1);
        }
    }
}
