using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _rb;

    public double speed;
    public double health;
    public int cashToEarn;

    private Vector2 directionToMove;
    
    private TextMeshProUGUI livesText;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        directionToMove = Vector2.right;
        livesText = GameObject.FindGameObjectWithTag("LivesText").GetComponent<TextMeshProUGUI>();
        speed = speed + (0.1*Globals.waveNum*Globals.waveNum);
        health = health + (0.1*Globals.waveNum*Globals.waveNum);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = directionToMove * (float)speed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "TurnUp": 
                transform.eulerAngles = new Vector3(0, 0, 90);
                directionToMove = Vector2.up;
                break;
            case "TurnDown": 
                transform.eulerAngles = new Vector3(0, 0, 270);
                directionToMove = Vector2.down;
                break;
            case "TurnRight": 
                transform.eulerAngles = new Vector3(0, 0, 0);
                directionToMove = Vector2.right;
                break;
            case "TurnLeft": 
                transform.eulerAngles = new Vector3(0, 180, 0);
                directionToMove = Vector2.left;
                break;
            case "End":
                UpdateLives();
                Destroy(this.gameObject, 1f);
                break;
        }
    }

    private void UpdateLives()
    {
        Globals.lives --;
        livesText.text = "Lives: " + Globals.lives.ToString();
        if (Globals.lives <= 0)
        {
            SceneManager.LoadScene("EndGame");
        }
        Destroy(this.gameObject, 1f);
    }
}
