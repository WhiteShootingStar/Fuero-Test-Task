using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float offsetZ = 7;



    private GameObject player;
    private bool isFound = false;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFound)
        {
            transform.position = player.transform.position - new Vector3(0, 0, offsetZ);
        }
        
    }

    public void Search()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isFound = true;
    }
    public void StopFollowing()
    {
        isFound = false;
    }
}
