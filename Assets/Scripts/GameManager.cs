using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public bool isGameActive = true;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bottleText;

    public int score = 0;
    public int collected = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score";
        bottleText.text = "Collected Bottles";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CollectingBottle()
    {

        collected += 1;
        bottleText.text = collected.ToString();
       
    }

    public void ScoreCalculate()
    {
        if (collected > 0 )
        {
            score += 5 + (int)Mathf.Log(collected, 2) * 10;
            scoreText.text = score.ToString();
            collected = 0;
            bottleText.text = collected.ToString();
        }

      
    }

    public void ScoreDownCal()
    {

        if (collected > 0)
        {
            score -= 5 + (int)Mathf.Log(collected, 4) * 10;
            scoreText.text = score.ToString();
            collected = 0;
            bottleText.text = collected.ToString();
        }

    }

}
