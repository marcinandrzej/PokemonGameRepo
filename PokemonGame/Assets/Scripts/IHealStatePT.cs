using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IHealStatePT : IGameStatesPT
{
    private GameManagerScriptPT gM;

    public void Execute(GameObject tower, int player)
    {
        int hp = gM.GetMaxHP();
        gM.GetComponent<SoundScriptPT>().PlaySound(Sounds.HEAL);
        tower.GetComponent<PokeTowerScript>().HealTower(hp);
        if (player == 1)
        {
            gM.ChangeState(new IEnemyMoveStatePT());
            gM.UndoPowerPoints(3,1);
            gM.GetComponent<GUIControllerScriptPT>().LockUnlockPowers(false, gM.GetPowerPoints(1));
        }
        else
        {
            gM.UndoPowerPoints(3, 2);
        }
    }

    public void OnStateEnter(GameManagerScriptPT gameManager)
    {
        gM = gameManager;
    }
}
