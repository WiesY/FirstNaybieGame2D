using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterHealth : MonoBehaviour
{ 
    [SerializeField] private int healthPoints = 3;
    private string trap = "Trap";

    private bool OnTrap = false;

    Rigidbody2D rb;

    [SerializeField] private GameObject healthPanel;

    private GameObject [] healthSprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        healthSprite = new GameObject [healthPanel.transform.childCount];

        for (int i = 0; i < healthSprite.Length; i++)
        {
            healthSprite[i] = healthPanel.transform.GetChild(i).gameObject;
        }
    }
    //public void TrapHit()
    //{
    //    if (healthPoints > 0)
    //    {
    //        healthSprite[3 - healthPoints].GetComponent<Animator>().SetTrigger("Trigger");
    //        var hitAnim = rb.velocity;
    //        hitAnim.y = 3;
    //        rb.velocity = hitAnim;

    //        healthPoints--;
    //        Debug.Log("-1");
    //    }
    //}
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(trap))
        {
            OnTrap = true;
            Debug.Log("1");
            //TrapHit();
        }
    }
    private void Update()
    {
        if (OnTrap)
        {
            Debug.Log("2");
            healthPoints--;
            var hitAnim = rb.velocity;
            hitAnim.y = 3;
            rb.velocity = hitAnim;
            healthSprite[healthSprite.Length - healthPoints].GetComponent<Animator>().SetTrigger("Trigger");

        }
        //ъ еаюк
        //щрн ме бнглнфмн
        
    }
}

