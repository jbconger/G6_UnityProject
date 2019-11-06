using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	public Rigidbody rb;
	public BoxCollider cc;

	// screen bounds
	public float vertLimit, horizLimit;

	private bool deadArrow = false;

	// property for arrow ID
	public string ID { get; set; }

    // Update is called once per frame
    void Update()
    {
		Vector3 rotateVector = new Vector3(rb.velocity.normalized.x, 0, rb.velocity.normalized.z);
		if (!deadArrow && rotateVector != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(rotateVector, Vector3.up);
		}

		// destroy arrow if it exits play area
		//if (Math.Abs(transform.position.z) > vertLimit || Math.Abs(transform.position.x) > horizLimit)
		//	Destroy(this.gameObject);
    }

	// called when arrow collides with another object
	private void OnCollisionEnter(Collision collision)
	{
		GameObject coll = collision.gameObject;
		
		//if (coll.tag == "Player" && coll.GetInstanceID() != ID && !deadArrow)
		//{
		//	Destroy(coll);
		//	Destroy(this.gameObject);
  //      }
		
		if (coll.tag == "Terrain")
		{
			cc.enabled = false;
			rb.velocity = Vector3.zero;
			rb.useGravity = true;
			deadArrow = true;
			Destroy(this.gameObject, 3f);
		}
	}

	public bool IsDeadArrow()
	{
		return deadArrow;
	}
}
