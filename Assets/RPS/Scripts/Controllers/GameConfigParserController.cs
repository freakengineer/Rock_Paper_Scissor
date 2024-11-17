using System.Collections;
using System.Collections.Generic;
using StellarPlay.RPS.Services;
using StellarPlay.Common.Manager;
using UnityEngine;
using StellarPlay.RPS.Core;

namespace StellarPlay.RPS.Controller
{
    public class GameConfigParserController
    {
        IGameDataService gameDataService;

        public GameConfigParserController()
        {
            SubscribeEvents();
        }

        ~GameConfigParserController()
        {
            UnSubscribeEvents();
        }

        public void SubscribeEvents()
        {
            EventManager.Instance.SubscribeEvent(eGameStateEvents.Launched, LoadGameComnfigData);

        }

        public void UnSubscribeEvents()
        {
            EventManager.Instance.UnSubscribeEvent(eGameStateEvents.Launched,LoadGameComnfigData);
        }

        void LoadGameComnfigData(string eventInfo)
        {
            gameDataService = ServiceManager.Instance.GetService<IGameDataService>();
            TextAsset jsonFile = Resources.Load<TextAsset>("WinningCondition"); // "data" is the file name without the extension

            if (jsonFile != null)
            {
                Debug.LogError("Json file  found");
                gameDataService.LoadConfigFromJson(jsonFile.text);
            }
            else
            {
                Debug.LogError("Json file not found");
            }
           
        }
    }
}
