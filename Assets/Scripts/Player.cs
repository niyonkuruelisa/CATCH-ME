using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed;
    public float increment;
    public float maxY;
    public float minY;

    private Vector2 targetPos;

    public int health;

    public GameObject moveEffect;
    public Animator camAnim;
    public Text healthDisplay;

    public GameObject spawner;
    //public GameObject restartDisplay;

    public GameObject restartButton;
    //handle touch movements
    private float move = 0;

    private void Update()
    {

        if (health <= 0) {
            FindObjectOfType<AudioManager>().Play("failed");
            spawner.SetActive(false);
            //restartDisplay.SetActive(true);
            restartButton.SetActive(true);
            Destroy(gameObject);
        }

        healthDisplay.text = health.ToString();

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY || (move == 1 && transform.position.y < maxY) )
        {
            move = 0;
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY || (move == -1 && transform.position.y > minY))
        {
            move = 0;
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
        }

    }

    //Move With UI Controls
    public void OnMoveUpButtonClicked()
    {
        
        move = 1;
    }
    public void OnMoveDownButtonClicked()
    {
        move = -1;
    }
    public void StopMovement()
    {
        move = 0;
    }
}
