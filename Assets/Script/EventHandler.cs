using System;
using UnityEngine;

namespace Script
{
    public static class EventHandler
    {
        public static Action AfterLevelLoad;
        public static void CallAfterSceneLoad()
        {
            AfterLevelLoad?.Invoke();
        }

        public static Action AfterLevelUnLoad;
        public static void CallAfterSceneUnload()
        {
            AfterLevelUnLoad?.Invoke();
        }

        public static Action AfterPlayerDead;
        public static void CallAfterPlayerDead()
        {
            AfterPlayerDead?.Invoke();
        }

        public static Action DoNotHaveEnoughFood;
        public static void CallDoNotHaveEnoughFood()
        {
            DoNotHaveEnoughFood?.Invoke();
        }
        
        public static Action AfterPlayerHealthChange;
        /// <summary>
        /// 当玩家生命值变化后
        /// </summary>
        public static void CallAfterPlayerHealthChange()
        {
            AfterPlayerHealthChange?.Invoke();
        }
    }
}
