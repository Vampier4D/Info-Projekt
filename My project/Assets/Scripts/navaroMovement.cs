using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navaroMovement : MonoBehaviour {

    public CharacterController2D controllerNavaro;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public float runSpeed = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }else if(Input.GetButtonUp("Jump"))
        {
            jump= false;
        }
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch= false;

        }
    }
    private void FixedUpdate()
    {
        controllerNavaro.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
    