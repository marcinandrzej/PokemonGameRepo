using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEndStatePT : IGameStatesPT
{
    private GameManagerScriptPT gM;

    public void Execute(GameObject tower, int player)
    {

    }

    public void OnStateEnter(GameManagerScriptPT gameManager)
    {
        gM = gameManager;
        if (gM.IfPlayerWon())
        {
            gM.GetComponent<GUIControllerScriptPT>().ViewMessage("You win", 2, true);
        }
        else
        {
            gM.GetComponent<GUIControllerScriptPT>().ViewMessage("You lose", 2, true);
        }
    }
}
