using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindHazard : MonoBehaviour
{
	public float windStrength = 100f;

	//public float windSpin = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerStay(Collider other)
	{
		//GameObject thing = other.gameObject;
		Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
		rb.AddForce(Vector3.forward * windStrength, ForceMode.Acceleration);
		//rb.AddTorque(Vector3.up * windSpin);
		//thing.transform.Rotate(Vector3.up * windSpin);
	}
}
