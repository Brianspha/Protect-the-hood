using System;
using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
[RequireComponent (typeof (Rigidbody))]
public class Bullet : MonoBehaviour {

    // Use this for initialization
    public float force = 6000f;
    Rigidbody rb;
    public GameObject explosionEffect;
    public float Speed = 30;
    CameraShaker shaker;
    public GameObject rocketTrail, smallExplosion,hitEffectbricks,flames;
    public float magn = 1000, rough = 500, fadeIn = 1f, fadeOut = 2f;
    public float deathIncrementor = 500;
    RipplePostProcessor rippler;
    public Image flash;
    public float flashDuration = 1;
    GameManager manager;
    bool attachedAlready = false;

    void Start () {
        rb = GetComponent<Rigidbody> ();
        shaker = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraShaker> ();
        rippler = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RipplePostProcessor>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update () {
        transform.position += Vector3.forward * Speed * Time.deltaTime;
        //transform.position = new Vector3(transform.position.x, YPos, transform.position.z);
    }
    public void Shoot () {
        if (gameObject&& transform && rb) {
            rb.AddForce (transform.forward * force);
        }
    }
    public void OnCollisionEnter (Collision other) {
        if (other.gameObject.CompareTag ("AI")) {
            Debug.Log ("Got the Bastard");
            Handheld.Vibrate();
            other.gameObject.GetComponent<AIMove> ().Health -= 1;
            if (other.gameObject.GetComponent<AIMove> ().Health <= 0) {
                SpawnDestructables (other.transform);
                DestroyOther(other.gameObject);
                shaker.ShakeOnce(magn+deathIncrementor, rough+deathIncrementor, fadeIn, fadeOut);
                manager.UpdateScore(Random.Range(5, 15));
                spawnExplosionEffect(other.gameObject.transform);
                spawnExplosionEffect(other.gameObject.transform);

            }
            else
            {
                shaker.ShakeOnce(magn, rough, fadeIn, fadeOut);
                rippler.Ripple();
                manager.UpdateScore(Random.Range(1, 4));
                SpawnSemiDestructable(other.gameObject.transform);
            }
            flash.CrossFadeColor(Color.red, flashDuration,false, false, true);
            DestroyOther(gameObject);
        }
        if (other.gameObject.CompareTag("RestrictorCenter") || other.gameObject.CompareTag("Restrictor"))
        {
            Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            Debug.Log("Called RestrictorCenter");
        }
    }

    public void SetParent(GameObject child)
    {
        if (!attachedAlready)
        {
            flames.transform.parent = child.gameObject.transform;
            attachedAlready = true;
        }
    }
    public void spawnExplosionEffect(Transform pos)
    {
        Instantiate(explosionEffect, pos.position, pos.rotation);
    }
    private void SpawnDestructables (Transform pos) {
        Instantiate (explosionEffect, pos.position, pos.rotation);
        Instantiate (smallExplosion, pos.position, pos.rotation);
    }
    private void SpawnSemiDestructable(Transform pos)
    {
        Instantiate(hitEffectbricks, pos.position, pos.rotation);
        Instantiate(smallExplosion, pos.position, pos.rotation);
    }
    public void DestroyOther(GameObject other)
    {
        Destroy(other);
    }
}