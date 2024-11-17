using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StellarPlay.RPS.Core
{
    public enum eGameStateEvents
    {
        Launched, ConfigDataLoaded,HomeScreen,GamePlay,GamePlayLoaded
    }

    public enum eGameEvents
    {
        PlayerChoiceInput,WonHand,LooseHand,NextRound,Tie
    }
}
