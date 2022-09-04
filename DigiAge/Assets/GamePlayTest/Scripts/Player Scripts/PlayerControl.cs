using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController PlayerControler;
    
    private float speed = 6f;
    private float TurnSmoothVelocity;
    private float TurnSmoothTime = 0.1f;

    public float GravityScale = -9.81f;
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    public float JumpPower = 3f;    

    private Vector3 Velcity;
    private bool isGrounded;
    private bool DoubleJump = false;
    public float DoubleJumpPower = 5f;
    private float basictimer = 0.01f;

    private int count = 0;
    
    //Dash & Movement
    public Vector3 moveDir;

    private void Awake()
    {
        PlayerControler = this.gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        Gravity();
        PlayerMovement();
        Jumping();
        DoubleJumping();
    }
    

    private void Jumping()
    {
        if (Input.GetButtonDown("Jump") && count ==0)
        {
            if (isGrounded == true)
            {
                Velcity.y = Mathf.Sqrt(JumpPower * -2f * GravityScale); 
                DoubleJump = true;
                count++;
            }
        }
    }
    private void DoubleJumping()
    {
        if (Input.GetButtonDown("Jump") && DoubleJump && count ==1 && !isGrounded)
        {
            Velcity.y = Mathf.Sqrt(DoubleJumpPower * -2f * GravityScale);
            DashEx.dashSpeed *= 2f;
            DoubleJump = false;
        }
    }
    private void Gravity()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded == true && Velcity.y < 0)
        {
            Velcity.y = -2f;
            count = 0;
        }
        
        Velcity.y += GravityScale * Time.deltaTime;
        PlayerControler.Move(Velcity * Time.deltaTime);
    }
    
    public void PlayerMovement()
    {
        float HorziontalAxes = Input.GetAxisRaw("Horizontal");
        float VerticalAxes = Input.GetAxisRaw("Vertical");
        Vector3 MoveDirection = new Vector3(HorziontalAxes, 0f, VerticalAxes).normalized;

        if (MoveDirection.magnitude >= 0.1f)
        {
            float TargetAngle = Mathf.Atan2(MoveDirection.x ,MoveDirection.z) * Mathf.Rad2Deg;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref TurnSmoothVelocity,
                TurnSmoothTime);
            
            moveDir = Quaternion.Euler(0, TargetAngle, 0) * Vector3.forward;
            transform.rotation = Quaternion.Euler(0f,Angle,0f);
            PlayerControler.Move(MoveDirection * speed * Time.deltaTime);
        }
    }
}
