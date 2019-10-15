using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public float speed =1;
    public float rotationSpeed = 1;
    public BulletScript Bullet;
    public GameObject Gun;
    private GameObject LosingContainer;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0.5f, 0.5f);
        LosingContainer = GameObject.FindGameObjectWithTag("LosingContainer");
        LosingContainer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector2(0, Input.GetAxis("Vertical") * speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {      
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
    }
    void Shoot()
    {
        Instantiate(Bullet, Gun.transform.position, Gun.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Asteroid"))
        {
            Time.timeScale = 0;
           
            LosingContainer.SetActive(true);
            
        }
    }
}
