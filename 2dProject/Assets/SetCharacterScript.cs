using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacterScript : MonoBehaviour
{
    [SerializeField] private GameObject[] allSkins;
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;
    [SerializeField] private Finish finish;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SelectedSkin"))
        {
            SelectSkin(PlayerPrefs.GetInt("SelectedSkin"));
        }
        else
        {
            SelectSkin(0);
        }
    }

    private void SelectSkin(int indexSkin)
    {
        var character = Instantiate(allSkins[indexSkin], transform);

        cinemachineCamera.Follow = character.transform;
        finish.player = character;
    }
}
