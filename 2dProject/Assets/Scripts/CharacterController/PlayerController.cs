using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D playerObject;

    private float move = 0f;
    public float moveSpeed = 40f;

    bool jump = false;
    bool crouch = false;

    void Start()
    {
        
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal") * moveSpeed;
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }


        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    private void FixedUpdate()
    {
        playerObject.Move(move, crouch, jump);
        jump = false;
    }
}
