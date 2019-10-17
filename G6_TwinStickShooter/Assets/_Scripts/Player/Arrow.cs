using System;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
		Vector3 rotateVector = new Vector3(rb.velocity.normalized.x, 0, rb.velocity.normalized.z);
		if (!deadArrow)
		{
			transform.rotation = Quaternion.LookRotation(rotateVector, Vector3.up);
		}

		// destroy arrow if it exits play area
		if (Math.Abs(transform.position.z) > vertLimit || Math.Abs(transform.position.x) > horizLimit)
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

			//ArrowGame gameScript = Camera.main.GetComponent<ArrowGame>();
			//gameScript.GameOver();

			//float count = Time.time;
   //         float timeToWait = 3.0f;
			//while(count + timeToWait < Time.time)
			//{
                
   //         }
   //         SceneManager.LoadScene("Menus");

        }
		
		if (coll.tag == "Terrain")
		{
			rb.velocity = Vector3.zero;
			rb.useGravity = true;
			deadArrow = true;
			Destroy(this.gameObject, 3f);
		}
	}
}
