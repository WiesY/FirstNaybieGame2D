using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{

    public int SceneNumber;

    public void ToLevels()
    {
        
        SceneManager.LoadScene(SceneNumber);
    }
}
