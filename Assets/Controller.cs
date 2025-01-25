using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public CharacterController characterController;
	private Vector3 moveDirection = Vector3.zero;
	public float speed = 6.0f;
	public Animator animator;
	public GameObject slay;
	public float rotationSpeed = 5f;
	public GameObject Slay;

	public bool canMove = true;

	// Use this for initialization
	void Start()
	{

	}

	void Attack()
	{
		if (Input.GetKeyDown("x"))
		{
			float horizontalInput = Input.GetAxis("Horizontal");
			float verticalInput = Input.GetAxis("Vertical");
			Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput);

			if (direction.magnitude > 0.1f)
			{
				Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
				slay.transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
				slay.transform.GetChild(0).GetComponent<Animator>().SetBool("play", true);
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
		Attack();
		float maxspd;
		if (Math.Abs(Input.GetAxis("Horizontal")) > Math.Abs(Input.GetAxis("Vertical")))
		{
			maxspd = Math.Abs(Input.GetAxis("Horizontal"));
		}
		else
		{
			maxspd = Math.Abs(Input.GetAxis("Vertical"));
		}
		animator.speed = maxspd;
		animator.SetFloat("x-dir", Input.GetAxis("Horizontal"));
		animator.SetFloat("y-dir", Input.GetAxis("Vertical"));
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		if (canMove) {
			characterController.Move(moveDirection * Time.deltaTime);
		}
	}
}
