using UnityEngine;
using UnityEngine.InputSystem;

public class RS_AimShoot : MonoBehaviour
{
	public Rigidbody rb;
	public Transform firePoint;
	public GameObject arrow;

	public float moveSpeed = 6f;
	public float baseArrowSpeed = 20f;
	public float maxCharge = 2f;

	private Vector2 i_move; //move vector
	private Vector2 i_look; //rotation vector
	private float chargeTime;

	// Update is called once per frame
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

	public void Fire(InputAction.CallbackContext ctx)
	{
		switch (ctx.phase)
		{
			case InputActionPhase.Performed:
				break;

			case InputActionPhase.Started:
				break;

			case InputActionPhase.Canceled:
				Firing();
				break;
		}
	}

	// INPUT HELPER FUNCTIONS

	void Moving()
	{
		Vector3 movement = new Vector3(i_move.x * moveSpeed, 0, i_move.y * moveSpeed);
		rb.AddForce(movement, ForceMode.Impulse);
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
		arw.GetComponent<Arrow>().ID = this.gameObject.name;
		rb.AddForce(firePoint.forward * baseArrowSpeed * chargeTime, ForceMode.Impulse);
		Destroy(arw, 5f);
	}
}
