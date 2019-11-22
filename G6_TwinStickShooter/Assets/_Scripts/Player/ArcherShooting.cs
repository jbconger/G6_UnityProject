using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ArcherShooting : MonoBehaviour
{
	// REFERENCES
	public GameObject arrow;
	public Transform firePoint;
	public AudioSource drawArrowSound;
	public Slider chargeIndicator;

	// PUBLIC FIELDS
	[HideInInspector] public int playerNumber = 1;
	public float baseArrowSpeed = 20f;
	public float chargeDuration = 2f;
	public float timeBetweenShots = 1f;

	// PRIVATE FIELDS
	private float chargeTime;
	private float lastShotTime;

	// ANIMATOR FIELDS
	private Animator anim;

    // AWAKE, START

    void Start()
    {
		anim = GetComponent<Animator>();
	}

	// INPUT HANDLERS

	public void Fire(InputAction.CallbackContext ctx)
	{
		switch (ctx.phase)
		{
			case InputActionPhase.Performed:
				break;

			case InputActionPhase.Started:
				chargeTime = Time.time;

				// play sound
				drawArrowSound.Play();

				// animation
				anim.SetFloat("Aim", 1);
				break;

			case InputActionPhase.Canceled:
				if (Time.time > lastShotTime + timeBetweenShots)
					Firing();
				
				// animation
				anim.SetFloat("Aim", 0);
				break;
		}
	}

	void Firing()
	{
		lastShotTime = Time.time;

		GameObject arw = Instantiate(arrow, firePoint.position, firePoint.rotation);
		Rigidbody rb = arw.GetComponent<Rigidbody>();
		arw.GetComponent<Arrow>().ID = playerNumber;

		if (Time.time - chargeTime <= 0.2)
		{
			rb.AddForce(firePoint.forward * baseArrowSpeed * 0.5f, ForceMode.Impulse);

		}
		else if (Time.time - chargeTime <= chargeDuration)
		{
			//rb.useGravity = false;
			rb.AddForce(firePoint.forward * baseArrowSpeed * (Time.time - chargeTime + 0.5f), ForceMode.Impulse);
		}
		else
		{
			//rb.useGravity = true;
			rb.AddForce(firePoint.forward * baseArrowSpeed * chargeDuration, ForceMode.Impulse);
		}

		Destroy(arw, 5f);
	}
}
