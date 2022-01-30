using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpeedManager : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    public float speed;
    [SerializeField]
    playerMovement plm;
    float score;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = Player.transform.position.x;
        if (score> 100)
        {
            plm.playerSpeed = 7;
        }   
    }
  
}
