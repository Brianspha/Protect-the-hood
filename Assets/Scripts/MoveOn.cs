using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOn : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay=2f;
    bool deactivated = false;
    GameManager manager;
   public bool canMove = false;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z < transform.position.z && manager.canMoveOn &&!deactivated)
        {
            Debug.Log("Called in MoveOn ignored physics");
            deactivated = true;
            // Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
            GetComponent<Collider>().enabled = false;
        }
        if(player.transform.position.z > transform.position.z)
        {
            GetComponent<Collider>().enabled = true;

        }
    }

    public void OnCollisionEnter(Collision other)
    {
       
        

    }
}
