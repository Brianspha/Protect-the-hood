using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class AIMove : MonoBehaviour {

    // Use this for initialization
    public float Speed = 5f;
    public float minRetreatDistance = 8;
    public float stopDistance = 9;
    Transform player;
    public float distanceFromPlayer;
    public GameObject[] AIS;
    public float minDistanceBetweenAI = 5f;
    public float factor = 5f;
    Rigidbody rb;
    public float force = 5;
    public float awayFactor = -30;
    public float delay = 5;
    public Vector3 destroyVector;
    public bool ignore = false;
    public float MinX = 15.3f;
    public float Health;
    GameManager manager;
    public Quaternion defaltRot;
    public  float defaultY;
    void Start () {
        Health = Random.Range(3, 7);
        defaltRot = transform.rotation;
        manager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
        Health = manager.GetHealthLevel () + Health;
        rb = GetComponent<Rigidbody> ();
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        AIS = GameObject.FindGameObjectsWithTag ("AI");
    }

    // Update is called once per frame
    void Update () {
        if (!ignore) {
            distanceFromPlayer = Vector3.Distance (transform.position, player.position);
            if (distanceFromPlayer > stopDistance) {
                transform.position = Vector3.MoveTowards (transform.position, player.position, Speed * Time.deltaTime);
            } else if (distanceFromPlayer < stopDistance && distanceFromPlayer > minRetreatDistance) {
                transform.position = transform.position;
            } else if (distanceFromPlayer < minRetreatDistance && distanceFromPlayer < minRetreatDistance) {
                transform.position = Vector3.MoveTowards (transform.position, player.position, -Speed * Time.deltaTime);
            }
            for (int i = 0; i < AIS.Length; i++) {
                if (AIS[i] == null) {
                    continue;
                }
                Transform temp = AIS[i].transform;
                float distance = Vector3.Distance (transform.position, temp.position);
                if (distance < minDistanceBetweenAI && temp != transform) {
                    Vector3 target = temp.position - transform.position;
                    target = target.normalized;
                    temp.position = Vector3.MoveTowards (temp.position, temp.position += target, Speed * Time.deltaTime);
                }
            }
        }
        if (transform.position.z < player.position.z) {
            ignore = true;
            destroyVector = new Vector3 (transform.position.x, transform.position.y, -transform.position.z + awayFactor);
            transform.position = Vector3.MoveTowards (transform.position, destroyVector, Speed * Time.deltaTime);
        }
        if (ignore && transform.position.z == destroyVector.z) {
            DestroyMe ();
        }
        transform.rotation = defaltRot;
        transform.position = new Vector3(transform.position.x, defaultY, transform.position.z);
    }
    public void OnCollisionEnter (Collision other) {
        if (other.gameObject.CompareTag ("RestrictorCenter") || other.gameObject.CompareTag ("Restrictor")) {
            Physics.IgnoreCollision (other.gameObject.GetComponent<Collider> (), GetComponent<Collider> ());
            Debug.Log ("Called RestrictorCenter");
        }
        if (other.gameObject.CompareTag ("Wall")) {
            transform.position = Vector3.MoveTowards (transform.position, -transform.position, Speed * Time.deltaTime);
        }
    }
    public void DestroyMe () {
        Destroy (gameObject, delay);
    }
}