using UnityEngine;
using UnityEngine.UI;

public class SetJumpButtonScript : MonoBehaviour
{
    [SerializeField] private Sprite[] jumpSpritesForButton;
    [SerializeField] private GameObject mainCharacter;

    private PlayerController _playerController;
    private bool buttonDown;

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

    private void Update()
    {
        if (buttonDown)
            _playerController.Jump();
    }

    public void OnJumpButtonDown()
    {
        buttonDown = true;
    }

    public void OnJumpButtonUp()
    {
        buttonDown = false;
    }
}