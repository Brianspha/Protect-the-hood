using EZCameraShake;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class Gun : MonoBehaviour {

    // Use this for initialization
    public GameObject[] bullets;
    public float maxDelay = 1f;
    public float currentDelay;
    public Transform gunPointA, gunPointB;
    CameraShaker shaker;
    public float magn = 1000, rough = 500, fadeIn = 1f, fadeOut = 2f;

    void Start ()
    {
        shaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShaker>();
    }
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown (KeyCode.Space) && currentDelay <= 0) {
            Shoot ();
            currentDelay = maxDelay;
            shaker.ShakeOnce(magn, rough, fadeIn, fadeOut);

        }
        currentDelay -= Time.deltaTime;

    }
    private void Shoot () {
        GameObject a = Instantiate (bullets[Random.Range (0, bullets.Length)], gunPointA.position, gunPointA.rotation) as GameObject;
        GameObject b = Instantiate (bullets[Random.Range (0, bullets.Length)], gunPointB.position, gunPointB.rotation) as GameObject;
        a.GetComponent<Bullet> ().Shoot ();
        b.GetComponent<Bullet> ().Shoot ();

    }

}