using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public PointsTeleport[] pointsToTeleport;

    private Animator ghostAnimator;

    private float timeToTeleport = 10f;

    private void Awake()
    {
        ghostAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(Teleport());
    }

    private IEnumerator Teleport()
    {
        int randomPointToTeleport = Random.Range(0, pointsToTeleport.GetLength(0));

        ghostAnimator.SetTrigger("StartTP");
        yield return new WaitForSeconds(0.5f);
        //transform.position = new Vector2(pointsToTeleport[randomPointToTeleport, 0].position.x, pointsToTeleport[randomPointToTeleport, 1].position.y);
        ghostAnimator.SetTrigger("EndTP");

        yield return new WaitForSeconds(timeToTeleport);
    }
}

public class PointsTeleport
{
    public Transform point1;
    public Transform point2;
}