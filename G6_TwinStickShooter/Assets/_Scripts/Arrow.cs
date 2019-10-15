using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{
	public Rigidbody rb;

	// screen bounds
	public float vertLimit, horizLimit;

	private int _id;

	private bool deadArrow = false;

	// property for arrow ID
	public int ID
	{
		get
		{
			return _id;
		}
		set
		{
			_id = value;
		}
	}

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
		Vector3 rotateVector = new Vector3(rb.velocity.normalized.x, 0, rb.velocity.normalized.z);
		transform.rotation = Quaternion.LookRotation(rotateVector, Vector3.up);

		// destroy arrow if it exits play area
		if (Math.Abs(transform.position.z) > vertLimit || transform.position.x > horizLimit)
			Destroy(this.gameObject);
    }

	// called when arrow collides with another object
	private void OnCollisionEnter(Collision collision)
	{
		GameObject coll = collision.gameObject;
		
		if (coll.tag == "Player" && coll.GetInstanceID() != ID && !deadArrow)
		{
			Destroy(coll);
			Destroy(this.gameObject);
		}
		
		if (coll.tag == "Terrain")
		{
			rb.velocity = Vector3.zero;
			rb.useGravity = true;
			deadArrow = true;
		}
	}
}
