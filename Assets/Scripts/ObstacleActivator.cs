using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleActivator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] walls;

    void Start()
    {
        int howMany = Random.Range(0, walls.Length);
        for(int i=0; i < howMany; i++)
        {
            walls[i].GetComponent<MeshRenderer>().enabled = true;
        }
        if(howMany+1 < walls.Length)
        {
            for(int i=howMany+1; i < walls.Length; i++)
            {
                walls[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
