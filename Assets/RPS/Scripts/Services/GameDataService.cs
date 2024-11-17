using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StellarPlay.Common.Manager;
using System;
using Newtonsoft.Json;
using StellarPlay.RPS.Core;

namespace StellarPlay.RPS.Services
{

    public interface IGameDataService : IService
    {
        List<string> GetHandTypes();

        bool IsWinner(string choice, string opponent);

        void LoadConfigFromJson(string jsonString);
    }

    public class GameConfig
    {
        [JsonProperty("winningConditions")]
        public Dictionary<string, List<string>> WinningConditions { get; set; }
    }
    public class GameDataService : IGameDataService
    {
        List<string> _playerHandNames = new List<string>();

        GameConfig _config;

        public List<string> GetHandTypes()
        {
            return _playerHandNames;
        }

        public bool IsWinner(string choice, string opponent)
        {
            return _config.WinningConditions[choice].Contains(opponent);
        }

        public void LoadConfigFromJson(string json)
        {
            _config =  JsonConvert.DeserializeObject<GameConfig>(json);
            foreach(var kv in _config.WinningConditions)
            {
                _playerHandNames.Add(kv.Key);
            }
            EventManager.Instance.TriggerEvent(eGameStateEvents.ConfigDataLoaded);
        }
    }
}
