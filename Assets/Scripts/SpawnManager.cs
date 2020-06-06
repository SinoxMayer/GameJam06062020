using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
   
    [SerializeField] private GameObject[] randomObject;
    [SerializeField] private GameObject bottle;
    private GameManager gameManager;
    private GroundManager groundManager;
    [SerializeField] private float maxSpawnPoint = 25;
    [SerializeField] private float minSpawnPoint;

    private float startTime = 3f;

    private bool stop;


    private void Awake()
    {
        groundManager = GameObject.Find("GorundManager").GetComponent<GroundManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

       

    }
    // Start is called before the first frame update
    void Start()
    {



        StartCoroutine(RndmTimeSpawner());

    }
        // Update is called once per frame
        void  LateUpdate()
    {
        maxSpawnPoint = groundManager.length;
    }



    void SpawnRandomObject()
    {

        int randomObjIndex = Random.Range(0,randomObject.Length);

        Vector3 spawnPosv =new  Vector3(15,0,Random.Range(0, maxSpawnPoint));

        Instantiate(randomObject[randomObjIndex], spawnPosv, randomObject[randomObjIndex].transform.rotation);

        }


    private IEnumerator RndmTimeSpawner()
    {
        yield return new WaitForSeconds(startTime);
        while (!stop)
        {
            if (gameManager.isGameActive)
            {
                SpawnRandomObject();
                yield return new WaitForSeconds(Random.Range(1, 2));
            }
            

        }



    }


}
