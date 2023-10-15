using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectCoin(string coinTag)
    {
        switch (coinTag)
        {
            case "GoldCoin":
                score += 5;
                break;
            case "SilverCoin":
                score += 3;
                break;
            case "BronzeCoin":
                score += 1;
                break;
        }
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
