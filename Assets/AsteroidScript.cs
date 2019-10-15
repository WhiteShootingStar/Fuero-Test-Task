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
        
        speed = Random.Range(0.1f,25f);
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        GetComponent<Rigidbody>().velocity= direction * speed * Time.deltaTime;
       
    }

    // Update is called once per frame
    //void LateUpdate()
    //{
    //    transform.Translate(direction * speed * Time.deltaTime);
    //  //  transform.localPosition += direction * speed * Time.deltaTime;
    //}

   

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
        //Destroy(gameObject);
        gameObject.SetActive(false);
        Invoke("resp", 1f);
        // GameController.RespAster(gameObject);
        // other.gameObject.SetActive(false);
       // GameController.RespAster(gameObject);
       //StartCoroutine(GameController.RespawnAsteroid(gameObject));
    }
   void resp()
    {
        
        gameObject.SetActive(true);
        gameObject.transform.position = GameController.getGoodSpawnPosition();
    }
}
