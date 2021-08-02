using UnityEngine;
using UnityEngine.UI;

public class SetJumpButtonScript : MonoBehaviour
{
    [SerializeField] public Sprite[] jumpSpritesForButton;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SelectedSkin"))
        {
            transform.Find("Jump Button").Find("Jump Image").GetComponent<Image>().sprite = jumpSpritesForButton[PlayerPrefs.GetInt("SelectedSkin")];
        }
        else
        {
            transform.Find("Jump Button").Find("Jump Image").GetComponent<Image>().sprite = jumpSpritesForButton[0];
        }
    }
}
