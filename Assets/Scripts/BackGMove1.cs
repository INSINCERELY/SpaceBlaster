using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGMove1 : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -800)
        {
            transform.position = new Vector3(0, 0, 780);
        }
        transform.Translate(-Vector3.up * Time.deltaTime * speed);
    }
}
