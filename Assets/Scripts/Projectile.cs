using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 600f;
    private float xBound = 640;
    private float zBound = 300f;
    //public ParticleSystem Impact;
    void Start()
    {
       // Impact = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (transform.position.z > zBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -zBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > xBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            //Impact.Play();
            Destroy(gameObject);
        }

    }

}
