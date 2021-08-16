using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private int numberIsland;
    [SerializeField] private int numberLevelsOfIsland;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject finishMenu;

    protected internal GameObject player;

    private bool isFinished = false;

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
        if (other.CompareTag("Player") && !isFinished)
        {
            isFinished = true;

            Time.timeScale = 0f;
            pauseButton.SetActive(false);
            finishMenu.SetActive(true);

            if (numberIsland <= 5 && numberLevelsOfIsland == (8 * (numberIsland + 1)) - 1)
            {
                InfoAboutApplication.OpenIslands[numberIsland + 1] = true;
            }

            if (numberLevelsOfIsland + 1 <= 55)
            {
                InfoAboutApplication.OpenLevels[numberLevelsOfIsland + 1] = true;
            }

            //var asd = PlayerPrefsX.GetBoolArray(nameIsland);
            //asd[numberLevelsOfIsland] = true;
            //PlayerPrefsX.SetBoolArray(nameIsland, asd);

            InfoAboutApplication.Money += FruitsScript.fruitScriptInstance.totalAmountOfFruits;

            GoogleServices.OpenSavedGame(true);
        }
    }
}