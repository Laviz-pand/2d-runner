using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class playerMovement : MonoBehaviour
{
    public TextMeshProUGUI score;
    public float playerSpeed;
    [SerializeField]

    void Awake(){
        Time.timeScale = 1;
    }
    void Update(){
        
        Movement();
        var scorey = transform.position.x;
        scorey = Mathf.Round(scorey *1.0f);
        score.text = scorey.ToString();
    }

    void Movement(){
        transform.position += new Vector3(playerSpeed,0 ,0 ) * Time.deltaTime;
    }
}
