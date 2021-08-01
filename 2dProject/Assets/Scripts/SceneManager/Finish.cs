using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public string playerTag;
    public GameObject player;
    public GameObject pauseButton;
    public GameObject finishMenu;

    private Rigidbody2D playerRb;
    private PlayerController playerScript;    

    private bool isFinished = false;

    private void Awake()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
        playerScript = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (isFinished && playerRb.velocity.magnitude > 0)
        {
            var move = playerRb.velocity;
            move.x -= 0.1f;
            playerRb.velocity = move;
            if (move.x < 0)
            {
                move.x = 0f;
                playerRb.velocity = move;
                playerScript.enabled = false;
            }
            pauseButton.SetActive(false);
            finishMenu.SetActive(true);                  
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            isFinished = true;            
        }
    }
}
