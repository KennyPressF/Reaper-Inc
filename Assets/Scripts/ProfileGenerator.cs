using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileGenerator : MonoBehaviour
{
    [SerializeField] Image profilePicture;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI dOBText;
    [SerializeField] TextMeshProUGUI hairText;
    [SerializeField] TextMeshProUGUI eyesText;
    [SerializeField] TextMeshProUGUI heightText;

    [SerializeField] ProfileSO[] allProfiles;
    [SerializeField] public ProfileSO currentProfile;
    [SerializeField] int randomProfileIndex;

    public void GetRandomProfile()
    {
        randomProfileIndex = Random.Range(0, allProfiles.Length);
        currentProfile = allProfiles[randomProfileIndex];

        if (currentProfile.hasBeenProcessed == false)
        {
            profilePicture.sprite = currentProfile.profilePicture; 
            nameText.text = currentProfile.profileName;
            dOBText.text = currentProfile.birthDay + " " + currentProfile.birthMonth + " " + currentProfile.birthYear.ToString();
            hairText.text = currentProfile.hairColour.ToString();
            eyesText.text = currentProfile.eyeColour.ToString();
            heightText.text = currentProfile.height;

            currentProfile.hasBeenProcessed = true;
        }

        else
        {
            GetRandomProfile();
        }
    }

    public void ResetAllProfiles()
    {
        foreach (ProfileSO profile in allProfiles)
        {
            profile.hasBeenProcessed = false;
        }
    }
}
