using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScriptPT : MonoBehaviour
{

    private int spriteIndex;
    private float soundLevel;
    private GameObject mainPanel;
    private GameObject howToPlayPanel;
    private GameObject optionsPanel;
    private GameObject slider;

    public Sprite backgrounSprite;
    public Sprite startSprite;
    public Sprite optionsSprite;
    public Sprite howToPlaySprite;
    public Sprite exitSprite;
    public Sprite nextSprite;
    public Sprite backSprite;
    public Sprite applySprite;
    public Sprite sliderSprite;

    public List<Sprite> helpPanelSprites;
    public AudioClip buttonSound;
    // Use this for initialization
    void Start ()
    {
        SetSoundLevel();
        SetUpBackground();
        SetUpMenuPanels();
        SetUpButtons();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SetUpBackground()
    {
        gameObject.AddComponent<Image>();
        gameObject.GetComponent<Image>().sprite = backgrounSprite;
    }

    private void SetUpMenuPanels()
    {
        //Main panel
        mainPanel = new GameObject("MainPanel");
        mainPanel.AddComponent<RectTransform>();
        mainPanel.GetComponent<RectTransform>().SetParent(transform);
        mainPanel.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        mainPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        mainPanel.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        mainPanel.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        mainPanel.GetComponent<RectTransform>().sizeDelta = new Vector3(300.0f, 300.0f);
        mainPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, 0.0f);
        mainPanel.SetActive(true);

        //How To Play Panel
        spriteIndex = 0;
        howToPlayPanel = new GameObject("HowToPlayPanel");
        howToPlayPanel.AddComponent<RectTransform>();
        howToPlayPanel.AddComponent<Image>();
        howToPlayPanel.GetComponent<Image>().sprite = helpPanelSprites[spriteIndex];
        howToPlayPanel.GetComponent<RectTransform>().SetParent(transform);
        howToPlayPanel.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        howToPlayPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 0.0f);
        howToPlayPanel.GetComponent<RectTransform>().anchorMax = new Vector2(1.0f, 1.0f);
        howToPlayPanel.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        howToPlayPanel.GetComponent<RectTransform>().offsetMin = new Vector2(0.0f, 0.0f);
        howToPlayPanel.GetComponent<RectTransform>().offsetMax = new Vector2(0.0f, 0.0f);
        howToPlayPanel.SetActive(false);

        //options panel
        optionsPanel = new GameObject("OptionsPanel");
        optionsPanel.AddComponent<Image>().sprite = backSprite;
        optionsPanel.GetComponent<RectTransform>().SetParent(transform);
        optionsPanel.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        optionsPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        optionsPanel.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        optionsPanel.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        optionsPanel.GetComponent<RectTransform>().sizeDelta = new Vector3(300.0f, 300.0f);
        optionsPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, 0.0f);
        optionsPanel.SetActive(false);
    }

    private void SetUpButtons()
    {
        GameObject gO;
        //Main Panel buttons
        //how to play button
        gO = new GameObject("HowToPlayButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = howToPlaySprite;
        gO.GetComponent<RectTransform>().SetParent(mainPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.0f, 1.0f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(120.0f, 120.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3( 75.0f, -75.0f, 0.0f);
        gO.GetComponent<Button>().onClick.AddListener(delegate {
            gameObject.GetComponent<AudioSource>().PlayOneShot(buttonSound);
            howToPlayPanel.SetActive(true);
            mainPanel.SetActive(false);
        });

        //start button
        gO = new GameObject("StartButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = startSprite;
        gO.GetComponent<RectTransform>().SetParent(mainPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(1.0f, 1.0f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(120.0f, 120.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(-75.0f, -75.0f, 0.0f);
        gO.GetComponent<Button>().onClick.AddListener(delegate {
            SceneManager.LoadScene("GameScene");
        });

        //options button
        gO = new GameObject("OptionsButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = optionsSprite;
        gO.GetComponent<RectTransform>().SetParent(mainPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 0.0f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.0f, 0.0f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(120.0f, 120.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(75.0f, 75.0f, 0.0f);
        gO.GetComponent<Button>().onClick.AddListener(delegate {
            gameObject.GetComponent<AudioSource>().PlayOneShot(buttonSound);
            optionsPanel.SetActive(true);
            mainPanel.SetActive(false);
        });

        //exit button
        gO = new GameObject("ExitButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = exitSprite;
        gO.GetComponent<RectTransform>().SetParent(mainPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(1.0f, 0.0f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(1.0f, 0.0f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(120.0f, 120.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(-75.0f, 75.0f, 0.0f);
        gO.GetComponent<Button>().onClick.AddListener(delegate {
            Application.Quit();
        });

        //How To Play Panel buttons
        //next button
        gO = new GameObject("NextButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = nextSprite;
        gO.GetComponent<RectTransform>().SetParent(howToPlayPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(1.0f, 0.0f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(1.0f, 0.0f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(120.0f, 120.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(-75.0f, 75.0f, 0.0f);
        gO.GetComponent<Button>().onClick.AddListener(delegate {
            gameObject.GetComponent<AudioSource>().PlayOneShot(buttonSound);
            if (spriteIndex + 1 < helpPanelSprites.Count)
            {
                spriteIndex++;
                howToPlayPanel.GetComponent<Image>().sprite = helpPanelSprites[spriteIndex];
            }
            else
            {
                spriteIndex = 0;
                howToPlayPanel.GetComponent<Image>().sprite = helpPanelSprites[spriteIndex];
                howToPlayPanel.SetActive(false);
                mainPanel.SetActive(true);
            }
        });

        //previous button
        gO = new GameObject("PreviousButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = nextSprite;
        gO.GetComponent<RectTransform>().SetParent(howToPlayPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 0.0f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.0f, 0.0f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(120.0f, 120.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(75.0f, 75.0f, 0.0f);
        gO.GetComponent<Button>().onClick.AddListener(delegate {
            gameObject.GetComponent<AudioSource>().PlayOneShot(buttonSound);
            if (spriteIndex - 1 >= 0)
            {
                spriteIndex--;
                howToPlayPanel.GetComponent<Image>().sprite = helpPanelSprites[spriteIndex];
            }
        });

        // option panel buttons
        //sound slider
        slider = DefaultControls.CreateSlider(new DefaultControls.Resources());
        slider.GetComponent<Slider>().minValue = 0.0f;
        slider.GetComponent<Slider>().maxValue = 1.0f;
        slider.GetComponent<Slider>().value = soundLevel;
        slider.GetComponent<RectTransform>().SetParent(optionsPanel.transform);
        slider.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        slider.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1.0f);
        slider.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1.0f);
        slider.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        slider.GetComponent<RectTransform>().sizeDelta = new Vector3(140.0f, 40.0f);
        slider.GetComponent<RectTransform>().anchoredPosition = new Vector3(50.0f, -60.0f, 0.0f);

        Image[] img = slider.GetComponentsInChildren<Image>();
        img[0].sprite = sliderSprite;
        img[0].color = new Color32(150, 150, 150, 255);
        img[1].sprite = sliderSprite;
        img[2].sprite = sliderSprite;

        slider.GetComponent<Slider>().onValueChanged.AddListener(delegate {
            UpdateSoundLevel(slider.GetComponent<Slider>().value);
        });

        //text near slider
        gO = new GameObject("SliderTxt");
        gO.AddComponent<Text>();
        gO.GetComponent<RectTransform>().SetParent(optionsPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1.0f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(100.0f, 40.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(-70.0f, -60.0f, 0.0f);
        gO.GetComponent<Text>().text = "Sound";
        gO.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        gO.GetComponent<Text>().fontStyle = FontStyle.BoldAndItalic;
        gO.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        gO.GetComponent<Text>().resizeTextForBestFit = true;
        gO.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        //apply buton
        gO = new GameObject("ApplyButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = applySprite;
        gO.GetComponent<RectTransform>().SetParent(optionsPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.0f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.0f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(100.0f, 100.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(55.0f, 100.0f, 0.0f);
        gO.GetComponent<Button>().onClick.AddListener(delegate {
            gameObject.GetComponent<AudioSource>().PlayOneShot(buttonSound);
            PlayerPrefs.SetFloat("SoundLevelPT", soundLevel);
            optionsPanel.SetActive(false);
            mainPanel.SetActive(true);
        });

        //return button
        gO = new GameObject("BackButton");
        gO.AddComponent<Image>();
        gO.AddComponent<Button>();
        gO.GetComponent<Image>().sprite = exitSprite;
        gO.GetComponent<RectTransform>().SetParent(optionsPanel.transform);
        gO.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gO.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.0f);
        gO.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.0f);
        gO.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        gO.GetComponent<RectTransform>().sizeDelta = new Vector3(100.0f, 100.0f);
        gO.GetComponent<RectTransform>().anchoredPosition = new Vector3(-55.0f, 100.0f, 0.0f);
        gO.GetComponent<Button>().onClick.AddListener(delegate {
            UpdateSoundLevel(PlayerPrefs.GetFloat("SoundLevelPT"));
            gameObject.GetComponent<AudioSource>().PlayOneShot(buttonSound);
            optionsPanel.SetActive(false);
            mainPanel.SetActive(true);
        });
    }

    private void UpdateSoundLevel(float soundLvl)
    {
        soundLevel = soundLvl;
        transform.GetComponent<AudioSource>().volume = soundLvl;
    }

    private void SetSoundLevel()
    {
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().playOnAwake = false;
        gameObject.GetComponent<AudioSource>().clip = buttonSound;
        if (PlayerPrefs.HasKey("SoundLevelPT"))
        {
            UpdateSoundLevel(PlayerPrefs.GetFloat("SoundLevelPT"));
        }
        else
        {
            UpdateSoundLevel(1.0f);
            PlayerPrefs.SetFloat("SoundLevelPT", 1.0f);
        }
    }
}
