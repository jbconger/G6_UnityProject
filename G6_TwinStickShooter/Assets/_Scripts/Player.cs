using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // player rigidbody
    public Rigidbody rbody;

	// move speed of player
	public float moveSpeed = 5f;

	// vectors for moving and rotating player
	Vector2 moveStick;
	Vector2 rotateStick;

	// arrow and fire point
	public GameObject arrowPrefab;
	public Transform firePoint;
    private bool arrowNotched = false;
    private bool arrowPulled = false;
    private float chargeTime;
    public bool useComplex;

	// arrow speed
	public float arrowSpeed = 20f;

	void Awake()
	{

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

	}

	// Right trigger is released
	void OnFire()
	{
        //uses complex controls
        if (useComplex)
        {
            if (arrowNotched && arrowPulled)
            {
                GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
                Rigidbody rb = arrow.GetComponent<Rigidbody>();
                arrow.GetComponent<Arrow>().ID = this.name;
                rb.AddForce(firePoint.forward * -arrowSpeed, ForceMode.Impulse);

                arrowPulled = false;
            }

            arrowNotched = false;
        }
        //uses simple controls
        else
        {
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            arrow.GetComponent<Arrow>().ID = this.name;
            rb.AddForce(firePoint.forward * -arrowSpeed, ForceMode.Impulse);
        }
    }

	void OnMove(InputValue value)
	{
		Vector2 moveStick = value.Get<Vector2>();
		Vector3 movement = new Vector3(moveStick.x * moveSpeed, 0, moveStick.y * moveSpeed);
        rbody.AddForce(movement, ForceMode.Impulse);
        //transform.Translate(movement, Space.World);
	}

	void OnRotate(InputValue value)
	{
		rotateStick = value.Get<Vector2>();
		Vector3 rotateVector = (Vector3.right * rotateStick.x) + (Vector3.forward * rotateStick.y);
		transform.rotation = Quaternion.LookRotation(rotateVector, Vector3.up);
	}

	void OnDodgeRoll()
	{

	}

    void OnNotchArrow()
    {
        arrowNotched = true;
        //TODO start timer
    }

    void OnPullArrow()
    {
        if (arrowNotched)
            arrowPulled = true;
    }
}
