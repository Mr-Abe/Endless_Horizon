using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    Text scoreText;
    [SerializeField] Text gameoverScoreText;

    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = $"Score: {score}";
        gameoverScoreText.text = scoreText.text;
    }
}
