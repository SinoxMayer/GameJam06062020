using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public bool isGameActive = false;
    public bool isGameEnd = true;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bottleText;

    public int score = 0;
    public int collected = 0;

    private GroundManager groundManager;

   
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score";
        bottleText.text = "Collected Bottles";
        groundManager = GameObject.Find("GorundManager").GetComponent<GroundManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CollectingBottle()
    {

        collected += 1;
        bottleText.text = collected.ToString();

        if (collected == 5)
        {
            groundManager.LengyhUpdate(-1);
        }
        if (groundManager.length > 13)
        {
            groundManager.LengyhUpdate(4);
            score += 30;
            scoreText.text = score.ToString();
        }
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
