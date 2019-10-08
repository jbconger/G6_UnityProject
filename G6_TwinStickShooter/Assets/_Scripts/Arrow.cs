using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	PlayerControls controls;

	public float arrowSpeed = 5f;

    // Start is called before the first frame update
    void Awake()
    {
		controls = new PlayerControls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// Enables controls
	void OnEnable()
	{
		controls.Gameplay.Enable();
	}

	// Disables controls
	void OnDisable()
	{
		controls.Gameplay.Disable();
	}
}
