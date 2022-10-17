using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesGenerator : MonoBehaviour
{
    [Header("Deed Value")]
    [SerializeField] int minThreshold;
    [SerializeField] int maxThreshold;
    int deedValueThreshold;

    [Header("Rules")]
    public AutoRule currentAutoRule;
    public enum AutoRule { Gender, BirthMonth, HairColour, EyeColour, AboveSixFoot, Before2000, Before1990, Before1980 }
    public bool autoIsForHeaven;

    [Header("Gender")]
    public string autoGender;

    [Header("Birth Month")]
    [SerializeField] string[] autoRuleBirthMonths;
    int randomMonthIndex;
    public string autoMonth;

    [Header("Hair Colour")]
    [SerializeField] string[] autoRuleHairColours;
    int randomHairIndex;
    public string autoHair;

    [Header("Eye Colour")]
    [SerializeField] string[] autoRuleEyeColours;
    int randomEyeIndex;
    public string autoEye;

    CasefileManager casefileManager;
    ProfileGenerator profileGenerator;
    RulesScreen rulesScreen;
    Randomiser randomiser;

    private void Awake()
    {
        casefileManager = GetComponent<CasefileManager>();
        profileGenerator = GetComponent<ProfileGenerator>();
        rulesScreen = FindObjectOfType<RulesScreen>();
        randomiser = GetComponent<Randomiser>();
    }

    public int GetNewThreshold()
    {
        deedValueThreshold = Random.Range(minThreshold, maxThreshold);

        int thresholdCoinFlip = randomiser.FlipACoin();

        if(thresholdCoinFlip <= 50)
        {
            deedValueThreshold = -deedValueThreshold;
        }
        else
        {
            deedValueThreshold = +deedValueThreshold;
        }

        rulesScreen.UpdateThresholdText(deedValueThreshold);

        return deedValueThreshold;
    }

    public void GetNewAutoRule()
    {
        //Random Rule
        int randomAutoRuleIndex = Random.Range(0, 7);
        currentAutoRule = (AutoRule)randomAutoRuleIndex;
        
        //Heaven Or Hell
        int heavenOrHellCoinFlip = randomiser.FlipACoin();
        {
            if (heavenOrHellCoinFlip <= 50)
            {
                autoIsForHeaven = true;
            }
            else
            {
                autoIsForHeaven = false;
            }
        }

        //Gender Rule Setup
        int genderCoinFlip = randomiser.FlipACoin();
        if (genderCoinFlip <= 50)
        {
            autoGender = "Male";
        }
        else
        {
            autoGender = "Female";
        }

        //Birth Month Rule Setup
        randomMonthIndex = Random.Range(0, autoRuleBirthMonths.Length);
        autoMonth = autoRuleBirthMonths[randomMonthIndex];

        //Hair Rule Setup
        randomHairIndex = Random.Range(0, autoRuleHairColours.Length);
        autoHair = autoRuleHairColours[randomHairIndex];

        //Eye Rule Setup
        randomEyeIndex = Random.Range(0, autoRuleEyeColours.Length);
        autoEye = autoRuleEyeColours[randomEyeIndex];

        //Update Rules Screen
        rulesScreen.MatchRuleCase();
        rulesScreen.ResetAllRuleTexts();
        rulesScreen.DisplayCurrentRule();
    }

    public void CheckAutoRule()
    {
        switch (currentAutoRule)
        {
            case AutoRule.Gender:

                string profileGender = profileGenerator.currentProfile.gender.ToString();

                if (profileGender == autoGender)
                {
                    if (autoIsForHeaven == true)
                    {
                        casefileManager.autoHeaven = true;
                        casefileManager.autoHell = false;
                    }
                    else
                    {
                        casefileManager.autoHeaven = false;
                        casefileManager.autoHell = true;
                    }
                }
                else
                {
                    casefileManager.autoHeaven = false;
                    casefileManager.autoHell = false;
                }

                break;

            case AutoRule.BirthMonth:

                string profileBirthMonth = profileGenerator.currentProfile.birthMonth.ToString();
                
                if (profileBirthMonth == autoMonth)
                {
                    if (autoIsForHeaven == true)
                    {
                        casefileManager.autoHeaven = true;
                        casefileManager.autoHell = false;
                    }
                    else
                    {
                        casefileManager.autoHeaven = false;
                        casefileManager.autoHell = true;
                    }
                }
                else
                {
                    casefileManager.autoHeaven = false;
                    casefileManager.autoHell = false;
                }

                Debug.Log(profileBirthMonth);
                Debug.Log(autoMonth);

                break;

            case AutoRule.HairColour:

                string profileHairColour = profileGenerator.currentProfile.hairColour.ToString();

                if (profileHairColour == autoHair)
                {
                    if (autoIsForHeaven == true)
                    {
                        casefileManager.autoHeaven = true;
                        casefileManager.autoHell = false;
                    }
                    else
                    {
                        casefileManager.autoHeaven = false;
                        casefileManager.autoHell = true;
                    }
                }
                else
                {
                    casefileManager.autoHeaven = false;
                    casefileManager.autoHell = false;
                }

                Debug.Log(profileHairColour);
                Debug.Log(autoHair);

                break;

            case AutoRule.EyeColour:

                string profileEyeColour = profileGenerator.currentProfile.eyeColour.ToString();

                if (profileEyeColour == autoEye)
                {
                    if (autoIsForHeaven == true)
                    {
                        casefileManager.autoHeaven = true;
                        casefileManager.autoHell = false;
                    }
                    else
                    {
                        casefileManager.autoHeaven = false;
                        casefileManager.autoHell = true;
                    }
                }
                else
                {
                    casefileManager.autoHeaven = false;
                    casefileManager.autoHell = false;
                }

                Debug.Log(profileEyeColour);
                Debug.Log(autoEye);

                break;

            case AutoRule.AboveSixFoot:

                if (profileGenerator.currentProfile.isAboveSixFoot == true)
                {
                    if (autoIsForHeaven == true)
                    {
                        casefileManager.autoHeaven = true;
                        casefileManager.autoHell = false;
                    }
                    else
                    {
                        casefileManager.autoHeaven = false;
                        casefileManager.autoHell = true;
                    }
                }
                else
                {
                    casefileManager.autoHeaven = false;
                    casefileManager.autoHell = false;
                }

                break;

            case AutoRule.Before2000:

                if (profileGenerator.currentProfile.bornBefore2000 == true)
                {
                    if (autoIsForHeaven == true)
                    {
                        casefileManager.autoHeaven = true;
                        casefileManager.autoHell = false;
                    }
                    else
                    {
                        casefileManager.autoHeaven = false;
                        casefileManager.autoHell = true;
                    }
                }
                else
                {
                    casefileManager.autoHeaven = false;
                    casefileManager.autoHell = false;
                }

                break;

            case AutoRule.Before1990:

                if (profileGenerator.currentProfile.bornBefore1990 == true)
                {
                    if (autoIsForHeaven == true)
                    {
                        casefileManager.autoHeaven = true;
                        casefileManager.autoHell = false;
                    }
                    else
                    {
                        casefileManager.autoHeaven = false;
                        casefileManager.autoHell = true;
                    }
                }
                else
                {
                    casefileManager.autoHeaven = false;
                    casefileManager.autoHell = false;
                }

                break;

            case AutoRule.Before1980:

                if (profileGenerator.currentProfile.bornBefore1980 == true)
                {
                    if (autoIsForHeaven == true)
                    {
                        casefileManager.autoHeaven = true;
                        casefileManager.autoHell = false;
                    }
                    else
                    {
                        casefileManager.autoHeaven = false;
                        casefileManager.autoHell = true;
                    }
                }
                else
                {
                    casefileManager.autoHeaven = false;
                    casefileManager.autoHell = false;
                }

                break;
        }
    }
}
