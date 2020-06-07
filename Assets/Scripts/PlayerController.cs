using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Android;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float downBound = -2;

    public Image imageAwsome;
    public Image imageGoodJob;

    private float horizantalnput = 1;
    private float timeCountDown = 1f ;

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
            else if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                horizantalnput *= -1;
            }

            PlayerMove();

        }

        if (!isOnGround)
        {
            gameManager.isGameActive = false;
        }


        if (transform.position.y < downBound)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (imageAwsome.enabled )
        {
            timeCountDown -= Time.deltaTime;
            if (timeCountDown < 0)
            {
                imageAwsome.enabled = false;
                timeCountDown = 1f;
            }
        }
        else if (imageGoodJob.enabled)
        {
            timeCountDown -= Time.deltaTime;
            if (timeCountDown < 0)
            {
                imageGoodJob.enabled = false;
                timeCountDown = 1f;
            }


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

            imageAwsome.enabled = true;
             
        }
        else if (other.gameObject.CompareTag("Recycle") && gameManager.isGameActive)
        {
            gameManager.ScoreCalculate();

            imageGoodJob.enabled = true;
        }
        else if (other.gameObject.CompareTag("Trashcan") && gameManager.isGameActive)
        {
            gameManager.ScoreDownCal();
        }
        else if (other.gameObject.CompareTag("Opsticale") && gameManager.isGameActive)
        {
            Destroy(other.gameObject);
            groundManager.LengyhUpdate(1);
        }

    }


}
