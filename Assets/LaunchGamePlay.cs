using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StellarPlay.Common.Manager;
using StellarPlay.RPS.Core;


namespace StellarPlay.RPS.Home
{
    public class LaunchGamePlay : MonoBehaviour
    {

        public void LoadGame()
        {
            EventManager.Instance.TriggerEvent(eGameStateEvents.GamePlay);
        }
    }
}
