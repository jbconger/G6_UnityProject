using UnityEngine;

public class Arrow : MonoBehaviour
{
	public Rigidbody rb;
	public BoxCollider cc;

	private bool deadArrow = false;

	// property for arrow ID
	public int ID { get; set; }

    // Update is called once per frame
    void Update()
    {
		Vector3 rotateVector = new Vector3(rb.velocity.normalized.x, 0, rb.velocity.normalized.z);
		if (!deadArrow && rotateVector != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(rotateVector, Vector3.up);
		}
    }

	// called when arrow collides with another object
	private void OnCollisionEnter(Collision collision)
	{
		GameObject coll = collision.gameObject;
	
		if (coll.tag != "Player")
		{
			cc.enabled = false;
			rb.velocity = Vector3.zero;
			//rb.useGravity = true;
			deadArrow = true;
			Destroy(this.gameObject, 2f);
		}
	}

	public bool IsDeadArrow()
	{
		return deadArrow;
	}
}
