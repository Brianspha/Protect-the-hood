using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public float offset = 5f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.z+offset < player.transform.position.z)
        {
            SelfDestruct();
        }    
    }
    void SelfDestruct()
    {
        Destroy(gameObject.transform.parent);
    }


}
