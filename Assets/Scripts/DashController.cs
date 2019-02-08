using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (PlayerMovement))]

public class DashController : MonoBehaviour {
    private int direction;
    public Vector3 moveVector;
    public float dashTimeCurrent;
    Rigidbody rb;
    public float dashTimeMax = .25f;
    public float dashSpeed = 5;
    public float jumpHeight =7;
    public int pressCountL, pressCountR, pressCountU, pressCountB;
    public float PressCountDelayMax = .05f;
    public float currentPresCountDelay;
    private bool pressed;
    public GameObject dashEffect;
    public Transform dashPos;
    PlayerMovement movement;
    public bool Activate = false;
    public float dashX = 12.44f;
    public bool Grounded { get; set; }

    // Use this for initialization
    void Start () {
        dashTimeCurrent = dashTimeMax;
        rb = GetComponent<Rigidbody> ();
        currentPresCountDelay = PressCountDelayMax;
        movement = GetComponent<PlayerMovement> ();
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Activate)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                moveVector = new Vector3(transform.position.x-dashX, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, moveVector, dashSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                moveVector = new Vector3(transform.position.x + dashX, transform.position.y, transform.position.z);
                if (moveVector.x > dashX)
                {
                    moveVector = transform.position;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, moveVector, dashSpeed * Time.deltaTime);
                }
            }
        }
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z+1*Time.deltaTime);
        }
    public void Smokey () {
        Instantiate (dashEffect, dashPos.position, dashPos.rotation);
    }
    public void OnCollisionEnter (Collision other) {
        if (other.gameObject.CompareTag ("Floor")) {
            Grounded = true;
        }
    }
}