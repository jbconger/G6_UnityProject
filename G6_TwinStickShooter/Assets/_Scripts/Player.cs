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
	Vector2 move;
	Vector2 rotate;

    void Awake() 
    {
        controls = new PlayerControls();

        controls.Gameplay.Grow.performed += ctx => Grow();

		controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
		controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

		controls.Gameplay.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
		// on release, fire arrow
		controls.Gameplay.Rotate.canceled += ctx => rotate = Vector2.zero;
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
		Vector3 m = new Vector3(move.x * moveSpeed, 0, move.y * moveSpeed) * Time.deltaTime;
		transform.Translate(m, Space.World);

		Vector3 r = new Vector3(0, rotate.x) * 100f * Time.deltaTime;
		transform.Rotate(r, Space.World);
	}

    // Increases the size of the player object - just for fun, will be removed or replaced
    void Grow()
    {
        transform.localScale *= 1.1f;
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
