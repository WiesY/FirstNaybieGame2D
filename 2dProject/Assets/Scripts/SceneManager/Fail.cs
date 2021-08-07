using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail : MonoBehaviour
{
    public GameObject FailMenu;
    public string PlayerTag;
    
    private void OnTriggerEnter2D(Collider2D playerObject)
    {
        if (playerObject.CompareTag(PlayerTag))
        {
            Time.timeScale = 0f;
            FailMenu.SetActive(true);
        }
    }
}
