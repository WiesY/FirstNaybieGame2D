using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Level()
    {
        SceneManager.LoadScene(3);
    }
    
    public void back()
    {
        SceneManager.LoadScene(1);
    }
}
