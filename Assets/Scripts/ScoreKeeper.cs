using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] Image profilePicture;
    [SerializeField] TextMeshProUGUI menuButtonText;
    [SerializeField] Button menuButton;

    [Header("Quota")]
    [SerializeField] TextMeshProUGUI quotaText;
    [SerializeField] public int quota;
    [SerializeField] public int maxQuota;
    [SerializeField] int quotaBeforeRuleChange;
    [SerializeField] int baseQuotaBeforeRuleChange;

    [Header("Cash")]
    [SerializeField] TextMeshProUGUI cashText;
    [SerializeField] int currentCash;
    [SerializeField] int correctAnswerValue;
    [SerializeField] int wrongAnswerValue;

    [Header("Timer")]
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float timeRemaining;
    [SerializeField] public float maxTime;
    [SerializeField] public bool timerIsActive;
    Color activeColour = Color.white;
    Color fadedColour = new Color(1, 1, 1, 0.5f);

    [Header("End Screen")]
    [SerializeField] public GameObject endScreen;
    [SerializeField] TextMeshProUGUI endTitleText;
    [SerializeField] TextMeshProUGUI endQuotaText;
    [SerializeField] TextMeshProUGUI endMoneyText;
    [SerializeField] TextMeshProUGUI endScoreText;
    [SerializeField] int finalScore;


    [Header("Buttons")]
    [SerializeField] Button heavenButton;
    [SerializeField] Button hellButton;

    CasefileManager casefileManager;
    ScreenManager screenManager;
    HighScore highScore;

    private void Awake()
    {
        casefileManager = GetComponent<CasefileManager>();
        screenManager = FindObjectOfType<ScreenManager>();
        highScore = GetComponent<HighScore>();
    }

    public void StartScoreKeeper()
    {
        heavenButton.interactable = true;
        hellButton.interactable = true;

        quotaText.text = quota + "/" + maxQuota;
        cashText.text = currentCash + " $";

        timeRemaining = maxTime;
        timerIsActive = true;

        baseQuotaBeforeRuleChange = Random.Range(4, 7);
        quotaBeforeRuleChange = baseQuotaBeforeRuleChange;
    }

    public void StopScoreKeeper()
    {
        {
            quota = 0;
            quotaText.text = quota + "/" + maxQuota;
            currentCash = 0;
            cashText.text = currentCash + " $";

            timerIsActive = false;
            timeRemaining = maxTime;
        }
    }

    private void Update()
    {
        HandleTimer();

        if (endScreen.activeSelf == true)
        {
            menuButton.interactable = false;
        }
        else
        {
            menuButton.interactable = true;
        }
    }

    private void ShowEndScreen()
    {
        endScreen.SetActive(true);

        if (quota >= maxQuota)
        {
            endTitleText.text = "QUOTA FULFILLED";
        }
        if (quota < maxQuota)
        {
            endTitleText.text = "TIME'S UP!";
        }

        endQuotaText.text = quota + "/" + maxQuota;
        endMoneyText.text = currentCash + "$";
        finalScore = currentCash * PlayerPrefs.GetInt("Difficulty");
        endScoreText.text = finalScore.ToString();
    }

    public void HideEndScreen()
    {
        highScore.SetHighScore(finalScore);
        screenManager.QuitReapingScreen();
        endScreen.SetActive(false);
    }

    public void AddToQuota()
    {
        quota++;
        
        if(quota > maxQuota)
        {
            quota = maxQuota;
            heavenButton.interactable = false;
            hellButton.interactable = false;
            timerIsActive = false;
            ShowEndScreen();
        }

        quotaText.text = quota + "/" + maxQuota;

        if (quota < maxQuota)
        {
            if (quota - 1 == quotaBeforeRuleChange) //quota starts on 1 so -1 is needed here
            {
                casefileManager.ChangeCurrentRule();
                baseQuotaBeforeRuleChange = Random.Range(4, 7);
                quotaBeforeRuleChange += baseQuotaBeforeRuleChange;
            }
        }
    }
    
    public void AddToCash()
    {
        currentCash += correctAnswerValue;
        cashText.text = currentCash + " $";
    }

    public void LoseCash()
    {
        currentCash -= wrongAnswerValue;

        if(currentCash <= 0)
        {
            currentCash = 0;
        }

        cashText.text = currentCash + " $";
    }

    private void HandleTimer()
    {
        timeText.text = timeRemaining.ToString("000");

        if (timerIsActive == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            else if (timeRemaining <= 0)
            {
                timerIsActive = false;
                heavenButton.interactable = false;
                hellButton.interactable = false;
                ShowEndScreen();
            }

            timeText.color = activeColour;
        }

        else if (timerIsActive == false)
        {
            timeText.color = fadedColour;
        }
    }
}
