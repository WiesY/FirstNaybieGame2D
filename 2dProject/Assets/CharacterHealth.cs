using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterHealth : MonoBehaviour
{ 
    [SerializeField] private int healthPoints = 3;

    private Rigidbody2D rb;
    private GameObject healthPanel;
    private Image[] healthSprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    private void Start()
    {
        healthPanel = transform.parent.GetComponent<SetCharacterScript>().hp;

        healthSprite = new Image[healthPanel.transform.childCount];

        for (int i = 0; i < healthSprite.Length; i++)
        {
            healthSprite[i] = healthPanel.transform.GetChild(i).GetComponent<Image>();
        }
    }

    public void TrapHit()
    {
        if (healthPoints > 0)
        {
            healthSprite[3 - healthPoints].GetComponent<Animator>().SetTrigger("Trigger");
            healthSprite[3 - healthPoints].enabled = false;
            var hitAnim = rb.velocity;
            hitAnim.y = 3;
            rb.velocity = hitAnim;

            healthPoints--;
        }
        else
        {
            Debug.Log("Lose");
        }
    }
}

