using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemyMoveStatePT : IGameStatesPT
{
    private GameManagerScriptPT gM;

    public void Execute(GameObject tower, int player)
    {
    }

    public void OnStateEnter(GameManagerScriptPT gameManager)
    {
        gM = gameManager;
        IGameStatesPT gS = new IHealStatePT();
        int points = gM.GetPowerPoints(2);
        int height = gM.GetTowerHeight();
        int index = Random.Range(0, height);
        float prob = Random.Range(0.0f, 1.0f);
        List<int> list;

        switch (points)
        {
            case 0:
                gS = new IAttackStatePT();
                list = new List<int>();
                for (int i = 0; i < height; i++)
                {
                    if (gM.HasDisadvantage(i, false))
                    {
                        int g = i;
                        list.Add(g);
                    }
                }
                if (list.Count > 0)
                {
                    index = list[Random.Range(0, list.Count)];
                }
                break;
            case 1:
                gS = new IAttackStatePT();
                list = new List<int>();
                for (int i = 0; i < height; i++)
                {
                    if (gM.HasDisadvantage(i, false))
                    {
                        int g = i;
                        list.Add(g);
                    }
                }
                if (list.Count > 0)
                {
                    index = list[Random.Range(0, list.Count)];
                }
                if (Random.Range(0.0f, 1.0f) < 0.05f && gM.GetTowerHeightP2() > 1)
                {
                    gS = new ISwapStatePT();
                    index = Random.Range(0, gM.GetTowerHeightP2());
                }
                break;
            case 2:
                gS = new IAttackStatePT();
                list = new List<int>();
                for (int i = 0; i < height; i++)
                {
                    if (gM.HasDisadvantage(i, false))
                    {
                        int g = i;
                        list.Add(g);
                    }
                }
                if (list.Count > 0)
                {
                    index = list[Random.Range(0, list.Count)];
                }
                if (prob < 0.05f && gM.GetTowerHeightP2() > 1)
                {
                    gS = new ISwapStatePT();
                    index = Random.Range(0, gM.GetTowerHeightP2());
                }
                else if (prob < 0.25f)
                {
                    list = new List<int>();
                    for (int i = 0; i < height; i++)
                    {
                        if (gM.HasDisadvantage(i, true))
                        {
                            int g = i;
                            list.Add(g);
                        }
                    }
                    if (list.Count > 0)
                    {
                        gS = new IChangeTowerStatePT();
                        index = list[Random.Range(0, list.Count)];
                    }
                }
                break;
            default:
                gS = new IAttackStatePT();
                list = new List<int>();
                for (int i = 0; i < height; i++)
                {
                    if (gM.HasDisadvantage(i, false))
                    {
                        int g = i;
                        list.Add(g);
                    }
                }
                if (list.Count > 0)
                {
                    index = list[Random.Range(0, list.Count)];
                }
                if (prob < 0.01f * points && gM.GetTowerHeightP2() > 1)
                {
                    gS = new ISwapStatePT();
                    index = Random.Range(0, gM.GetTowerHeightP2());
                }
                else if (prob < 0.05f * points)
                {
                    list = new List<int>();
                    for (int i = 0; i < height; i++)
                    {
                        if (gM.HasDisadvantage(i, true))
                        {
                            int g = i;
                            list.Add(g);
                        }
                    }
                    if (list.Count > 0)
                    {
                        gS = new IChangeTowerStatePT();
                        index = list[Random.Range(0, list.Count)];
                    }
                }
                else if (prob < 0.20f * points)
                {
                    height = gM.GetTowerHeightP2();
                    list = new List<int>();
                    for (int i = 0; i < height; i++)
                    {
                        if (gM.GetTowerHp(i) <= 2)
                        {
                            int g = i;
                            list.Add(g);
                        }
                    }
                    if (list.Count > 0)
                    {
                        gS = new IHealStatePT();
                        index = list[Random.Range(0, list.Count)];
                    }
                }
                break;
        }
        gS.OnStateEnter(gM);
        gS.Execute(gM.GetTowerP2(index), 2);
        gM.AddPowerPoints(2);
        gM.Wait(2, new IAttackStatePT(), 2);
    }
}