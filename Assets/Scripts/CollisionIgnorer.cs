using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnorer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 5f;
    public bool canCountDown = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (canCountDown)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            canCountDown = false;
            GetComponent<BoxCollider>().isTrigger = true;

        }
    }
    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided with: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Attempted to disable collision");
            GetComponent<BoxCollider>().isTrigger = false;
            canCountDown = true;
        }
    }

}
