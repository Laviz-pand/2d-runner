using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameoverScript : MonoBehaviour
{
    [SerializeField]
    GameObject gameovertext;
    bool isDead =false;

    float highscore;
    float currscore;
    [SerializeField]
    TextMeshProUGUI highscoretext;
    
    void Awake(){
        highscore = PlayerPrefs.GetFloat("highscr", 0);
        highscore = Mathf.Round(highscore *1.0f);
        highscoretext.text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isDead )
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("obstacle"))
        {
           Die(); 
        }
    }

    void Die(){
        gameovertext.SetActive(true);
        Time.timeScale = 0;
        isDead = true;
        HighScoreupdate();
    }

    void HighScoreupdate(){
        currscore = transform.position.x;
        if (currscore > highscore)
        {
            highscore = currscore;
            PlayerPrefs.SetFloat("highscr", highscore);
        }
    }
}
