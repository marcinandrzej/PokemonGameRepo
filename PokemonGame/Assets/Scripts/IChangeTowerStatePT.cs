using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IChangeTowerStatePT : IGameStatesPT
{
    private GameManagerScriptPT gM;

    public void Execute(GameObject tower, int player)
    {
        gM.GetComponent<SoundScriptPT>().PlaySound(Sounds.TRANSFORM);
        int pT = (int)tower.GetComponent<PokeTowerScript>().GetPokeType();
        PokeType newType = generateType(pT);
        Sprite towerSprite = gM.GetComponent<ConstDataScript>().GetTowerSprite(newType);
        tower.GetComponent<PokeTowerScript>().ChangeType(newType, towerSprite);
        if (player == 1)
        {
            gM.ChangeState(new IEnemyMoveStatePT());
            gM.UndoPowerPoints(2, 1);
            gM.GetComponent<GUIControllerScriptPT>().LockUnlockPowers(false, gM.GetPowerPoints(1));
        }
        else
        {
            gM.UndoPowerPoints(2, 2);
        }
    }

    public void OnStateEnter(GameManagerScriptPT gameManager)
    {
        gM = gameManager;
    }

    public void OnStateExit()
    {
    }

    private PokeType generateType(int typeIndex)
    {
        int typesCount = System.Enum.GetNames(typeof(PokeType)).Length;
        int newIndex = Random.Range(0, typesCount);
        while (newIndex == typeIndex)
        {
            newIndex = Random.Range(0, typesCount);
        }
        PokeType pT = gM.GetComponent<ConstDataScript>().GetType(newIndex);
        return pT;
    }
}