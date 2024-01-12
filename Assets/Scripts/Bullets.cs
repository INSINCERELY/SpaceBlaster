using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullets : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 200f;
    private float xBound = 640;
    private float zBound = 300f;
    private GameObject player;
    private Rigidbody rb;
    Vector3 lookDirection;
   //public ParticleSystem Impact;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        lookDirection = (player.transform.position - transform.position).normalized;
       
    }

    // Update is called once per frame
    void Update()
    {
       
        //transform.Translate(Vector3.up* Time.deltaTime * speed);
        Quaternion rot = Quaternion.Euler(270,lookDirection.x,lookDirection.z);
        transform.rotation = rot;    
        rb.AddForce (lookDirection*speed);
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
        if (!other.gameObject.CompareTag("Enemy2"))
        {
            //  Impact.Play();
            Destroy(gameObject);
        }
    } 
}
