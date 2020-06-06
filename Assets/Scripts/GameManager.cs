using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool isGameActive = true;

    public int score = 0;
    public int collected = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CollectingBottle()
    {

        collected += 1;
    }

    public void ScoreCalculate()
    {

        score = (int)Mathf.Log(collected, 4)*10;
        collected = 0;
        Debug.Log(score);
    }

}
