using UnityEngine;
using UnityEngine.UI;

public class FruitsScript : MonoBehaviour
{
    private Text fruitsCountText;

    private void Awake()
    {
        fruitsCountText = transform.GetChild(1).GetComponent<Text>();
    }
}