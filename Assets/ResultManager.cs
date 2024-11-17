using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StellarPlay.Common.Manager;
using StellarPlay.RPS.Core;
using StellarPlay.RPS.Services;


namespace StellarPlay.RPS.GamePlay
{
    public class ResultManager : MonoBehaviour
    {
        IGameDataService gameDataServices;
        // Start is called before the first frame update
        void Start()
        {
            EventManager.Instance.SubscribeEvent(eGameEvents.PlayerChoiceInput,OnPlayerChoice);
            gameDataServices = ServiceManager.Instance.GetService<IGameDataService>();
        }

        void OnPlayerChoice(string handType)
        {
            int index = UnityEngine.Random.Range(0, 5);

            string computerhandType = gameDataServices.GetHandTypes()[index];

            if(computerhandType == handType)
            {
                EventManager.Instance.TriggerEvent(eGameEvents.Tie, computerhandType);
            }
            else
            {
                bool isPlayerWon = gameDataServices.IsWinner(handType, computerhandType);

                if (isPlayerWon)
                {
                    EventManager.Instance.TriggerEvent(eGameEvents.WonHand, computerhandType);
                }
                else
                {
                    EventManager.Instance.TriggerEvent(eGameEvents.LooseHand, computerhandType);

                }
            }
        }

    }
}
