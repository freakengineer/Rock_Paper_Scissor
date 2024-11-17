using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StellarPlay.Common.Manager;
using StellarPlay.RPS.Controller;


namespace StellarPlay.RPS.Launcher
{
    public class LoadingContext : Context
    {
        GameConfigParserController _gameConfigParser;

        public override void RegisterServices()
        {
            base.RegisterServices();
        }

        public override void UnRegisterServices()
        {
            base.UnRegisterServices();
        }

        public override void CreateControllers()
        {
            _gameConfigParser = new GameConfigParserController();
        }

    }
}
