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
	public float minArrowSpeed = 10f;
	public float maxArrowSpeed = 40f;
	public float maxChargeTime = 2f;
	public float timeBetweenShots = 1f;

	// PRIVATE FIELDS
	private float chargeSpeed;
	private float chargeTime;
	private float lastShotTime;
	private float currentCharge;

	private bool arrowDrawn;

	// ANIMATOR FIELDS
	private Animator anim;

    // AWAKE, START

    void Start()
    {
		anim = GetComponent<Animator>();

		foreach (var childAnimator in GetComponentsInChildren<Animator>())
		{
			if (childAnimator != anim)
			{
				anim.avatar = childAnimator.avatar;
				Destroy(childAnimator);
				break;
			}
		}

		chargeSpeed = (maxArrowSpeed - minArrowSpeed) / maxChargeTime;
		arrowDrawn = false;
	}

	// UPDATE

	void Update()
	{
		if (currentCharge >= maxArrowSpeed && arrowDrawn)
		{
			chargeIndicator.value = maxArrowSpeed;
		}
		else if (currentCharge < maxArrowSpeed && arrowDrawn)
		{
			currentCharge += chargeSpeed * Time.deltaTime;
			chargeIndicator.value = currentCharge;
		}
		else
		{
			chargeIndicator.value = minArrowSpeed;
		}
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
				arrowDrawn = true;

				// play sound
				drawArrowSound.Play();

				// animation
				anim.SetFloat("Aim", 1);
				break;

			case InputActionPhase.Canceled:
				if (Time.time > lastShotTime + timeBetweenShots)
					Firing();
				
				arrowDrawn = false;
				
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
<<<<<<< Updated upstream
=======
		arw.GetComponentInChildren<MeshRenderer>().material.color = playerColor;
		arw.GetComponentInChildren<TrailRenderer>().material.color = playerColor;
>>>>>>> Stashed changes
		rb.AddForce(firePoint.forward * currentCharge, ForceMode.Impulse);

		currentCharge = minArrowSpeed;

		Destroy(arw, 5f);
	}
<<<<<<< Updated upstream
=======

	// OTHER FUNCTIONS

	public void RespawnReset()
	{
		currentCharge = minArrowSpeed;
		isDead = false;
	}
>>>>>>> Stashed changes
}
