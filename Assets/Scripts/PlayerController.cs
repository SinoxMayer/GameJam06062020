using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 10f;
    private float horizantalnput = 1;
    public bool isPlayerAlive = true;
    public bool isOnGround = true;
    private GameManager gameManager;
    private GroundManager groundManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        groundManager = GameObject.Find("GorundManager").GetComponent<GroundManager>();
        gameManager.collected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                horizantalnput *= -1;
            }

            PlayerMove();

        }

        if (!isOnGround)
        {
            gameManager.isGameActive = false;
        }

    }

    void PlayerMove()
    {


        transform.Translate(Vector3.forward * horizantalnput * Time.deltaTime * playerSpeed);


    }

    private void OnCollisionEnter(Collision collision)
    {
        //gameObject üzerinde bir collision varsa ve tag i varsa
        if (collision.gameObject.CompareTag("Ground") && gameManager.isGameActive)
        {
            isOnGround = true;

        }
        else
        {
            isOnGround = false;
        }

        //if (collision.gameObject.CompareTag("Bottle") && gameManager.isGameActive)
        //{
        //    //Destroy(collision.gameObject);
        //    gameManager.score += 10;

        //}
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bottle") && gameManager.isGameActive)
        {
            Destroy(other.gameObject);
            gameManager.CollectingBottle();
            Debug.Log(gameManager.collected);
        }
        else if (other.gameObject.CompareTag("Recycle") && gameManager.isGameActive)
        {
            gameManager.ScoreCalculate();
        }
        else if (other.gameObject.CompareTag("Trashcan") && gameManager.isGameActive)
        {
            gameManager.ScoreDownCal();
        }
        else if (other.gameObject.CompareTag("Opsticale") && gameManager.isGameActive)
        {
            groundManager.LengyhUpdate(1);
        }

    }


}
