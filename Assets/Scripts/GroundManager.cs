using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GroundManager : MonoBehaviour
{
    [SerializeField] private GameObject groundBox;
    private GameManager gameManager;

    public int length = 10;
    private int lengthW = 35;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameStartGound();
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameManager.isGameActive)
        {

            for (int i = 0; i < length; i++)
            {

                Instantiate(groundBox, new Vector3(25, -1, i), groundBox.transform.rotation);
            }


        }


    }
    

    void GameStartGound()
    {
        for (int i = 0; i < lengthW; i++)
        {
            for (int j = 0; j < length; j++)
            {
                Instantiate(groundBox,new Vector3(i,-1,j), groundBox.transform.rotation);
            }
        }
    }

    public void LengyhUpdate(int num)
    {

        length -= num;

    }

  
}
