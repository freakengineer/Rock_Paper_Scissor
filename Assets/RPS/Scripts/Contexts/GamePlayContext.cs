using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StellarPlay.Common.Manager;
using StellarPlay.RPS.Core;


namespace StellarPlay.RPS.GameContext
{
    public class GamePlayContext : MonoBehaviour
    {
        ServiceManager serviceManager;
        // Start is called before the first frame update
        IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            EventManager.Instance.TriggerEvent(eGameStateEvents.GamePlayLoaded);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
