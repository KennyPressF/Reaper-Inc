using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    int currentHighScore;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
            currentHighScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = currentHighScore.ToString("000000");
        }

        else if (PlayerPrefs.HasKey("HighScore"))
        {
            currentHighScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = currentHighScore.ToString("000000");
        }
    }

    public void SetHighScore(int score)
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            highScoreText.text = score.ToString("000000");
            PlayerPrefs.SetInt("HighScore", score);
        }

        else if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score > currentHighScore)
            {
                highScoreText.text = score.ToString("000000");
                PlayerPrefs.SetInt("HighScore", score);
            }
            else if (score <= currentHighScore)
            {
                highScoreText.text = currentHighScore.ToString("000000");
            }
        }
    }

    public void ResetHighScore()
    {
        AudioManager.instance.PlaySFX(0);
        PlayerPrefs.SetInt("HighScore", 0);
        highScoreText.text = 0.ToString("000000");
    }
}
