using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private string nameIsland;
    [SerializeField] private int numberLevelsOfIsland;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject finishMenu;

    protected internal GameObject player;

    private Rigidbody2D playerRb;
    private PlayerController playerScript;    

    private bool isFinished = false;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
        playerScript = player.GetComponent<PlayerController>();
    }

    //void Update()
    //{
    //    if (isFinished && playerRb.velocity.magnitude > 0)
    //    {
    //        var move = playerRb.velocity;
    //        move.x -= 0.1f;
    //        playerRb.velocity = move;
    //        if (move.x < 0)
    //        {
    //            move.x = 0f;
    //            playerRb.velocity = move;
    //            playerScript.enabled = false;
    //        }
                            
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            isFinished = true;
            pauseButton.SetActive(false);
            finishMenu.SetActive(true);
            var asd = PlayerPrefsX.GetBoolArray(nameIsland);
            asd[numberLevelsOfIsland] = true;
            PlayerPrefsX.SetBoolArray(nameIsland, asd);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + FruitsScript.fruitScriptInstance.totalAmountOfFruits);
        }
    }
}