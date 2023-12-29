using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    // Start is called before the first frame update
    private float topBound = 300f;
    private float speed = 10000f;
    private float startDelay = 0;
    private float spawnInterval = 1f;
    private Rigidbody rb;
    [SerializeField] GameObject Bullets;
   
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        InvokeRepeating("SpawnBullet", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
            CancelInvoke("SpawnBullet");
        }
        else if (transform.position.z < -topBound)
        {
            Destroy(gameObject);
            CancelInvoke("SpawnBullet");
        }
       
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Missile"))
        {
            Destroy(gameObject);
            CancelInvoke("SpawnBullet");
            
        }
    }
    void SpawnBullet()
    {
       
       Instantiate(Bullets,transform.position, Bullets.transform.rotation);
      
    }
}
