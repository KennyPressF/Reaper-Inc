using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeedGenerator : MonoBehaviour
{
    [Header("Trait Value")]
    int randomValue;
    [SerializeField] int minDeedValue;
    [SerializeField] int maxDeedValue;
    int selectedDeedValue;
    int totalDeedValue;

    [SerializeField] GameObject[] deedObjectArray;

    [Header("Trait Text")]
    string selectedDeedText;
    [SerializeField] string[] possibleGoodDeeds;
    [SerializeField] string[] possibleBadDeeds;

    List<int> goodDeedsList;
    List<int> badDeedsList;
    List<int> allDeedValuesList;

    Randomiser randomiser;

    private void Awake()
    {
        randomiser = GetComponent<Randomiser>();
    }

    public void GetRandomDeeds()
    {
        goodDeedsList = new List<int>();
        badDeedsList = new List<int>();
        allDeedValuesList = new List<int>();

        for (int i = 0; i < possibleGoodDeeds.Length; i++)
        {
            goodDeedsList.Add(i);
        }

        for (int i = 0; i < possibleBadDeeds.Length; i++)
        {
            badDeedsList.Add(i);
        }

        foreach (GameObject deedObject in deedObjectArray)
        {
            int coinFlipResult = randomiser.FlipACoin();
            int deedTextIndex = 0;
            int deedValueIndex = 1;

            TextMeshProUGUI deedText = deedObject.transform.GetChild(deedTextIndex).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI deedValue = deedObject.transform.GetChild(deedValueIndex).GetComponent<TextMeshProUGUI>();


            if (coinFlipResult <= 50)
            {
                int listIndex = Random.Range(0, goodDeedsList.Count - 1);

                selectedDeedText = possibleGoodDeeds[goodDeedsList[listIndex]];

                randomValue = Random.Range(minDeedValue, maxDeedValue);
                selectedDeedValue = randomValue;

                deedText.text = selectedDeedText;
                deedValue.text = selectedDeedValue.ToString();
                deedValue.color = Color.green;

                allDeedValuesList.Add(selectedDeedValue);
                goodDeedsList.RemoveAt(listIndex);
            }
            else
            {
                int listIndex = Random.Range(0, badDeedsList.Count - 1);

                selectedDeedText = possibleBadDeeds[badDeedsList[listIndex]];

                randomValue = Random.Range(minDeedValue, maxDeedValue);
                selectedDeedValue = -randomValue;

                deedText.text = selectedDeedText;
                deedValue.text = selectedDeedValue.ToString();
                deedValue.color = Color.red;

                allDeedValuesList.Add(selectedDeedValue);
                badDeedsList.RemoveAt(listIndex);
            }
        }
    }

    public int CalculateTotalValue()
    {
        totalDeedValue = 0;

        foreach (int value in allDeedValuesList)
        {
            totalDeedValue += value;
        }

        return totalDeedValue;
    }
}
