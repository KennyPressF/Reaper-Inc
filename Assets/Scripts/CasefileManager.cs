using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CasefileManager : MonoBehaviour
{
    [SerializeField] int currentDeedTotal;
    [SerializeField] int currentDeedValueThreshold;
    public bool autoHeaven;
    public bool autoHell;
    public bool newRuleToSee;

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject fireEffect;
    [SerializeField] Transform wingsPoint;
    [SerializeField] GameObject wingsEffect;

    ProfileGenerator profileGenerator;
    DeedGenerator deedGenerator;
    RulesGenerator rulesGenerator;
    MenuButton menuButton;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        profileGenerator = GetComponent<ProfileGenerator>();
        deedGenerator = GetComponent<DeedGenerator>();
        rulesGenerator = GetComponent<RulesGenerator>();
        menuButton = FindObjectOfType<MenuButton>();
        scoreKeeper = GetComponent<ScoreKeeper>();
    }

    public void StartReaping()
    {
        {
            profileGenerator.ResetAllProfiles();
            ChangeCurrentRule();
            LoadNewCasefile();
        }
    }

    private void LoadNewCasefile()
    {
        scoreKeeper.AddToQuota();

        if (scoreKeeper.quota < scoreKeeper.maxQuota)
        {
            profileGenerator.GetRandomProfile();
            deedGenerator.GetRandomDeeds();
            rulesGenerator.CheckAutoRule();
            currentDeedTotal = deedGenerator.CalculateTotalValue();
        }
    }

    public void ChangeCurrentRule()
    {
        newRuleToSee = true;
        menuButton.ToggleNotificationBell();
        rulesGenerator.GetNewAutoRule();
        currentDeedValueThreshold = rulesGenerator.GetNewThreshold();
    }

    public void SendToHeaven()
    {
        if (autoHeaven == true)
        {
            scoreKeeper.AddToCash();
            AudioManager.instance.PlaySFX(1);
        }

        else if (autoHell == true)
        {
            scoreKeeper.LoseCash();
            AudioManager.instance.PlaySFX(3);
        }

        else if (autoHeaven == false)
        {
            if (currentDeedTotal >= currentDeedValueThreshold)
            {
                scoreKeeper.AddToCash();
                AudioManager.instance.PlaySFX(1);
            }

            else if (currentDeedTotal < currentDeedValueThreshold)
            {
                scoreKeeper.LoseCash();
                AudioManager.instance.PlaySFX(3);
            }
        }

        Instantiate(wingsEffect, wingsPoint.position, Quaternion.identity);
        LoadNewCasefile();
    }

    public void SendToHell()
    {
        if (autoHeaven == true)
        {
            scoreKeeper.LoseCash();
            AudioManager.instance.PlaySFX(3);
        }

        else if (autoHell == true)
        {
            scoreKeeper.AddToCash();
            AudioManager.instance.PlaySFX(2);
        }

        else if (autoHell == false)
        {
            if (currentDeedTotal < currentDeedValueThreshold)
            {
                scoreKeeper.AddToCash();
                AudioManager.instance.PlaySFX(2);
            }

            else if (currentDeedTotal >= currentDeedValueThreshold)
            {
                scoreKeeper.LoseCash();
                AudioManager.instance.PlaySFX(3);
            }
        }

        Instantiate(fireEffect, firePoint.position, Quaternion.identity);
        LoadNewCasefile();
    }
}
