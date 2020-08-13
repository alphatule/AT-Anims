using CitizenFX.Core;
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

        public static bool inAnim = false;
        public static uint KeyFastAnim = 0;

        public Funciones()
        {
            Tick += OnScenario;
        }

        private static async Task OnScenario()
        {
            if (!GetConfig.configLoaded) return;
            if (API.IsControlJustPressed(0, KeyFastAnim))
            {
                if (GetConfig.Config["AutoScenarioActivated"].ToObject<bool>())
                {
                    if (!inAnim)
                    {
                        Vector3 pCoords = API.GetEntityCoords(API.PlayerPedId(), true, true);
                        Function.Call((Hash)0x322BFDEA666E2B0E, API.PlayerPedId(), pCoords.X, pCoords.Y, pCoords.Z, 5.0, -1, 1, 1, 1, 1);
                        inAnim = true;
                    }
                    else
                    {
                        API.ClearPedTasks(API.PlayerPedId(), 1, 1);
                        inAnim = false;
                    }
                }
            }
        }

        public static async Task ResetWalk()
        {

            foreach (var WalkStyle in GetConfig.Config["WalkStyleList"])
            {
                Function.Call((Hash)0xCB9401F918CB0F75, API.PlayerPedId(), WalkStyle["Style"].ToString(), 0, -1);
                await Delay(20);
            }
        }

        internal static void SetWalk(string style)
        {
            Function.Call((Hash)0xCB9401F918CB0F75, API.PlayerPedId(), style, 1, -1);
        }

        public static void StopAnimation()
        {
            API.ClearPedTasks(API.PlayerPedId(), 1, 1);
        }

        public static async Task StartAnimation(string dic, string anim)
        {
            await LoadAnim(dic);
            Function.Call(Hash.TASK_PLAY_ANIM, API.PlayerPedId(), dic, anim, 1.0f, 8.0f, -1, 0, 0.0f, false, false, false);
        }

        public static async Task StartTypeAnim(int dicTable)
        {
            Debug.WriteLine(GetConfig.Config["AnimationsList"][dicTable]["Type"].ToString());
            if (GetConfig.Config["AnimationsList"][dicTable]["Type"].ToString() != "scenario")
            {
                StartAnimation(GetConfig.Config["AnimationsList"][dicTable]["Dic"].ToString(), GetConfig.Config["AnimationsList"][dicTable]["Anim"].ToString());
            }
            else
            {
                if (!API.IsPedUsingAnyScenario(API.PlayerPedId()))
                {
                    int hashDic = API.GetHashKey(GetConfig.Config["AnimationsList"][dicTable]["Anim"].ToString());
                    API.TaskStartScenarioInPlace(API.PlayerPedId(), hashDic, -1, 0, 0, 0, 0);
                }
            }
        }

        private static async Task LoadAnim(string dic)
        {
            API.RequestAnimDict(dic);

            while (!API.HasAnimDictLoaded(dic))
            {
                await Delay(100);
            }
        }
    }
}
