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

            if (numberIsland <= 5 && numberLevelsOfIsland == (numberIsland * 8 + 7))
            {
                InfoAboutApplication.OpenIslands[numberIsland + 1] = true;
            }

            if (numberLevelsOfIsland + 1 <= 55)
            {
                InfoAboutApplication.OpenLevels[numberLevelsOfIsland + 1] = true;
            }

            if (numberLevelsOfIsland == 0)
            {
                Social.ReportProgress("CgkI0pz-7K4UEAIQAw", 100.0f, (bool success) => { });
            }

            InfoAboutApplication.Money += FruitsScript.fruitScriptInstance.totalAmountOfFruits;

            Social.LoadAchievements(ach => {
                foreach (var achiev in ach)
                {
                    if (achiev.id == "CgkI0pz-7K4UEAIQAA" && achiev.percentCompleted < 100) // Collect 50 apples
                    {
                        Social.ReportProgress("CgkI0pz-7K4UEAIQAA", 100 / 50 * InfoAboutApplication.CountTakenFruits[0], (bool success) => { });
                    }
                }
            });

            GoogleServices.OpenSavedGame(true);
        }
    }
}