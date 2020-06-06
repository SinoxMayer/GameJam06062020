using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GroundManager : MonoBehaviour
{
    [SerializeField] private GameObject groundBox;

    public int length =10;
    private int lengthW =35;
    // Start is called before the first frame update
    void Start()
    {
        GameStartGound();
    }

    // Update is called once per frame
    private void Update()
    {
    
        for (int i = 0; i < length; i++)
        {

            Instantiate(groundBox, new Vector3(25, -1, i), groundBox.transform.rotation);
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

  
}
