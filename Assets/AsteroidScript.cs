﻿using System.Collections;
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
<<<<<<< HEAD
        speed = Random.Range(3f,20f);
=======
        speed = Random.Range(1f,20f);
>>>>>>> 2493ad097dd2438841c2c8f9cf4fd1c6e9f67695
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));// getting random speed and direction
        GetComponent<Rigidbody>().velocity= direction * speed * Time.deltaTime;// this function is much cheaper in terms of CPU than Translate in Update() method
       
    }
<<<<<<< HEAD
   
=======

>>>>>>> 2493ad097dd2438841c2c8f9cf4fd1c6e9f67695
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Bullet"))
        {
            GameController.UpdateText();
            Destroy(other.gameObject);
           
        }
        else if (other.tag.Equals("Player"))
        {
            Camera.main.GetComponent<CameraScript>().StopFollowing();
            other.gameObject.SetActive(false);
           
        }
       
        gameObject.SetActive(false); // since the is a lot of such objects, I've decided to to use object pooling here 
        Invoke("Resp", 1f);
       
    }
   void Resp()
    {  
        gameObject.SetActive(true);
         GameController.RespawnAtGoodPosition(gameObject); // 'ask' Gamecontroller to respawn this object
    }
}
