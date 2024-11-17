using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StellarPlay.Common.Manager;
using TMPro;
using StellarPlay.RPS.Core;


namespace StellarPlay.RPS.UI {
    public class PlayerHandButton: Button
    {

        string _handType;

        public void UpdateHandType(string handName)
        {
            _handType = handName;
            GetComponentInChildren<TextMeshProUGUI>().text = handName;
            EventManager.Instance.SubscribeEvent(eGameEvents.NextRound, OnNextRound);

        }

        protected override void Start()
        {
            base.Start();
            onClick.AddListener(OnButtonClick);
        }

        void OnButtonClick()
        {
            interactable = false;
            EventManager.Instance.TriggerEvent(eGameEvents.PlayerChoiceInput,_handType);
        }

        void OnNextRound(string info)
        {
            interactable = true;
        }
    }
}
