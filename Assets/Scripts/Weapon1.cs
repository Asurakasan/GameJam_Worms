using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    public MainG MainGame;
    public int Rebound, MaxRebound;
    public int IdBullet, playerID;
    // Start is called before the first frame update
    void Start()
    {
        Rebound = 0;
        IdBullet = MainGame.CurrentId;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rebound++;
        if (Rebound == MaxRebound)
        {
            Destroy(gameObject);
        }
        playerID = collision.gameObject.GetComponent<Player>().IdPlayer;

        if (playerID != IdBullet)
        {
            //Damage
        }

        //CollisionBullet = collision.gameObject;
        //IdBulletPlayer = CollisionBullet.GetComponent<Weapon1>().IdBullet;
    }

}
