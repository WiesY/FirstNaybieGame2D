using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public string playerTag;
    public Rigidbody2D playerRb;
    public PlayerController playerScript;
    public Canvas canvas;

    private bool isFinished = false;

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
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            isFinished = true;
            canvas.enabled = true;
        }
    }
}
