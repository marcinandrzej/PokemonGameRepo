using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScriptPT : MonoBehaviour
{
    private const int MAX_HEALTH = 6;
    private const int NUMBER_OF_TOWERS = 3;

    private int powerPoints;
    private int powerPointsP2;

    private Vector3 DROP_POINT_P1;
    private Vector3 DROP_POINT_P2;
    
    private List<GameObject> towersP1;
    private List<GameObject> towersP2;

    private IGameStatesPT gameState;

    public Sprite hpSprite;

    // Use this for initialization
    void Start ()
    {
        ChangeState(new IEnterGameStatePT());
        towersP1 = new List<GameObject>();
        towersP2 = new List<GameObject>();
        DROP_POINT_P1 = new Vector3(-5.0f, 3.0f, 0.0f);
        DROP_POINT_P2 = new Vector3(5.0f, 3.0f, 0.0f);
        powerPoints = 0;
        powerPointsP2 = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    public int GetMaxHP()
    {
        return MAX_HEALTH;
    }

    public int GetNumberOfTowers()
    {
        return NUMBER_OF_TOWERS;
    }

    public int GetTowerHeight()
    {
        return Mathf.Min(towersP1.Count, towersP2.Count);
    }

    public int GetTowerHeightP2()
    {
        return towersP2.Count;
    }

    public bool HasDisadvantage(int index, bool defending)
    {
        PokeType defType = towersP2[index].GetComponent<PokeTowerScript>().GetPokeType();
        PokeType attType = towersP1[index].GetComponent<PokeTowerScript>().GetPokeType();
        int damage = 2;
        if (defending)
        {
            damage = transform.GetComponent<ConstDataScript>().CountDamage(attType, defType);
            if (damage > transform.GetComponent<ConstDataScript>().GetBaseDamage() * 2)
                return true;
            return false;
        }
        else
        {
            damage = transform.GetComponent<ConstDataScript>().CountDamage(defType, attType);
            if (damage > transform.GetComponent<ConstDataScript>().GetBaseDamage() * 2)
                return true;
            return false;
        }
    }

    public int GetTowerHp(int index)
    {
        return towersP2[index].GetComponent<PokeTowerScript>().GetCurrentHp();
    }

    public GameObject GetTowerP2(int index)
    {
        return towersP2[index];
    }

    public bool IsEnd()
    {
        if (towersP1.Count == 0 || towersP2.Count == 0)
            return true;
        return false;
    }

    public bool IfPlayerWon()
    {
        if (towersP1.Count == 0)
            return false;
        return true;
    }

    public void AddPowerPoints(int player)
    {
        switch (player)
        {
            case 1:
                powerPoints = System.Math.Min(powerPoints + 1, 5);
                break;
            case 2:
                powerPointsP2 = System.Math.Min(powerPointsP2 + 1, 5);
                break;
        }
    }

    public int GetPowerPoints(int player)
    {
        int points = 0;
        switch (player)
        {
            case 1:
                points = powerPoints;
                break;
            case 2:
                points = powerPointsP2;
                break;
        }
        return points;
    }

    public void UndoPowerPoints(int points, int player)
    {
        switch (player)
        {
            case 1:
                powerPoints -= points;
                break;
            case 2:
                powerPointsP2 -= points;
                break;
        }
    }

    public void Wait(int time, IGameStatesPT gS, int player)
    {
        StartCoroutine(WaitExecute(time, gS, player));
    }

    private IEnumerator WaitExecute(int time, IGameStatesPT gS, int player)
    {
        yield return new WaitForSeconds(time);
        if (!IsEnd())
        {
            ChangeState(gS);
            if (player == 2)
            {

                transform.GetComponent<GUIControllerScriptPT>().ViewMessage("Your Turn", 1, false);
                AddPowerPoints(1);
                transform.GetComponent<GUIControllerScriptPT>().LockUnlockPowers(true, powerPoints);
            }
        }
        else
        {
            ChangeState(new IEndStatePT());
        }
    }

    public IEnumerator SetTowers(List<PokeType> listP1, List<PokeType> listP2)
    {
        for (int i = 0; i < listP1.Count; i++)
        {
            AddTower(1, listP1[i]);
            AddTower(2, listP2[i]);
            yield return new WaitForSeconds(0.8f);
        }
        ChangeState(new IAttackStatePT());
        transform.GetComponent<GUIControllerScriptPT>().LockUnlockPowers(true, powerPoints);
    }

    public void ChangeState(IGameStatesPT newState)
    {
        gameState = newState;
        gameState.OnStateEnter(this);
    }

    public void Execute(GameObject tower)
    {
        if (towersP1.Contains(tower))
        {
            gameState.Execute(tower, 1);
        }
    }

    public void DealDamage(GameObject tower, GameObject attBall)
    {
        PokeType defType = tower.GetComponent<PokeTowerScript>().GetPokeType();
        PokeType attType = attBall.transform.parent.GetComponent<PokeTowerScript>().GetPokeType();
        int damage = transform.GetComponent<ConstDataScript>().CountDamage(attType, defType);
        if (damage > 0)
        {
            bool isDead = tower.GetComponent<PokeTowerScript>().TakeDamage(damage);
            if (isDead)
            {
                gameObject.GetComponent<SoundScriptPT>().PlaySound(Sounds.DESTROY);
                DestroyTower(tower);
            }
            else
            {
                gameObject.GetComponent<SoundScriptPT>().PlaySound(Sounds.DAMAGE);
            }
        }
    }

    public void SwapTowers(GameObject tower, int player)
    {
        List<GameObject> towersList = towersP2;
        if (player == 1)
            towersList = towersP1;
        if (towersList.IndexOf(tower) != (towersList.Count - 1) && towersList.Count > 1)
        {
            int index1 = towersList.IndexOf(tower);
            int index2 = index1 + 1;
            GameObject tmp = towersList[index1];
            towersList[index1] = towersList[index2];
            towersList[index2] = tmp;

            Vector3 pos = towersList[index1].transform.position;
            towersList[index1].transform.position = towersList[index2].transform.position;
            towersList[index2].transform.position = pos;
        }
        else if (towersList.IndexOf(tower) == (towersList.Count - 1) && towersList.Count > 1)
        {
            int index1 = towersList.IndexOf(tower);
            int index2 = index1 - 1;
            GameObject tmp = towersList[index1];
            towersList[index1] = towersList[index2];
            towersList[index2] = tmp;

            Vector3 pos = towersList[index1].transform.position;
            towersList[index1].transform.position = towersList[index2].transform.position;
            towersList[index2].transform.position = pos;
        }
    }

    public void DestroyTower(GameObject tower)
    {
        if(towersP1.Contains(tower))
        {
            towersP1.Remove(tower);
        }
        else
        {
            towersP2.Remove(tower);
        }
        Destroy(tower);
    }

    public void AddTower(int player, PokeType type)
    {
        //Instantiate tower
        GameObject tower = new GameObject("Tower");

        //Set parent
        tower.transform.parent = transform;

        //Add  and set comonents
        tower.transform.localScale = new Vector3(1.25f, 1.25f, 1.0f);
        tower.AddComponent<SpriteRenderer>();
        tower.AddComponent<PokeTowerScript>();
        tower.GetComponent<PokeTowerScript>().ChangeType(type,
            transform.GetComponent<ConstDataScript>().GetTowerSprite(type));
        tower.AddComponent<BoxCollider2D>();
        tower.GetComponent<BoxCollider2D>().size = new Vector2(2.0f, 2.0f);
        tower.AddComponent<Rigidbody2D>();
        tower.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        tower.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        // Setting up hp canvas
        GameObject canvas = new GameObject("Hp");
        canvas.AddComponent<Canvas>();
        canvas.AddComponent<CanvasScaler>();
        canvas.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        canvas.transform.SetParent(tower.transform);
        canvas.GetComponent<CanvasScaler>().dynamicPixelsPerUnit = 200;
        canvas.GetComponent<CanvasScaler>().referencePixelsPerUnit = 100;
        canvas.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        canvas.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 0.0f);
        canvas.GetComponent<RectTransform>().anchorMax = new Vector2(0.0f, 0.0f);
        canvas.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        canvas.GetComponent<RectTransform>().sizeDelta = new Vector3(2.0f, 1.8f);
        canvas.GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);

        GameObject hpImg = new GameObject("HPLvl");
        hpImg.AddComponent<Image>();
        hpImg.GetComponent<Image>().sprite = hpSprite;
        hpImg.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
        hpImg.GetComponent<Image>().type = Image.Type.Filled;
        hpImg.GetComponent<Image>().fillMethod = Image.FillMethod.Horizontal;
        hpImg.GetComponent<Image>().fillAmount = 1;
        hpImg.transform.SetParent(canvas.transform);
        hpImg.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        hpImg.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1.0f);
        hpImg.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1.0f);
        hpImg.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        hpImg.GetComponent<RectTransform>().sizeDelta = new Vector3(1.5f, 0.3f);
        hpImg.GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, -0.15f, 0.0f);

        tower.GetComponent<PokeTowerScript>().HealTower(MAX_HEALTH);

        if (player == 1)
        {
            tower.transform.position = DROP_POINT_P1;
            towersP1.Add(tower);
        }
        else
        {
            tower.transform.position = DROP_POINT_P2;
            towersP2.Add(tower);
        }
    }
}
