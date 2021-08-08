using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonsScript : MonoBehaviour
{
    public void OnLeftButtonDown()
    {
        PlayerController.playerController.leftMove = true;
        PlayerController.playerController.rightMove = false;
    }

    public void OnLeftButtonUp()
    {
        PlayerController.playerController.leftMove = false;
    }

    public void OnRightButtonDown()
    {
        PlayerController.playerController.rightMove = true;
        PlayerController.playerController.leftMove = false;
    }

    public void OnRightButtonUp()
    {
        PlayerController.playerController.rightMove = false;
    }
}