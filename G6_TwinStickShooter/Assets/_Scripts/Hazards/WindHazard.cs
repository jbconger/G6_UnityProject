using UnityEngine;

public class WindHazard : MonoBehaviour
{
	public float windStrength;
	public bool affectsPlayers = false;

	// applied once per frame while other is within the collider
	private void OnTriggerStay(Collider other)
	{
		if (affectsPlayers)
		{
			if (other.CompareTag("Player"))
			{
				Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
				rb.AddForce(transform.forward * windStrength, ForceMode.Impulse);
			}
			else
			{
				Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
				rb.AddForce(transform.forward * windStrength, ForceMode.Acceleration);
			}
		}
		else
		{
			if (other.CompareTag("Player"))
			{
				return;
			}

			Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
			rb.AddForce(transform.forward * windStrength, ForceMode.Acceleration);
		}
	}
}
