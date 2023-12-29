using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    private float topBound = 300f;
    private float speed = 240000f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        rb.velocity = transform.forward * speed * Time.deltaTime;
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -topBound)
        {
            Destroy(gameObject);
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Missile"))
        {
            Destroy(gameObject);
            
        }
    }
}


