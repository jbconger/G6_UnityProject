using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	// gamepad input object
    PlayerControls controls;

	// move speed of player
	public float moveSpeed = 5f;

	// vectors for moving and rotating player
	Vector2 moveStick;
	Vector2 rotateStick;

	// arrow and fire point
	public GameObject arrowPrefab;
	public Transform firePoint;

	// arrow speed
	public float arrowSpeed = 20f;
	bool arrowDrawn;

	void Awake()
	{
		controls = new PlayerControls();

		controls.Gameplay.Move.performed += ctx => moveStick = ctx.ReadValue<Vector2>();
		controls.Gameplay.Move.canceled += ctx => moveStick = Vector2.zero;

		controls.Gameplay.Rotate.performed += ctx => rotateStick = ctx.ReadValue<Vector2>();
		// on release, fire arrow
		controls.Gameplay.Rotate.canceled += ctx => rotateStick = Vector2.zero;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
    }

    // Called 50 times per second - if I remember right
    void FixedUpdate()
    {
		Vector3 moveVector = new Vector3(moveStick.x * moveSpeed, 0, moveStick.y * moveSpeed) * Time.deltaTime;
		transform.Translate(moveVector, Space.World);

		Vector3 rotateVector = (Vector3.right * rotateStick.x) + (Vector3.forward * rotateStick.y);
		if (rotateVector.sqrMagnitude > 0.0f)
		{
			transform.rotation = Quaternion.LookRotation(rotateVector, Vector3.up);

			if (arrowDrawn)
			{
				if (rotateVector.sqrMagnitude < 0.9)
				{
					ShootArrow();
					arrowDrawn = false;
				}
			}
			else
			{
				if (rotateVector.sqrMagnitude == 1.0)
				{
					arrowDrawn = true;
					//start timer
				}
			}
		}	
	}

	// Fires an arrow from the player firepoint
	void ShootArrow()
	{
		GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);	
		Rigidbody rb = arrow.GetComponent<Rigidbody>();
		arrow.GetComponent<Arrow>().ID = this.name;
		rb.AddForce(firePoint.forward * -arrowSpeed, ForceMode.Impulse);
	}


	// Enables controls
	void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    // Disables controls
    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
