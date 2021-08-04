using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterHealth : MonoBehaviour
{ 
    [SerializeField] private int healthPoints = 3;

    private bool OnTrap = false;
    private string trap = "Trap";

    private Rigidbody2D rb;
    private GameObject healthPanel;
    private GameObject[] healthSprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    private void Start()
    {
        healthPanel = transform.parent.GetComponent<SetCharacterScript>().hp;
        Debug.Log(healthPanel);

        healthSprite = new GameObject[healthPanel.transform.childCount];

        for (int i = 0; i < healthSprite.Length; i++)
        {
            healthSprite[i] = healthPanel.transform.GetChild(i).gameObject;
        }
    }

    public void TrapHit()
    {
        if (healthPoints > 0)
        {
            healthSprite[3 - healthPoints].GetComponent<Animator>().SetTrigger("Trigger");
            var hitAnim = rb.velocity;
            hitAnim.y = 3;
            rb.velocity = hitAnim;

            healthPoints--;
        }
    }
}

