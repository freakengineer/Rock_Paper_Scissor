using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StellarPlay.Common.Manager;
using StellarPlay.RPS.Core;
using UnityEngine.UI;
using TMPro;



namespace StellarPlay.RPS.GamePlay
{
    public class ResultDisplayManager : MonoBehaviour
    {
        [SerializeField]
        Text _scoreText, _resultText;

        [SerializeField]
        TextMeshProUGUI _computerHandText;

        [SerializeField]
        GameObject _computerHand;

        int score;

        // Start is called before the first frame update
        void Start()
        {
            EventManager.Instance.SubscribeEvent(eGameEvents.WonHand, OnWon);
            EventManager.Instance.SubscribeEvent(eGameEvents.LooseHand, OnLoose);
            EventManager.Instance.SubscribeEvent(eGameEvents.Tie, OnTie);
        }

        void OnTie(string info)
        {
            _resultText.text = "TIE";
            _computerHand.gameObject.SetActive(true);
            StartCoroutine(NextRound());
        }

        void OnWon(string computerHand)
        {
            _resultText.text = "YOU WON";
            score++;
            UpdateBoard(score, computerHand);
            StartCoroutine(NextRound());
        }

        IEnumerator NextRound()
        {
            yield return new WaitForSeconds(3.0f);
            _resultText.text = null;
            _computerHand.gameObject.SetActive(false);
            EventManager.Instance.TriggerEvent(eGameEvents.NextRound);
        }

        void UpdateBoard(int score, string handInfo)
        {
            _computerHand.gameObject.SetActive(true);
            _computerHandText.text = handInfo;
            _scoreText.text = "Score: " + score;
        }

        void OnLoose(string computerHand)
        {
            _resultText.text = "YOU LOOSE";
            score = 0;
            UpdateBoard(score, computerHand);
            StartCoroutine(NextRound());
        }

       
    }
}
