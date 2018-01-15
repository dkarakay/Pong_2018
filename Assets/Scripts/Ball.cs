using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	public float speed = 30;
	public int playerRight, playerLeft;
    public Text ScoreLeft, ScoreRight;
    public GameObject restartButton,exitButton;
	// Use this for initialization
	void Awake () {
        Debug.Log("Awake");
        Time.timeScale = 1f;
		GetComponent<Rigidbody2D>().velocity = Vector2.right * 30;
	}
    void Update(){
        //Debug.Log("L: " + playerLeft);
		//Debug.Log("R: " + playerRight);
        ScoreLeft.text = "" + playerLeft;
        ScoreRight.text = "" + playerRight;

        if(playerLeft == 10 || playerRight == 10){
            Time.timeScale = 0f;
            restartButton.SetActive(true);
            exitButton.SetActive(true);
        }
	}

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }
	void OnCollisionEnter2D(Collision2D col) {
    // Note: 'col' holds the collision information. If the
    // Ball collided with a racket, then:
    //   col.gameObject is the racket
    //   col.transform.position is the racket's position
    //   col.collider is the racket's collider
    
    // Hit the left Racket?
    if (col.gameObject.name == "RacketLeft") {
        // Calculate hit Factor
        float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = new Vector2(1, y).normalized;
            speed += 4;
        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    // Hit the right Racket?
    else if (col.gameObject.name == "RacketRight") {
            // Calculate hit Factor
        float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = new Vector2(-1, y).normalized;
            speed += 4;
        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;

	}
      else if(col.gameObject.name == "WallRight"){
		playerLeft +=1;

    } else if(col.gameObject.name == "WallLeft"){
		playerRight += 1;
	}
}
	
}
