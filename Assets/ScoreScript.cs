using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score :" + Player.GetComponent<Player>().Score;
    }
}
