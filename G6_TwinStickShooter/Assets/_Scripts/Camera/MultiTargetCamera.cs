using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultiTargetCamera : MonoBehaviour
{
	public List<Transform> targets;
	public Vector3 offset;
	
	public float smoothTime = 2f;

	public float minZoom = 20f;
	public float maxZoom = 10f;
	public float zoomLimiter = 2f;

	private Vector3 velocity;
	private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
		cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
		if (targets.Count == 0)
			return;

		var bounds = EncapsulateBounds();
		Move(bounds.center);
		Zoom(bounds.size.x);
    }

	private void Move(Vector3 bounds)
	{
		Vector3 newPosition = bounds + offset;
		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
	}

	void Zoom(float bounds)
	{
		float newZoom;

		if (bounds > minZoom)
			newZoom = Mathf.Lerp(maxZoom, minZoom, smoothTime);
		else if (bounds < maxZoom)
			newZoom = Mathf.Lerp(bounds, maxZoom, smoothTime);
		else
			newZoom = Mathf.Lerp(maxZoom, bounds, smoothTime);
		//float newZoom = Mathf.Lerp(maxZoom, bounds, smoothTime);
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
	}

	Bounds EncapsulateBounds()
	{
		var bounds = new Bounds(targets[0].position, Vector3.zero);
		for (int i = 0; i < targets.Count; i++)
		{
			bounds.Encapsulate(targets[i].position);
		}

		return bounds;
	}
}
