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

    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")|| other.gameObject.CompareTag("Gun"))
        {
            Debug.Log("Collided with: " + other.gameObject.tag);
            Physics.IgnoreCollision(GetComponent<Collider>(), other.gameObject.GetComponent<Collider>());
        }
    }

}
