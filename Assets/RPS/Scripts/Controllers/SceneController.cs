using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StellarPlay.Common.Manager;
using UnityEngine.SceneManagement;


namespace StellarPlay.RPS.Core
{
    public class SceneController
    {
        public SceneController()
        {
            EventManager.Instance.SubscribeEvent(eGameStateEvents.GamePlay,LoadGamePlay);

        }

        ~SceneController()
        {
            EventManager.Instance.UnSubscribeEvent(eGameStateEvents.GamePlay, LoadGamePlay);

        }

        void LoadGamePlay(string eventInfo)
        {
            SceneManager.LoadScene(1);
        }
    }
}
