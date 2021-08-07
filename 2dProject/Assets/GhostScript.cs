using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    [SerializeField] private PointsTeleport[] pointsToTeleport;

    private Animator ghostAnimator;
    private AudioSource audioSource;

    private float timeToTeleport = 5f;
    private bool canHit = true;

    private void Awake()
    {
        ghostAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(Teleport());
    }

    private IEnumerator Teleport()
    {
        while (true)
        {
            int randomPointToTeleport = Random.Range(0, pointsToTeleport.Length);

            if (!ghostAnimator.GetBool("StartTP"))
            {
                ghostAnimator.SetBool("StartTP", true);
                canHit = false;
            }
            yield return new WaitForSeconds(1f);
            transform.position = new Vector2(Random.Range(pointsToTeleport[randomPointToTeleport].point1.position.x, pointsToTeleport[randomPointToTeleport].point2.position.x), pointsToTeleport[randomPointToTeleport].point1.position.y);
            ghostAnimator.SetTrigger("EndTP");
            ghostAnimator.SetBool("StartTP", false);
            canHit = true;

            yield return new WaitForSeconds(timeToTeleport);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canHit)
        {
            CharacterHealth.characterHealthInstance.EnemyHit();
            audioSource.Play();
            ghostAnimator.SetBool("StartTP", true);
            canHit = false;
        }
    }
}

[System.Serializable]
public class PointsTeleport
{
    [SerializeField] protected internal Transform point1;
    [SerializeField] protected internal Transform point2;
}