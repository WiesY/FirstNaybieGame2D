using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadScript : MonoBehaviour
{
    private Animator spikeHeadAnimator;

    private void Awake()
    {
        spikeHeadAnimator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spikeHeadAnimator.SetBool("Hitting", true);
            CharacterHealth.characterHealthInstance.TrapHit();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spikeHeadAnimator.SetBool("Hitting", false);
        }
    }
}
