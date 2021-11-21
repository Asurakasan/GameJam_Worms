using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    public int Rebound, MaxRebound;
    // Start is called before the first frame update
    void Start()
    {
        Rebound = 0;   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rebound++;
        if(Rebound == MaxRebound)
        {
            Destroy(gameObject);
        }
    }
}
