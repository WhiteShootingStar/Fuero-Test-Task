using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletScript : MonoBehaviour
{
   
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 10f);
        Destroy(gameObject, 3f);   // since only player shoots, there is no nedd for object pooling for bullets
    }

}
