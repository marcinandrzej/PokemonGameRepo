using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIControllerScriptPT : MonoBehaviour
{
    private List<PokeType> listP1;
    private List<PokeType> listP2;
    private List<GameObject> selectionList;
    private List<GameObject> powerPointsList;

    public Sprite startButtonSprite;
    public Sprite undoButtonSprite;
    public Sprite attackButtonSprite;
    public Sprite swapButtonSprite;
    public Sprite changeButtonSprite;
    public Sprite healButtonSprite;
    public Sprite playButtonSprite;
    public Sprite exitButtonSprite;
    public Sprite powerPoint;

    private Color32 selectionColor =  new Color32(216, 212, 84, 255);
 
    public GameObject gui;
    private GameObject textPanel;
    private GameObject endPanel;
    private GameObject selectionPanel;
    private GameObject startButton;
    private GameObject undoButton;
    private GameObject powersPanel;
    private GameObject endButton;
    // Use this for initialization
    void Start ()
    {
        listP1 = new List<PokeType>();
        listP2 = new List<PokeType>();
        selectionList = new List<GameObject>();
        powerPointsList = new List<GameObject>();
        SetUpPanel();
        SetUpButtons();
        SetUpPowerPoints();
    }
	
	// Update is called once per frame
	void Update ()
    {		
	}

    public void ViewMessage(string message, int time, bool end)
    {
        StartCoroutine(ViewMessageExecute(message, time, end));
    }

    private IEnumerator ViewMessageExecute(string message, int time, bool end)
    {
        textPanel.GetComponent<Text>().text = message;
        textPanel.SetActive(true);
        yield return new WaitForSeconds(time);
        textPanel.SetActive(false);

        if (end)
            LockUnlockEndPanel();
    }

    private void AddToList(int type)
    {
        if (listP1.Count < transform.GetComponent<GameManagerScriptPT>().GetNumberOfTowers())
        {
            listP1.Add((PokeType)type);
            AddToSelectionStack(type, (listP1.Count - 1));
        }
        if (listP1.Count >= transform.GetComponent<GameManagerScriptPT>().GetNumberOfTowers())
            LockUnlockSelection();
    }

    private void StartGame()
    {
        PopulateEnemy(transform.GetComponent<GameManagerScriptPT>().GetNumberOfTowers());
        selectionPanel.SetActive(false);
        startButton.SetActive(false);
        undoButton.SetActive(false);
        powersPanel.SetActive(true);
        StartCoroutine(transform.GetComponent<GameManagerScriptPT>().SetTowers(listP1, listP2));
    }

    private void PopulateEnemy(int numberOfTowers)
    {
        for (int i = 0; i < numberOfTowers; i++)
        {
            listP2.Add((PokeType)Random.Range(0, System.Enum.GetNames(typeof(PokeType)).Length));
        }
    }

    private void LockUnlockSelection()
    {
        Button[] buttons = selectionPanel.GetComponentsInChildren<Button>();
        foreach (Button but in buttons)
        {
            but.interactable = !but.interactable;
        }
        undoButton.GetComponent<Button>().interactable = !undoButton.GetComponent<Button>().interactable;
    }

    private void LockUnlockEndPanel()
    {
        endPanel.SetActive(true);
        powersPanel.SetActive(false);
        endButton.SetActive(false);
    }

    public void LockUnlockPowers(bool locking, int points)
    {
        Button[] buttons = powersPanel.GetComponentsInChildren<Button>();

        if (locking == false)
        {
            foreach (Button but in buttons)
            {
                but.interactable = false;
            }
        }
        else
        {
            switch (points)
            {
                case 0:
                    buttons[0].interactable = true;
                    break;
                case 1:
                    buttons[0].interactable = true;
                    buttons[1].interactable = true;
                    break;
                case 2:
                    buttons[0].interactable = true;
                    buttons[1].interactable = true;
                    buttons[2].interactable = true;
                    break;
                default:
                    buttons[0].interactable = true;
                    buttons[1].interactable = true;
                    buttons[2].interactable = true;
                    buttons[3].interactable = true;
                    break;
            }
        }
        UpdatePowerPoints(points);
    }

    private void UpdatePowerPoints(int points)
    {
        for (int i = 0; i < powerPointsList.Count; i++)
        {
            if (i + 1> points)
            {
                powerPointsList[i].GetComponent<Image>().enabled = false;
            }
            else
            {
                powerPointsList[i].GetComponent<Image>().enabled = true;
            }
        }
    }

    private void AddToSelectionStack(int type, int number)
    {
        GameObject gO = new GameObject(((PokeType)type).ToString() + "Tower");
        gO.AddComponent<Image>();
        gO.GetComponent<Image>().sprite = transform.GetComponent<ConstDataScript>().GetTowerSprite((PokeType)type);
        gO.GetComponent<RectTransform>().SetParent(selectionPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.25f, 1.25f, 1.25f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.0f, 1.0f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(90.0f, 90.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(-110.0f, ((110.0f * number) - 360.0f), 0.0f);
        gO.SetActive(true);
        selectionList.Add(gO);
        undoButton.GetComponent<Button>().interactable = true;
    }

    private void UndoSeletion()
    {
        gameObject.GetComponent<SoundScriptPT>().PlaySound(Sounds.UNDO);
        listP1.RemoveAt(listP1.Count - 1);
        GameObject gO = selectionList[selectionList.Count - 1];
        selectionList.Remove(gO);
        Destroy(gO);
        if (selectionList.Count == 0)
            undoButton.GetComponent<Button>().interactable = false;
        if (selectionList.Count == transform.GetComponent<GameManagerScriptPT>().GetNumberOfTowers() - 1)
            LockUnlockSelection();
    }

    private void SetUpButtons()
    {
        ColorBlock cB;
        GameObject gO;
        //Selection buttons
        for (int i = 0; i < System.Enum.GetNames(typeof(PokeType)).Length; i++)
        {
            int x = i % 4;
            int y = i / 4;
            int n = i;
            gO = new GameObject("Select" + ((PokeType)i).ToString());
            gO.AddComponent<Image>();
            gO.AddComponent<Button>();
            gO.GetComponent<Image>().sprite = transform.GetComponent<ConstDataScript>().GetAttackSprite((PokeType)i);
            gO.GetComponent<RectTransform>().SetParent(selectionPanel.transform);
            gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
            gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 1.0f);
            gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.0f, 1.0f);
            gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            gO.GetComponent<RectTransform>().sizeDelta = new Vector3(70.0f, 70.0f);
            gO.GetComponent<RectTransform>().anchoredPosition = new Vector3((x * 80.0f) + 40, (y * (-80.0f)) - 40, 0.0f);
            cB = gO.GetComponent<Button>().colors;
            cB.highlightedColor = selectionColor;
            gO.GetComponent<Button>().colors = cB;
            gO.GetComponent<Button>().onClick.AddListener(delegate { AddToList(n); });
            gO.SetActive(true);
        } 
        
        //Start button
        startButton = new GameObject("StartButton");
        startButton.AddComponent<Image>();
        startButton.AddComponent<Button>();
        startButton.GetComponent<Image>().sprite = startButtonSprite;
        startButton.GetComponent<RectTransform>().SetParent(selectionPanel.transform);
        startButton.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        startButton.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 1.0f);
        startButton.GetComponent<RectTransform>().anchorMax = new Vector2(0.0f, 1.0f);
        startButton.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        startButton.GetComponent<RectTransform>().sizeDelta = new Vector3(70.0f, 70.0f);
        startButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(200.0f, -360.0f, 0.0f);
        startButton.GetComponent<Button>().interactable = false;
        cB = startButton.GetComponent<Button>().colors;
        cB.highlightedColor = selectionColor;
        startButton.GetComponent<Button>().colors = cB;
        startButton.GetComponent<Button>().onClick.AddListener(StartGame);
        startButton.SetActive(true);

        //Undo button
        undoButton = new GameObject("UndoButton");
        undoButton.AddComponent<Image>();
        undoButton.AddComponent<Button>();
        undoButton.GetComponent<Image>().sprite = undoButtonSprite;
        undoButton.GetComponent<RectTransform>().SetParent(selectionPanel.transform);
        undoButton.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        undoButton.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 1.0f);
        undoButton.GetComponent<RectTransform>().anchorMax = new Vector2(0.0f, 1.0f);
        undoButton.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        undoButton.GetComponent<RectTransform>().sizeDelta = new Vector3(70.0f, 70.0f);
        undoButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(280.0f, -360.0f, 0.0f);
        undoButton.GetComponent<Button>().interactable = false;
        cB = startButton.GetComponent<Button>().colors;
        cB.highlightedColor = selectionColor;
        undoButton.GetComponent<Button>().colors = cB;
        undoButton.GetComponent<Button>().onClick.AddListener(UndoSeletion);
        undoButton.SetActive(true);

        //Power buttons
        //Attack button
            gO = new GameObject("AttackButton");
            gO.AddComponent<Image>();
            gO.AddComponent<Button>();
            gO.GetComponent<Image>().sprite = attackButtonSprite;
            gO.GetComponent<RectTransform>().SetParent(powersPanel.transform);
            gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
            gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
            gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
            gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            gO.GetComponent<RectTransform>().sizeDelta = new Vector3(80.0f, 80.0f);
            gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(-135.0f, 0.0f, 0.0f);
            gO.GetComponent<Button>().onClick.AddListener(delegate{
                transform.GetComponent<GameManagerScriptPT>().ChangeState(new IAttackStatePT());
            });
            gO.GetComponent<Button>().interactable = false;

        //Swap button
        gO = new GameObject("SwapButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = swapButtonSprite;
        gO.GetComponent<RectTransform>().SetParent(powersPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(80.0f, 80.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(-45.0f, 0.0f, 0.0f);
        gO.GetComponent<Button>().onClick.AddListener(delegate {
            transform.GetComponent<GameManagerScriptPT>().ChangeState(new ISwapStatePT());
        });
        gO.GetComponent<Button>().interactable = false;

        //Change button
        gO = new GameObject("ChangeButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = changeButtonSprite;
        gO.GetComponent<RectTransform>().SetParent(powersPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(80.0f, 80.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(45.0f, 0.0f, 0.0f);
        gO.GetComponent<Button>().onClick.AddListener(delegate {
            transform.GetComponent<GameManagerScriptPT>().ChangeState(new IChangeTowerStatePT());
        });
        gO.GetComponent<Button>().interactable = false;

        //Heal button
        gO = new GameObject("HealButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = healButtonSprite;
        gO.GetComponent<RectTransform>().SetParent(powersPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(80.0f, 80.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(135.0f, 0.0f, 0.0f);
        gO.GetComponent<Button>().onClick.AddListener(delegate {
            transform.GetComponent<GameManagerScriptPT>().ChangeState(new IHealStatePT());
        });
        gO.GetComponent<Button>().interactable = false;



        //End panel buttons
        //Play button
        gO = new GameObject("PlayButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = playButtonSprite;
        gO.GetComponent<RectTransform>().SetParent(endPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(100.0f, 100.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(80.0f, 0.0f, 0.0f);
        cB = gO.GetComponent<Button>().colors;
        cB.highlightedColor = selectionColor;
        gO.GetComponent<Button>().colors = cB;
        gO.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene(SceneManager.GetActiveScene().name); });
        gO.SetActive(true);

        //Exit button
        gO = new GameObject("ExitButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = exitButtonSprite;
        gO.GetComponent<RectTransform>().SetParent(endPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(100.0f, 100.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(-80.0f, 0.0f, 0.0f);
        cB = gO.GetComponent<Button>().colors;
        cB.highlightedColor = selectionColor;
        gO.GetComponent<Button>().colors = cB;
        gO.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene("MainMenuScene"); });
        gO.SetActive(true);

        // exit buton in corner
        endButton = new GameObject("ExitButtonSmall");
        endButton.AddComponent<Image>();
        endButton.AddComponent<Button>();
        endButton.GetComponent<Image>().sprite = exitButtonSprite;
        endButton.GetComponent<RectTransform>().SetParent(gui.transform);
        endButton.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        endButton.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 1.0f);
        endButton.GetComponent<RectTransform>().anchorMax = new Vector2(0.0f, 1.0f);
        endButton.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        endButton.GetComponent<RectTransform>().sizeDelta = new Vector3(80.0f, 80.0f);
        endButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(45.0f, -45.0f, 0.0f);
        cB = gO.GetComponent<Button>().colors;
        cB.highlightedColor = selectionColor;
        endButton.GetComponent<Button>().colors = cB;
        endButton.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene("MainMenuScene"); });
        endButton.SetActive(true);
    }

    private void SetUpPanel()
    {
        //Selection panel
        selectionPanel = new GameObject("SelectionPanel");
        selectionPanel.AddComponent<RectTransform>();
        selectionPanel.GetComponent<RectTransform>().SetParent(gui.transform);
        selectionPanel.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        selectionPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        selectionPanel.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        selectionPanel.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        selectionPanel.GetComponent<RectTransform>().sizeDelta = new Vector3(400.0f, 400.0f);
        selectionPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(100.0f, 0.0f, 0.0f);
        selectionPanel.SetActive(true);

        //Power panel
        powersPanel = new GameObject("PowersPanel");
        powersPanel.AddComponent<RectTransform>();
        powersPanel.GetComponent<RectTransform>().SetParent(gui.transform);
        powersPanel.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        powersPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1.0f);
        powersPanel.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1.0f);
        powersPanel.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        powersPanel.GetComponent<RectTransform>().sizeDelta = new Vector3(400.0f, 100.0f);
        powersPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, -50.0f, 0.0f);
        powersPanel.SetActive(false);

        //End panel
        endPanel = new GameObject("EndPanel");
        endPanel.AddComponent<RectTransform>();
        endPanel.GetComponent<RectTransform>().SetParent(gui.transform);
        endPanel.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        endPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        endPanel.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        endPanel.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        endPanel.GetComponent<RectTransform>().sizeDelta = new Vector3(300.0f, 300.0f);
        endPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
        endPanel.SetActive(false);

        //text panel
        textPanel = new GameObject("Text");
        textPanel.AddComponent<Text>();
        textPanel.GetComponent<RectTransform>().SetParent(gui.transform);
        textPanel.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        textPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        textPanel.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        textPanel.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        textPanel.GetComponent<RectTransform>().sizeDelta = new Vector3(500.0f, 80.0f);
        textPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
        textPanel.GetComponent<Text>().font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        textPanel.GetComponent<Text>().fontStyle = FontStyle.BoldAndItalic;
        textPanel.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        textPanel.GetComponent<Text>().resizeTextForBestFit = true;
        textPanel.GetComponent<Text>().color = new Color32(50, 50, 50, 255);
        textPanel.GetComponent<Text>().resizeTextMinSize = 0;
        textPanel.GetComponent<Text>().resizeTextMaxSize = 300;
        textPanel.SetActive(false);
    }

    private void SetUpPowerPoints()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject gO = new GameObject("PowerPoint");
            gO.AddComponent<Image>();
            gO.GetComponent<Image>().sprite = powerPoint;
            gO.GetComponent<Image>().enabled = false;
            gO.GetComponent<RectTransform>().SetParent(powersPanel.transform);
            gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
            gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
            gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
            gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            gO.GetComponent<RectTransform>().sizeDelta = new Vector3(40.0f, 40.0f);
            gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(((i - 2) * 45.0f), -55.0f, 0.0f);
            gO.SetActive(true);
            powerPointsList.Add(gO);
        }
    }
}
