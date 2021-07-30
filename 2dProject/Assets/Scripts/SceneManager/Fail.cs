using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail : MonoBehaviour
{
    public GameObject FailMenu;
    public string PlayerTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D playerObject)
    {
        if (playerObject.CompareTag(PlayerTag))
        {
            FailMenu.SetActive(true);
        }
    }
}
