﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using static BP_Essentials.EssentialsVariablesPlugin;
using static BP_Essentials.EssentialsMethodsPlugin;

namespace BP_Essentials
{
    class SaveNow : EssentialsChatPlugin
    {
        public static void Run()
        {
            try
            {
                Debug.Log(SetTimeStamp.Run() + "[INFO] Saving game..");
                foreach (var shPlayer in FindObjectsOfType<ShPlayer>())
                    if (shPlayer.IsRealPlayer())
                    {
                        if (shPlayer.GetPlaceIndex() >= 13) continue;
                        shPlayer.svPlayer.SendToSelf(Channel.Unsequenced, 10, "Saving game.. This can take up to 5 seconds.");
                        shPlayer.svPlayer.Save();
                    }
            }
            catch (Exception ex)
            {
                ErrorLogging.Run(ex);
            }
        }
    }
}
