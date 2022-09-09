using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	public Animator animator;
	public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	private int ExtraJumps;
	public int ExtraJumpsValue;



	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
			controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		}

	//	if (Input.GetButtonDown("Crouch"))
	//	{
	//		crouch = true;
	//		animator.SetBool("IsCrouch", true);
	//	}
	//	else if (Input.GetButtonUp("Crouch"))
	//	{
	//		crouch = false;
	//	}

	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
		jump = false;
	}

	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("IsCrouch", isCrouching);
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		
	}
	

}