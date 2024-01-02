using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    private float topBound = 300f;
    private float speed = 10000f;
    private float startDelay = 0;
    private float spawnInterval = 1f;
    private Rigidbody rb;
    [SerializeField] GameObject Bullets;
    [SerializeField] AudioClip explosionSound; // Add explosion sound field
    private AudioSource enemyAudio;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyAudio = GetComponent<AudioSource>();
        InvokeRepeating("SpawnBullet", startDelay, spawnInterval);
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
        if (other.gameObject.CompareTag("Missile")|| other.gameObject.CompareTag("Player"))
        {
            
            CancelInvoke("SpawnBullet");
           // PlayExplosionSound(); // Add explosion sound when destroyed
            DestroyEnemy();
        }
    }

    void SpawnBullet()
    {
        Instantiate(Bullets, transform.position, Bullets.transform.rotation);
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    void PlayExplosionSound()
    {
        //Debug.Log("Playing explosion sound");
        //AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        enemyAudio.PlayOneShot(explosionSound, 1.0f);
    }
}