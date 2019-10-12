﻿using UnityEngine;

public class WindHazard : MonoBehaviour
{
	public float windStrength;

	// applied once per frame while other is within the collider
	private void OnTriggerStay(Collider other)
	{
		Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
		rb.AddForce(Vector3.forward * windStrength, ForceMode.Acceleration);
	}
}
