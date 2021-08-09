using System.Collections;
using UnityEngine;

public class JumpTipScript : MonoBehaviour
{
    [SerializeField] private GameObject jumpTip;

    private bool jumpTipIsActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jumpTip.SetActive(true);
            StartCoroutine(JumpTipCheckJump());
        }
    }

    public void OnJumpButtonForTips()
    {
        jumpTipIsActive = true;
    }

    private IEnumerator JumpTipCheckJump()
    {
        while (!jumpTipIsActive)
        {
            yield return null;
        }

        if (jumpTipIsActive)
        {
            jumpTip.SetActive(false);
            yield break;
        }
    }
}
