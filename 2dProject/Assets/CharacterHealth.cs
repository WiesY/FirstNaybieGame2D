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
            Invoke("RemoveHeart", 0.35f);
            var hitAnim = rb.velocity;
            hitAnim.x = 25f;
            hitAnim.y = 12f;
            rb.velocity = hitAnim;
            canHit = false;
            StartCoroutine(TakeHit());
        }
    }

    public void TrapHit()
    {
        if (healthPoints > 0 && canHit)
        {
            healthPoints--;
            healthSprite[healthPoints].GetComponent<Animator>().SetTrigger("Trigger");
            Invoke("RemoveHeart", 0.35f);
            var hitAnim = rb.velocity;
            hitAnim.y = 12f;
            rb.velocity = hitAnim;
            canHit = false;
            StartCoroutine(TakeHit());
        }
    }

    public void HitWithMaxDamage()
    {
        if (healthPoints > 0)
        {
            try
            {
                healthSprite[healthPoints - 1]?.GetComponent<Animator>().SetTrigger("Trigger");
            }
            catch (System.Exception)
            {

            }

            try
            {
                healthSprite[healthPoints - 2]?.GetComponent<Animator>().SetTrigger("Trigger");
            }
            catch (System.Exception)
            {

            }

            try
            {
                healthSprite[healthPoints - 3]?.GetComponent<Animator>().SetTrigger("Trigger");
            }
            catch (System.Exception)
            {

            }
            
            healthPoints = 0;
            Invoke("RemoveAllHeart", 0.35f);
            gameObject.transform.localScale = new Vector2(0.001f, 0.001f);
        }
    }

    private void RemoveHeart()
    {
        Destroy(healthSprite[healthPoints]);
        if (healthPoints == 0)
        {
            Time.timeScale = 0f;
            failPanel.SetActive(true);
        }
        // healthSprite[healthPoints].enabled = false;
    }

    private void RemoveAllHeart()
    {
        Destroy(healthSprite?[2]);
        Destroy(healthSprite?[1]);
        Destroy(healthSprite?[0]);
        //Destroy(gameObject);
        Time.timeScale = 0f;
        failPanel.SetActive(true);
        // healthSprite[healthPoints].enabled = false;
    }

    private IEnumerator TakeHit()
    {
        while (spriteRenderer.material.color.a > 0)
        {
            var tempColor = spriteRenderer.material.color;
            tempColor.a -= 0.1f;
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