using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacterScript : MonoBehaviour
{
    public GameObject[] allSkins;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SelectedSkin"))
        {
            Instantiate(allSkins[PlayerPrefs.GetInt("SelectedSkin")], transform);
        }
        else
        {
            Instantiate(allSkins[0], transform);
        }
    }
}
