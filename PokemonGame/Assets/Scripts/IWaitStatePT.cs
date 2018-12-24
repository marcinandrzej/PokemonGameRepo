using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IWaitStatePT : IGameStatesPT
{
    private GameManagerScriptPT gM;

    public void Execute(GameObject tower, int player)
    {

    }

    public void OnStateEnter(GameManagerScriptPT gameManager)
    {
        gM = gameManager;
        gM.Wait(2, new IEnemyMoveStatePT(), 1);
    }
}