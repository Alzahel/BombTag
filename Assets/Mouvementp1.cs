using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouvementp1 : MonoBehaviour
{


	private Vector2 moveInput;


	private Rigidbody2D rbPlayer;
	[SerializeField]
	public float speed;
	public float slowSpeed;
	public float memorySpeed;
	private float angle;

	public bool isStun = false;

	public Animator anim;


	// Start is called before the first frame update
	void Start()
	{
		rbPlayer = this.GetComponent<Rigidbody2D>();
		memorySpeed = speed;
	}


	// Update is called once per frame
	void Update()
	{
		Move();
	}

	public void OnMovement(InputValue value)
	{
		moveInput = value.Get<Vector2>();
	}

	void Move()
	{

		if (isStun)
		{
			rbPlayer.velocity = new Vector2(0, 0);
			return;
		}
		rbPlayer.velocity = moveInput * speed;
		if (moveInput.x != 0 || moveInput.y != 0)
		{
			angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
		}

		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

		MoveAnimation();
	}

	private void MoveAnimation()
	{
		if (moveInput == new Vector2(0, 0))
		{
			anim.SetBool("isMoving", false);
		}
		else
		{
			anim.SetBool("isMoving", true);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.tag == "Eau")
		{

			speed -= slowSpeed;
			//Debug.Log(speed);

		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Eau")
		{
			speed += slowSpeed;
			//Debug.Log(speed);

		}

	}

}
