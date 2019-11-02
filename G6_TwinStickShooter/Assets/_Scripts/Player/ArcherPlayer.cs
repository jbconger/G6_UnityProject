using UnityEngine;
using UnityEngine.InputSystem;

public class ArcherPlayer : MonoBehaviour
{
	public Rigidbody rbody;
	public GameObject arrow;
	public Transform firePoint;

	public float moveSpeed = 5f; //player move speed
	public float baseArrowSpeed = 20f; //arrow speed
	public float maxCharge = 3.0f;

	private bool isFallen = false;
	private bool arrowNotched = false;
	private bool arrowPulled = false;
	private float chargeTime;
	
	private Vector2 i_move; //move vector
	private Vector2 i_look; //rotation vector

	// Update is called once per frame
	void Update()
	{
		if (isFallen)
		{
			Debug.Log("You dead!");
			transform.position = new Vector3(0, 1.5f, 5);
			isFallen = false;
		}

		if (arrowPulled && chargeTime < maxCharge)
		{
			chargeTime += Time.deltaTime;
		}

		if (this.transform.position.y < -10)
			isFallen = true;
	}

	// Called 50 times per second - if I remember right
	void FixedUpdate()
	{
		Moving();
		Looking();
	}

	// INPUT FUNCTIONS

	public void Move(InputAction.CallbackContext ctx)
	{
		i_move = ctx.ReadValue<Vector2>();
	}

	public void Look(InputAction.CallbackContext ctx)
	{
		i_look = ctx.ReadValue<Vector2>();
	}

	public void DodgeRoll(InputAction.CallbackContext ctx)
	{
		//TODO
	}

	public void Fire(InputAction.CallbackContext ctx)
	{
		switch (ctx.phase)
		{
			case InputActionPhase.Performed:
				break;

			case InputActionPhase.Started:
				arrowNotched = true;
				break;

			case InputActionPhase.Canceled:
				if (arrowNotched && arrowPulled)
				{
					Firing();
				}

				arrowNotched = false;
				arrowPulled = false;

				break;
		}
	}

	public void PullArrow(InputAction.CallbackContext ctx)
	{
		switch (ctx.phase)
		{
			case InputActionPhase.Started:
				if (arrowNotched)
				{
					arrowPulled = true;
					chargeTime = 1.0f;
				}
				break;
			
			case InputActionPhase.Canceled:
				arrowPulled = false;
				break;
		}
	}

	// INPUT HELPER FUNCTIONS

	void Moving()
	{
		Vector3 movement = new Vector3(i_move.x * moveSpeed, 0, i_move.y * moveSpeed);
		rbody.AddForce(movement, ForceMode.Impulse);
	}

	void Looking()
	{
		Vector3 lookVector = (Vector3.right * i_look.x) + (Vector3.forward * i_look.y);
		if (!lookVector.Equals(Vector3.zero))	
			transform.rotation = Quaternion.LookRotation(-lookVector, Vector3.up);
	}
	void Firing()
	{
		GameObject arw = Instantiate(arrow, firePoint.position, firePoint.rotation);
		Rigidbody rb = arw.GetComponent<Rigidbody>();
		arw.GetComponent<Arrow>().ID = this.gameObject.GetInstanceID();
		rb.AddForce(firePoint.forward * baseArrowSpeed * chargeTime, ForceMode.Impulse);
		Destroy(arw, 5f);
	}
}
