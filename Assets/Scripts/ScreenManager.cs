using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject startMenu;

    [SerializeField] GameObject reapingScreen;
    bool reaperScreenIsActive;

    [SerializeField] GameObject tutorialScreen;
    bool tutorialScreenIsActive;

    [SerializeField] GameObject settingsScreen;
    bool settingsScreenIsActive;
    
    CasefileManager casefileManager;
    MenuButton menuButton;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        casefileManager = FindObjectOfType<CasefileManager>();
        menuButton = GetComponent<MenuButton>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        startMenu.SetActive(false);
        reapingScreen.SetActive(false);
        tutorialScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }

    public void ToggleStartMenu()
    {
        if (!reaperScreenIsActive && !tutorialScreenIsActive && !settingsScreenIsActive)
        {
            if (startMenu.activeSelf == true)
            {
                startMenu.SetActive(false);
                AudioManager.instance.PlaySFX(0);
            }
            else if (startMenu.activeSelf == false)
            {
                startMenu.SetActive(true);
                AudioManager.instance.PlaySFX(0);
            }
        }
    }

    public void LoadReapingScreen()
    {
        AudioManager.instance.PlaySFX(0);
        ToggleStartMenu();
        reapingScreen.SetActive(true);
        reaperScreenIsActive = true;

        menuButton.accountScreen.SetActive(true);
        menuButton.criteriaScreen.SetActive(false);
        menuButton.helpScreen.SetActive(false);
        menuButton.dropdownMenu.SetActive(false);
        menuButton.fadeScreen.SetActive(false);
        scoreKeeper.endScreen.SetActive(false);

        casefileManager.StartReaping();
        scoreKeeper.StartScoreKeeper();
    }

    public void QuitReapingScreen()
    {
        AudioManager.instance.PlaySFX(0);
        reapingScreen.SetActive(false);
        reaperScreenIsActive = false;
        scoreKeeper.StopScoreKeeper();
    }

    public void LoadTutorialScreen()
    {
        AudioManager.instance.PlaySFX(0);
        ToggleStartMenu();
        tutorialScreen.SetActive(true);
        tutorialScreenIsActive = true;
    }

    public void QuitTutorialScreen()
    {
        AudioManager.instance.PlaySFX(0);
        tutorialScreen.SetActive(false);
        tutorialScreenIsActive = false;
    }

    public void LoadSettingsScreen()
    {
        AudioManager.instance.PlaySFX(0);
        ToggleStartMenu();
        settingsScreen.SetActive(true);
        settingsScreenIsActive = true;
    }

    public void QuitSettingsScreen()
    {
        AudioManager.instance.PlaySFX(0);
        settingsScreen.SetActive(false);
        settingsScreenIsActive = false;
    }

    public void QuitGame()
    {
        AudioManager.instance.PlaySFX(0);
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
