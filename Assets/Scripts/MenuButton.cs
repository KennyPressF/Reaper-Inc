using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuButton : MonoBehaviour
{
    [SerializeField] Image menuIcon;
    [SerializeField] Sprite accountIcon;
    [SerializeField] Sprite criteriaIcon;
    [SerializeField] Sprite settingsIcon;
    [SerializeField] TextMeshProUGUI menuText;
    [SerializeField] GameObject notificationBell;

    [SerializeField] public GameObject dropdownMenu;
    [SerializeField] public GameObject accountScreen;
    [SerializeField] public GameObject criteriaScreen;
    [SerializeField] TextMeshProUGUI criteriaText;
    [SerializeField] public GameObject helpScreen;
    [SerializeField] public GameObject fadeScreen;

    ScreenManager appManager;
    CasefileManager casefileManager;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        appManager = GetComponent<ScreenManager>();
        casefileManager = FindObjectOfType<CasefileManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        menuIcon.sprite = accountIcon;
        menuText.text = "Account";

        accountScreen.SetActive(true);
        criteriaScreen.SetActive(false);
        helpScreen.SetActive(false);
        dropdownMenu.SetActive(false);
        fadeScreen.SetActive(false);
    }

    public void ToggleDropdownMenu()
    {
        AudioManager.instance.PlaySFX(0);

        if (dropdownMenu.activeSelf == false)
        {
            dropdownMenu.SetActive(true);
            fadeScreen.SetActive(true);
        }
        else if (dropdownMenu.activeSelf == true)
        {
            dropdownMenu.SetActive(false);
            fadeScreen.SetActive(false);
        }

        if (notificationBell.activeSelf == true)
        {
            criteriaText.color = Color.red;
        }
        else if (notificationBell.activeSelf == false)
        {
            criteriaText.color = new Color32(50, 50, 50, 255);
        }
    }

    public void ToggleNotificationBell()
    {
        if(casefileManager.newRuleToSee == true)
        {
            notificationBell.SetActive(true);
            AudioManager.instance.PlaySFX(4);
        }

        else if (casefileManager.newRuleToSee == false)
        {
            notificationBell.SetActive(false);
        }
    }

    public void GoToAccountScreen()
    {
        AudioManager.instance.PlaySFX(0);

        scoreKeeper.timerIsActive = true;

        menuIcon.sprite = accountIcon;
        menuText.text = "Account";

        accountScreen.SetActive(true);
        criteriaScreen.SetActive(false);
        helpScreen.SetActive(false);
        ToggleDropdownMenu();
    }

    public void GoToCriteriaScreen()
    {
        AudioManager.instance.PlaySFX(0);

        scoreKeeper.timerIsActive = true;

        menuIcon.sprite = criteriaIcon;
        menuText.text = "Criteria";

        accountScreen.SetActive(false);
        criteriaScreen.SetActive(true);
        helpScreen.SetActive(false);
        ToggleDropdownMenu();

        casefileManager.newRuleToSee = false;
        ToggleNotificationBell();
    }

    public void GoToSettingsScreen()
    {
        AudioManager.instance.PlaySFX(0);

        scoreKeeper.timerIsActive = false;

        menuIcon.sprite = settingsIcon;
        menuText.text = "Settings";

        accountScreen.SetActive(false);
        criteriaScreen.SetActive(false);
        helpScreen.SetActive(true);

        ToggleDropdownMenu();
    }

    public void LogOut()
    {
        AudioManager.instance.PlaySFX(0);
        ToggleDropdownMenu();
        appManager.QuitReapingScreen();
    }
}
