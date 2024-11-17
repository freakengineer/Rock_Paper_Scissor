using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StellarPlay.Common.Manager;
using StellarPlay.RPS.Services;


namespace StellarPlay.RPS.Core
{
    public class MainContext : Context
    {
        SceneController _sceneController;
        GameDataService gameDataService = new GameDataService();

        public override void RegisterServices()
        {
            DontDestroyOnLoad(gameObject);
            serviceManager.RegisterService<IGameDataService>(gameDataService);
        }

        public override void PostRegistration()
        {
            EventManager.Instance.TriggerEvent(eGameStateEvents.Launched);
        }

        public override void UnRegisterServices()
        {
            serviceManager.UnregisterService<IGameDataService>();

        }

        public override void CreateControllers()
        {
            _sceneController = new SceneController();
        }

    }
}
