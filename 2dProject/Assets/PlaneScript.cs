using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlaneScript : MonoBehaviour
{
    [SerializeField] private GameObject[] pointsToMove;

    public void ActivatePlane()
    {
        StartCoroutine(MovePlane());
    }

    private IEnumerator MovePlane()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            while (transform.position.x < pointsToMove[1].transform.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, pointsToMove[1].transform.position, 0.035f);
                yield return null;
            }

            yield return new WaitForSeconds(2.35f);

            while (transform.position.x > pointsToMove[0].transform.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, pointsToMove[0].transform.position, 0.035f);
                yield return null;
            }
        }
    }
}