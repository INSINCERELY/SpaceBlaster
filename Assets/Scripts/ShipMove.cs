using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    float speed = 500.0f;
    int xrange = 640;
    int zrange = 300;
    public float horizontalInput;
    public float verticalInput;
    public ParticleSystem beams;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject gameOver;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        beams.Play();
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.x > xrange)
        {
            transform.position = new Vector3(xrange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xrange)
        {
            transform.position = new Vector3(-xrange, transform.position.y, transform.position.z);
        }
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //rb.velocity = transform.right * speed * horizontalInput * Time.deltaTime;

        verticalInput = Input.GetAxis("Vertical");
        if (transform.position.z > zrange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zrange);
        }
        if (transform.position.z < -zrange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zrange);
        }
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
       // rb.velocity = transform.forward * speed * verticalInput * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

    }
    private void FixedUpdate()
    {
    }
    private void OnTriggerEnter (Collider other)
    {
        if (!other.gameObject.CompareTag("Missile"))
        {
            Debug.Log("Game Over!");
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }

    
}

