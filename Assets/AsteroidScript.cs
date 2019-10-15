using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public static GameController GameController;
    private float speed;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        if (GameController == null)
        {
            GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        }
        speed = Random.value * 15;
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Bullet"))
        {
            GameController.UpdateText();

        }
        else if (other.tag.Equals("Player"))
        {
            Camera.main.GetComponent<CameraScript>().StopFollowing();
            other.gameObject.SetActive(false);
        }
       
        //Destroy(other.gameObject);
       
        GameController.RespAster(gameObject);
        // other.gameObject.SetActive(false);


       //StartCoroutine(GameController.RespawnAsteroid(gameObject));
    }
}
