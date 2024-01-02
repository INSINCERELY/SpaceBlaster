using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private float topBound = 300f;
    private float speed = 24000f;
    private Rigidbody rb;
    [SerializeField] AudioClip explosionSound; // Add explosion sound field
    private AudioSource enemyAudio;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.position.z > topBound)
        {
            DestroyEnemy();
        }
        else if (transform.position.z < -topBound)
        {
            DestroyEnemy();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Missile") || other.gameObject.CompareTag("Player"))
        {
           
           // PlayExplosionSound(); // Add explosion sound when destroyed
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    void PlayExplosionSound()
    {
        //Debug.Log("Playing explosion sound");
        // AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        enemyAudio.PlayOneShot(explosionSound, 1.0f);
    }
}


