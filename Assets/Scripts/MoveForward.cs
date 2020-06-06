using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 20f;
    [SerializeField] private float leftBound = 0;
    [SerializeField] private float leftBound2 = -5;
    [SerializeField] private float downBound = -1;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.left * Time.deltaTime * forwardSpeed);
        }
     
        DestroyGameobj();
    }

    void DestroyGameobj()
    {


        if (transform.position.x < leftBound)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            if (transform.position.x < leftBound2 || transform.position.y < downBound)
            {
                Destroy(gameObject);
            }
          
        }

    }
}
