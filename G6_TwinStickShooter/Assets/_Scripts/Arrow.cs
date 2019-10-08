using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	public Rigidbody rb;

	private string _id;

	private bool deadArrow = false;

	// property for arrow ID
	public string ID
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
        
    }

	// called when arrow collides with another object
	private void OnCollisionEnter(Collision collision)
	{
		GameObject coll = collision.gameObject;
		
		if (coll.tag == "Player" && coll.name != ID && !deadArrow)
		{
			Destroy(coll);
			Destroy(this);
		}
		
		if (coll.tag == "Terrain")
		{
			rb.velocity = Vector3.zero;
			rb.useGravity = true;
			deadArrow = true;
		}
	}
}
