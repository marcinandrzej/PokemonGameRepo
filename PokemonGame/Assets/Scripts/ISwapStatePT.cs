using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISwapStatePT : IGameStatesPT
{
    private GameManagerScriptPT gM;

    public void Execute(GameObject tower, int player)
    {
        gM.GetComponent<SoundScriptPT>().PlaySound(Sounds.SWAP);
        gM.SwapTowers(tower, player);
        if (player == 1)
        {
           gM.ChangeState(new IEnemyMoveStatePT());
           gM.UndoPowerPoints(1, 1);
           gM.GetComponent<GUIControllerScriptPT>().LockUnlockPowers(false, gM.GetPowerPoints(1));
        }
        else
        {
            gM.UndoPowerPoints(1, 2);
        }
    }

    public void OnStateEnter(GameManagerScriptPT gameManager)
    {
        gM = gameManager;
    }
}
