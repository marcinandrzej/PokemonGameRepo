using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAttackStatePT : IGameStatesPT
{
    private GameManagerScriptPT gM;

    public void Execute(GameObject tower, int player)
    {
        int xOffset = -2;
        Vector2 force = new Vector2(-500, 0);
        if (player == 1)
        {
            xOffset = 2;
            force = new Vector2(500, 0);
            gM.GetComponent<GUIControllerScriptPT>().LockUnlockPowers(false, gM.GetPowerPoints(1));
        }

        PokeType pT= tower.GetComponent<PokeTowerScript>().GetPokeType();
        Vector3 position = new Vector3(tower.transform.position.x + xOffset,
            tower.transform.position.y, tower.transform.position.z);

        tower.GetComponent<PokeTowerScript>().Attack(gM.GetComponent<ConstDataScript>().GetAttackSprite(pT),
            position, force);

        if (player == 1)
        {
            gM.ChangeState(new IWaitStatePT());
        }
    }

    public void OnStateEnter(GameManagerScriptPT gameManager)
    {
        gM = gameManager;
    }
}
