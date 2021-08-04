using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterHealth : MonoBehaviour
{ 
    [SerializeField] private int healthPoints = 3;

    public static CharacterHealth characterHealthInstance;

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
            hitAnim.y = 13f;
            rb.velocity = hitAnim;
            canHit = false;
            Invoke("HitReload", 0.35f);
            if (healthPoints == 0)
            {
                GetComponent<PlayerController>().enabled = false;
                rb.velocity = new Vector2(0, 0);
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
            hitAnim.y = 10f;
            rb.velocity = hitAnim;
            canHit = false;
            Invoke("HitReload", 0.35f);
            if (healthPoints == 0)
            {
                GetComponent<PlayerController>().enabled = false;
                rb.velocity = new Vector2(0, 0);
                failPanel.SetActive(true);
            }
        }
       
    }

    private void RemoveHeart()
    {
        healthSprite[healthPoints].enabled = false;
    }

    private void HitReload()
    {
        canHit = true;
    }
}

