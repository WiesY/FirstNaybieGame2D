using UnityEngine;
using UnityEngine.UI;

public class SetJumpButtonScript : MonoBehaviour
{
    [SerializeField] private Sprite[] jumpSpritesForButton;
    [SerializeField] private GameObject mainCharacter;

    private PlayerController _playerController;

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

    private void Start()
    {
        _playerController = mainCharacter.transform.GetChild(0).gameObject.GetComponent<PlayerController>();
    }

    public void OnJumpButton()
    {
        if (_playerController != null)
            _playerController.Jump();
    }
}
