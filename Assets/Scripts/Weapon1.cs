using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    public GameObject MainGame;
    public GameObject CurrentPlayer;
    public GameObject Versus;
    public int Rebound, MaxRebound;
    public int IdBullet, playerID;
    // Start is called before the first frame update
    void Start()
    {
        Rebound = 0;
        MainGame = GameObject.Find("_MainGame");

        IdBullet = MainGame.GetComponent<MainG>().CurrentId;

    }
    void Update()
    {
        CurrentPlayer = MainGame.GetComponent<MainG>().player[IdBullet];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rebound++;
        if (Rebound == MaxRebound)
        {
            Destroy(gameObject);
        }
        playerID = collision.gameObject.GetComponent<Player>().IdPlayer;
        if(collision.collider.CompareTag("Player"))
        {
            Versus = collision.gameObject;
            if (playerID != IdBullet)
            {
                Versus.GetComponent<Player>().Pv -= 5;
                CurrentPlayer.GetComponent<Player>().Score += 10;
            }
        }
        if (collision.collider.CompareTag("Coeur"))
        {
            if (playerID != IdBullet)
            {
                
                CurrentPlayer.GetComponent<Player>().Score += 25;
            }
        }
        
    }

}
