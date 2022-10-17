using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Image volumeSliderIcon;
    [SerializeField] Sprite audioOn;
    [SerializeField] Sprite audioOff;

    [Header("Difficulty")]
    [SerializeField] Toggle easyToggle;
    [SerializeField] Image easyIcon;
    [SerializeField] TextMeshProUGUI easyText;
    [SerializeField] Toggle mediumToggle;
    [SerializeField] Image mediumIcon;
    [SerializeField] TextMeshProUGUI mediumText;
    [SerializeField] Toggle hardToggle;
    [SerializeField] Image hardIcon;
    [SerializeField] TextMeshProUGUI hardText;
    [SerializeField] int difficultyIndex;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        InitializeDifficulty();
        SetDifficulty();
        InitializeVolume();
        SetVolume();
    }

    private void InitializeVolume()
    {
        if(!PlayerPrefs.HasKey("Volume"))
        {
            volumeSlider.value = -5f;
            PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        }
        else
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
    }

    public void SetVolume()
    {
        audioMixer.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);

        if(volumeSlider.value <= -29)
        {
            audioMixer.SetFloat("Volume", -80);
            volumeSliderIcon.sprite = audioOff;
        }
        else
        {
            volumeSliderIcon.sprite = audioOn;
        }
    }

    private void InitializeDifficulty()
    {
        if (!PlayerPrefs.HasKey("Difficulty"))
        {
            difficultyIndex = 1;
            PlayerPrefs.SetInt("Difficulty", difficultyIndex);
        }
        else if (PlayerPrefs.HasKey("Difficulty"))
        {
            difficultyIndex = PlayerPrefs.GetInt("Difficulty");
        }

        if (difficultyIndex == 1)
        {
            easyToggle.isOn = true;
        }
        else if (difficultyIndex == 2)
        {
            mediumToggle.isOn = true;
        }
        else if (difficultyIndex == 3)
        {
            hardToggle.isOn = true;
        }
    }

    public void SetDifficulty()
    {
        AudioManager.instance.PlaySFX(0);

        if (easyToggle.isOn)
        {
            difficultyIndex = 1;
            PlayerPrefs.SetInt("Difficulty", difficultyIndex);
            scoreKeeper.maxTime = 120;

            easyIcon.color = Color.green;
            easyText.color = Color.green;
            easyText.fontStyle = FontStyles.Underline;

            mediumIcon.color = Color.white;
            mediumText.color = Color.white;
            hardText.fontStyle = FontStyles.Normal;

            hardIcon.color = Color.white;
            hardText.color = Color.white;
            hardText.fontStyle = FontStyles.Normal;
        }

        if (mediumToggle.isOn)
        {
            difficultyIndex = 2;
            PlayerPrefs.SetInt("Difficulty", difficultyIndex);
            scoreKeeper.maxTime = 90;

            easyIcon.color = Color.white;
            easyText.color = Color.white;
            easyText.fontStyle = FontStyles.Normal;

            mediumIcon.color = Color.yellow;
            mediumText.color = Color.yellow;
            mediumText.fontStyle = FontStyles.Underline;

            hardIcon.color = Color.white;
            hardText.color = Color.white;
            hardText.fontStyle = FontStyles.Normal;
        }

        if (hardToggle.isOn)
        {
            difficultyIndex = 3;
            PlayerPrefs.SetInt("Difficulty", difficultyIndex);
            scoreKeeper.maxTime = 60;

            easyIcon.color = Color.white;
            easyText.color = Color.white;
            easyText.fontStyle = FontStyles.Normal;

            mediumIcon.color = Color.white;
            mediumText.color = Color.white;
            mediumText.fontStyle = FontStyles.Normal;

            hardIcon.color = Color.red;
            hardText.color = Color.red;
            hardText.fontStyle = FontStyles.Underline;
        }
    }
}
