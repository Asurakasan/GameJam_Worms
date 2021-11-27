using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainG : MonoBehaviour
{
    public static MainG Instance;

    public Player Scp_Player;
    
    public GameObject[] O_Player;
    public GameObject[] O_Spawner;
    public GameObject[] player;

    
    public float TimerRound, StopRound;

    public int CurrentId;
    public bool test;
    private int MaxLenght;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {

        MaxLenght = player.Length - 1;
        
        for (int i = 0; i < O_Player.Length; i++)
        {
            Scp_Player.IdPlayer++;
        }
        for (int y = 0; y < O_Player.Length; y++)
        {
            Vector3 pose = new Vector3(O_Spawner[y].transform.position.x, O_Spawner[y].transform.position.y, 0);
            player[y] = Instantiate(O_Player[y], pose, Quaternion.identity);
            player[y].GetComponent<Player>().IdPlayer = y;
        }

        player[0].GetComponent<Player>().CanMove = true;
        player[0].GetComponent<Shooting>().CanShoot = true;
        player[0].GetComponent<Shooting>().weapon1 = true;
    }

    // Update is called once per frame
    void Update()
    {
      

        TimerRound += Time.deltaTime;
       
        if (TimerRound >= StopRound)
        {
            CurrentId++;

            if (CurrentId > MaxLenght)
            {
                CurrentId = 0;
            }

            TimerRound = 0;


            for (int i = 0; i < player.Length; i++)
            {
                if (CurrentId == player[i].GetComponent<Player>().IdPlayer)
                {
                    player[i].GetComponent<Player>().CanMove = true;
                    player[i].GetComponent<Shooting>().CanShoot = true;
                    test = true;
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        player[i].GetComponent<Shooting>().weapon1 = true;
                        player[i].GetComponent<Shooting>().weapon2 = false;
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        player[i].GetComponent<Shooting>().weapon1 = false;
                        player[i].GetComponent<Shooting>().weapon2 = true;
                    }
                }
                else
                {
                    player[i].GetComponent<Player>().CanMove = false;
                    player[i].GetComponent<Shooting>().CanShoot = false;
                    player[i].GetComponent<Shooting>().weapon1 = false;
                    player[i].GetComponent<Shooting>().weapon2 = false;
                    player[i].GetComponent<Player>().rb.velocity = new Vector2(0, 0);
                }
            }

        }
  
           
    }

   

    
   
}
