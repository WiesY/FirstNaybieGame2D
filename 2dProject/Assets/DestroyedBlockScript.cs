using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedBlockScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(DeleteDestoyedObjects());
    }

    private IEnumerator DeleteDestoyedObjects()
    {
        yield return new WaitForSeconds(5f);

        while (spriteRenderer.color.a > 0)
        {
            var tempColor = spriteRenderer.color;
            tempColor.a -= 0.007f;
            spriteRenderer.color = tempColor;
            yield return null;
        }

        Destroy(gameObject);
    }
}
