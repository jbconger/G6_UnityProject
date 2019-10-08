using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowGame : MonoBehaviour
{
	private GameObject[] players;

	private bool roundOver = false;

    // Start is called before the first frame update
    void Awake()
    {
		players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (players.Length == 1)
		{
			roundOver = true;
		}

		if (roundOver)
		{
			SceneManager.LoadScene("RoundOver");
		}
    }
}
