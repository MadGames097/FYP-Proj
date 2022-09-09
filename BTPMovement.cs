using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTPMovement : MonoBehaviour
{
	// Movement
	public Animator animator;
	public float RunSpeed = 40f;
	public float JumpForce;
	private float HorizontalMove;
	private float MoveInput;
	private Rigidbody2D rb2d;
	private bool FacingRight = true;
	// jump/groundchk

	private bool IsGrounded;
	public Transform GroundChk;
	public float ChkRadius;
	public LayerMask WhatIsGround;
	// Extra jumps
	
	public int ExtraJumpsValue;
	private int ExtraJumps;
	// Dash mechanics + particles

	public float DashForce;
	public float StartDashTimer;
	private float CurrDashTimer;
	private float DashDirection;
	private bool IsDashing;
	public int DashCounter;
	private int DshCnt;
	public GameObject Particles;
	public GameObject Dirt;
	private void Start()
    {
		ExtraJumps = ExtraJumpsValue;
		DshCnt = DashCounter;
		rb2d = GetComponent<Rigidbody2D>();
		
	}
	void FixedUpdate()
	{
		

	}
    private void Update()
    {
		IsGrounded = Physics2D.OverlapCircle(GroundChk.position, ChkRadius, WhatIsGround);

		HorizontalMove = Input.GetAxisRaw("Horizontal") * RunSpeed;

		animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

		MoveInput = Input.GetAxis("Horizontal");
		rb2d.velocity = new Vector2(MoveInput * RunSpeed, rb2d.velocity.y);
		if (MoveInput > 0 && !FacingRight)
		{
			Flip();
		}
		else if (MoveInput < 0 && FacingRight)
		{
			Flip();
		}
		if (Input.GetKeyDown(KeyCode.LeftShift) && !IsGrounded && HorizontalMove != 0 && DshCnt>0)
		{
			IsDashing = true;
			CurrDashTimer = StartDashTimer;
			rb2d.velocity = Vector2.zero;
			//Debug.Log(HorizontalMove);
			DashDirection = (int)HorizontalMove;
			Instantiate(Particles, transform.position, Quaternion.identity);
			Instantiate(Dirt, transform.position, transform.rotation);
		}
		if (IsDashing)
		{
			DashDirection = (int)HorizontalMove;
			//Debug.Log(DashDirection);
			rb2d.velocity = Vector2.right * DashDirection * DashForce;
			//Debug.Log(transform.right * DashDirection * DashForce);
			CurrDashTimer -= Time.deltaTime;
			DshCnt--;
			if (CurrDashTimer <= 0)
			{
				IsDashing = false;
			}
		}

		if (IsGrounded)
        {
			ExtraJumps = ExtraJumpsValue;
			DshCnt = DashCounter;
			animator.SetBool("IsJumping", false);
        }
		if (Input.GetButtonDown("Jump") && ExtraJumps == 0 && IsGrounded)
		{
			animator.SetBool("IsJumping", true);
			JUMMP();
		//	Debug.Log("1st Ii jump : " + ExtraJumps);
		//	Debug.Log("1Grounded : " + IsGrounded);
		}
		if (Input.GetButtonDown("Jump") && ExtraJumps > 0)
		{
			animator.SetBool("IsJumping", true);
			JUMMP();
			ExtraJumps--;
		//	Debug.Log("2nd Ii jump : " + ExtraJumps);
		//	Debug.Log("2Grounded : " + IsGrounded);
		}
		



	}
    public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}


	private void Flip()
	{	
		FacingRight = !FacingRight;
		transform.Rotate(0f, 180f, 0f);
	}

	private void JUMMP()
    {
		rb2d.velocity = Vector2.up * JumpForce;
    }

}