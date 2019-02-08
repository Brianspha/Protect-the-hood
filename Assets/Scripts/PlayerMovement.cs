using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    // Use this for initialization
    public float Speed = 5f;
    Rigidbody rb;
    public Vector3 moveVector;
    Quaternion defualtRot;
    public int direction; //@dev 1=left 2=right 3=up 4=up 5=dash
    public float MinX = 15.3f;
    public float MinZ = 8f;
    public bool Grounded { get; private set; }
    public Vector3 defaltRot;
    GameManager manager;
    GameObject half;
    void Start () {
        manager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
        rb = GetComponent<Rigidbody> ();
        defualtRot = transform.rotation;
        direction = Random.Range (1, 5);
    }

    // Update is called once per frame
    void Update () {
        transform.rotation = defualtRot;

    }
    public void FixedUpdate () {
        if (Input.GetKey (KeyCode.LeftArrow)) {
            moveVector = new Vector3 (transform.position.x + Vector3.left.x * Time.deltaTime * Speed, transform.position.y, transform.position.z);
            if (moveVector.x >= -MinX) {
                transform.position = Vector3.MoveTowards (transform.position, moveVector, Speed * Time.deltaTime);
            }
        }
        if (Input.GetKey (KeyCode.RightArrow)) {
            moveVector = new Vector3 (transform.position.x + Vector3.right.x * Time.deltaTime * Speed, transform.position.y, transform.position.z);
            if (moveVector.x <= MinX) {
                transform.position = Vector3.MoveTowards (transform.position, moveVector, Speed * Time.deltaTime);
            }
        }
        if (Input.GetKey (KeyCode.UpArrow)) {
            moveVector = new Vector3 (transform.position.x, transform.position.y, transform.position.z + Vector3.forward.z * Time.deltaTime * Speed);
            if (moveVector.z < moveVector.z + MinZ) {
                transform.position = Vector3.MoveTowards (transform.position, moveVector, Speed * Time.deltaTime);
            }
        }
        if (Input.GetKey (KeyCode.DownArrow)) {
            moveVector = new Vector3 (transform.position.x, transform.position.y, transform.position.z - Vector3.forward.z * Time.deltaTime * Speed);
            transform.position = Vector3.MoveTowards (transform.position, moveVector, Speed * Time.deltaTime);
        }
    }
    public void OnCollisionEnter (Collision other) {
        if (other.gameObject.CompareTag ("Floor")) {
            Grounded = true;
        }
        if (other.gameObject.CompareTag ("Restrictor")) {
            transform.position = transform.position;
            Debug.Log ("Called");
        }
    }
}