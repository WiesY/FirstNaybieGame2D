using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacterScript : MonoBehaviour
{
    [SerializeField] private GameObject[] allSkins;
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Finish finish;

    protected internal GameObject hp;

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

        hp = canvas.transform.Find("HealthPoints").gameObject;
    }

    private void SelectSkin(int indexSkin)
    {
        var character = Instantiate(allSkins[indexSkin], transform);

        cinemachineCamera.Follow = character.transform;
        finish.player = character;
    }
}
