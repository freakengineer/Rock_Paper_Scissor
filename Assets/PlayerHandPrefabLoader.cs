using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StellarPlay.Common.Manager;
using StellarPlay.RPS.Core;
using StellarPlay.RPS.Services;


namespace StellarPlay.RPS.UI
{
    public class PlayerHandPrefabLoader : MonoBehaviour
    {
        [SerializeField]
        PlayerHandButton _playerHandPrefab;

        IGameDataService gameDataService;

        private void Start()
        {
            EventManager.Instance.SubscribeEvent(eGameStateEvents.GamePlayLoaded, LoadPrefab);
            gameDataService = ServiceManager.Instance.GetService<IGameDataService>();
        }

        void LoadPrefab(string eventInfo)
        {
            List<string> handsNames = gameDataService.GetHandTypes();

            for(int i = 0; i <handsNames.Count; i++)
            {
                PlayerHandButton playerHand = Instantiate(_playerHandPrefab,transform);
                playerHand.UpdateHandType(handsNames[i]);
            }
        }
    }
}
