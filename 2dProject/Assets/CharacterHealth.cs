using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{ 
    [SerializeField] private int healthPoints = 3;

    public static CharacterHealth characterHealthInstance;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Image[] healthSprite;
    private GameObject healthPanel;
    private GameObject failPanel;

    private bool canHit = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        characterHealthInstance = this;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthPanel = transform.parent.GetComponent<SetCharacterScript>().hp;
        failPanel = transform.parent.GetComponent<SetCharacterScript>().failMenu;

        healthSprite = new Image[healthPanel.transform.childCount];

        for (int i = 0; i < healthSprite.Length; i++)
        {
            healthSprite[i] = healthPanel.transform.GetChild(i).GetComponent<Image>();
        }
    }

    public void EnemyHit()
    {
        if (healthPoints > 0 && canHit)
        {
            healthPoints--;
            healthSprite[healthPoints].GetComponent<Animator>().SetTrigger("Trigger");
            Invoke("RemoveHeart", 0.3f);
            var hitAnim = rb.velocity;
            hitAnim.x = 25f;
            hitAnim.y = 12f;
            rb.velocity = hitAnim;
            canHit = false;
            StartCoroutine(TakeHit());
            if (healthPoints == 0)
            {
                Time.timeScale = 0f;
                failPanel.SetActive(true);
            }
        }
    }

    public void TrapHit()
    {
        if (healthPoints > 0 && canHit)
        {
            healthPoints--;
            healthSprite[healthPoints].GetComponent<Animator>().SetTrigger("Trigger");
            Invoke("RemoveHeart", 0.3f);
            var hitAnim = rb.velocity;
            hitAnim.y = 12f;
            rb.velocity = hitAnim;
            canHit = false;
            StartCoroutine(TakeHit());
            if (healthPoints == 0)
            {
                Time.timeScale = 0f;
                failPanel.SetActive(true);
            }
        }
    }

    private void RemoveHeart()
    {
        healthSprite[healthPoints].enabled = false;
    }

    //private void HitReload()
    //{
    //    canHit = true;
    //}

    private IEnumerator TakeHit()
    {

        while (spriteRenderer.material.color.a > 0)
        {
            var tempColor = spriteRenderer.material.color;
            tempColor.a -= 0.001f;
            spriteRenderer.material.color = tempColor;
        }

        yield return new WaitForSeconds(0.1f);

        while (spriteRenderer.material.color.a < 1)
        {
            var tempColor = spriteRenderer.material.color;
            tempColor.a += 0.001f;
            spriteRenderer.material.color = tempColor;
        }

        yield return new WaitForSeconds(0.7f);

        canHit = true;
    }
}