using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void UpdateScoreText()
    {
        scoreText.text ="Score : " + score;
    }

    public void IncrementaScore()
    {
        score++;
        UpdateScoreText();
    }
}
