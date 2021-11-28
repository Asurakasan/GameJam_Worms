using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    
    public GameObject Bullet1, Bullet2, CollisionObject;
    public Transform FirePosition;
    public float BulletSpeed;
    public bool CanShoot, weapon1, weapon2;
    Vector2 lookdirection;
    float lookangle;
    

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
        lookdirection = Camera.main.WorldToScreenPoint(Input.mousePosition);
        lookangle = Mathf.Atan2(lookdirection.y, lookdirection.x) * Mathf.Rad2Deg;

        FirePosition.rotation = Quaternion.Euler(0, 0, lookangle);
        if (weapon1)
        {
            if (Input.GetMouseButtonDown(0) && CanShoot)
            {
                GameObject bullet1Clone = Instantiate(Bullet1);
                bullet1Clone.transform.position = FirePosition.position;
                bullet1Clone.transform.rotation = Quaternion.Euler(0, 0, lookangle);

                bullet1Clone.GetComponent<Rigidbody2D>().velocity = FirePosition.right * BulletSpeed;
            }
        }
        if (weapon2)
        {
            if (Input.GetMouseButtonDown(0) && CanShoot)
            {
                GameObject bullet2Clone = Instantiate(Bullet2);
                bullet2Clone.transform.position = FirePosition.position;
                bullet2Clone.transform.rotation = Quaternion.Euler(0, 0, lookangle);

                bullet2Clone.GetComponent<Rigidbody2D>().velocity = FirePosition.right * BulletSpeed;
            }
        }
    }

    
}
