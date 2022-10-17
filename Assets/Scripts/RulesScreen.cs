using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RulesScreen : MonoBehaviour
{
    [Header("Misc")]
    public RuleToMatch ruleToMatch;
    public enum RuleToMatch { Gender, BirthMonth, HairColour, EyeColour, AboveSixFoot, Before2000, Before1990, Before1980 }
    Color highlightedRuleColour = Color.green;
    Color fadedRuleColour = new Color(1, 1, 1, 0.25f);

    [Header("Threshold")]
    [SerializeField] TextMeshProUGUI thresholdText;

    [Header("Hell Rules")]
    [SerializeField] TextMeshProUGUI genderRuleText_Hell;
    [SerializeField] TextMeshProUGUI birthMonthRuleText_Hell;
    [SerializeField] TextMeshProUGUI hairColourRuleText_Hell;
    [SerializeField] TextMeshProUGUI eyeColourRuleText_Hell;
    [SerializeField] TextMeshProUGUI heightRuleText_Hell;
    [SerializeField] TextMeshProUGUI bornBeforeRuleText_Hell;

    [Header("Heaven Rules")]
    [SerializeField] TextMeshProUGUI genderRuleText_Heaven;
    [SerializeField] TextMeshProUGUI birthMonthRuleText_Heaven;
    [SerializeField] TextMeshProUGUI hairColourRuleText_Heaven;
    [SerializeField] TextMeshProUGUI eyeColourRuleText_Heaven;
    [SerializeField] TextMeshProUGUI heightRuleText_Heaven;
    [SerializeField] TextMeshProUGUI bornBeforeRuleText_Heaven;


    RulesGenerator dailyRulesGenerator;

    private void Awake()
    {
        dailyRulesGenerator = FindObjectOfType<RulesGenerator>();
    }

    public void UpdateThresholdText(int currentThreshold)
    {
        thresholdText.text = "CURRENT THRESHOLD:  " + currentThreshold;
    }

    public void ResetAllRuleTexts()
    {
        genderRuleText_Heaven.text = "Gender:";
        genderRuleText_Heaven.color = fadedRuleColour;
        genderRuleText_Hell.text = "Gender:";
        genderRuleText_Hell.color = fadedRuleColour;

        birthMonthRuleText_Heaven.text = "Born In:";
        birthMonthRuleText_Heaven.color = fadedRuleColour;
        birthMonthRuleText_Hell.text = "Born In:";
        birthMonthRuleText_Hell.color = fadedRuleColour;

        hairColourRuleText_Heaven.text = "Hair Color:";
        hairColourRuleText_Heaven.color = fadedRuleColour;
        hairColourRuleText_Hell.text = "Hair Color:";
        hairColourRuleText_Hell.color = fadedRuleColour;

        eyeColourRuleText_Heaven.text = "Eye Color:";
        eyeColourRuleText_Heaven.color = fadedRuleColour;
        eyeColourRuleText_Hell.text = "Eye Color:";
        eyeColourRuleText_Hell.color = fadedRuleColour;

        heightRuleText_Heaven.text = "Height:";
        heightRuleText_Heaven.color = fadedRuleColour;
        heightRuleText_Hell.text = "Height:";
        heightRuleText_Hell.color = fadedRuleColour;

        bornBeforeRuleText_Heaven.text = "Born Before:";
        bornBeforeRuleText_Heaven.color = fadedRuleColour;
        bornBeforeRuleText_Hell.text = "Born Before:";
        bornBeforeRuleText_Hell.color = fadedRuleColour;
    }

    public void MatchRuleCase()
    {
        ruleToMatch = (RuleToMatch)dailyRulesGenerator.currentAutoRule;
    }

    public void DisplayCurrentRule()
    {
        switch (ruleToMatch)
        {
            case RuleToMatch.Gender:

                if (dailyRulesGenerator.autoIsForHeaven == true)
                {
                    genderRuleText_Heaven.text = "Gender: " + dailyRulesGenerator.autoGender;
                    genderRuleText_Heaven.color = highlightedRuleColour;
                }
                else if (dailyRulesGenerator.autoIsForHeaven == false)
                {
                    genderRuleText_Hell.text = "Gender: " + dailyRulesGenerator.autoGender;
                    genderRuleText_Hell.color = highlightedRuleColour;
                }

                break;

            case RuleToMatch.BirthMonth:

                if (dailyRulesGenerator.autoIsForHeaven == true)
                {
                    birthMonthRuleText_Heaven.text = "Born In: " + dailyRulesGenerator.autoMonth;
                    birthMonthRuleText_Heaven.color = highlightedRuleColour;
                }
                else if (dailyRulesGenerator.autoIsForHeaven == false)
                {
                    birthMonthRuleText_Hell.text = "Born In: " + dailyRulesGenerator.autoMonth;
                    birthMonthRuleText_Hell.color = highlightedRuleColour;
                }

                break;

            case RuleToMatch.HairColour:

                if (dailyRulesGenerator.autoIsForHeaven == true)
                {
                    hairColourRuleText_Heaven.text = "Hair Color: " + dailyRulesGenerator.autoHair;
                    hairColourRuleText_Heaven.color = highlightedRuleColour;
                }
                else if (dailyRulesGenerator.autoIsForHeaven == false)
                {
                    hairColourRuleText_Hell.text = "Hair Color: " + dailyRulesGenerator.autoHair;
                    hairColourRuleText_Hell.color = highlightedRuleColour;
                }

                break;

            case RuleToMatch.EyeColour:

                if (dailyRulesGenerator.autoIsForHeaven == true)
                {
                    eyeColourRuleText_Heaven.text = "Eye Color: " + dailyRulesGenerator.autoEye;
                    eyeColourRuleText_Heaven.color = highlightedRuleColour;
                }
                else if (dailyRulesGenerator.autoIsForHeaven == false)
                {
                    eyeColourRuleText_Hell.text = "Eye Color: " + dailyRulesGenerator.autoEye;
                    eyeColourRuleText_Hell.color = highlightedRuleColour;
                }

                break;

            case RuleToMatch.AboveSixFoot:

                if (dailyRulesGenerator.autoIsForHeaven == true)
                {
                    heightRuleText_Heaven.text = "Height: Above 6'";
                    heightRuleText_Heaven.color = highlightedRuleColour;
                }
                else if (dailyRulesGenerator.autoIsForHeaven == false)
                {
                    heightRuleText_Hell.text = "Height: Above 6'";
                    heightRuleText_Hell.color = highlightedRuleColour;
                }

                break;

            case RuleToMatch.Before2000:

                if (dailyRulesGenerator.autoIsForHeaven == true)
                {
                    bornBeforeRuleText_Heaven.text = "Born Before: 2000";
                    bornBeforeRuleText_Heaven.color = highlightedRuleColour;
                }
                else if (dailyRulesGenerator.autoIsForHeaven == false)
                {
                    bornBeforeRuleText_Hell.text = "Born Before: 2000";
                    bornBeforeRuleText_Hell.color = highlightedRuleColour;
                }

                break;

            case RuleToMatch.Before1990:

                if (dailyRulesGenerator.autoIsForHeaven == true)
                {
                    bornBeforeRuleText_Heaven.text = "Born Before: 1990";
                    bornBeforeRuleText_Heaven.color = highlightedRuleColour;
                }
                else if (dailyRulesGenerator.autoIsForHeaven == false)
                {
                    bornBeforeRuleText_Hell.text = "Born Before: 1990";
                    bornBeforeRuleText_Hell.color = highlightedRuleColour;
                }

                break;

            case RuleToMatch.Before1980:

                if (dailyRulesGenerator.autoIsForHeaven == true)
                {
                    bornBeforeRuleText_Heaven.text = "Born Before: 1980";
                    bornBeforeRuleText_Heaven.color = highlightedRuleColour;
                }
                else if (dailyRulesGenerator.autoIsForHeaven == false)
                {
                    bornBeforeRuleText_Hell.text = "Born Before: 1980";
                    bornBeforeRuleText_Hell.color = highlightedRuleColour;
                }

                break;

        }
    }
}
