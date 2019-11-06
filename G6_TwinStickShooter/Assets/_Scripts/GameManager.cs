using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;

	public GameObject p1;
	public Transform p1Spawn;
	private int p1Score;
	
	public GameObject p2;
	public Transform p2Spawn;
	private int p2Score;

	public GameObject winMessage;

	public float roundStartDelay = 2f;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}

	public void RoundOver(Object go)
	{
		// Award win to the correct player
		if ((go.name.Equals("Player1")))
			p1Score++;
		else
			p2Score++;

		// show win message

		if (p1Score >= 2 || p2Score >= 2)
		{
			// end game
			//GameOver();
		}
		else
		{
			//Time.timeScale = 0f;
			// Reset positions
			//Respawn();
		}

		Invoke("Respawn", roundStartDelay);

	}

	void Respawn()
	{
		Debug.Log("We made it!");
		// destroy all arrows
		
		// disable win message

		p1.transform.position = p1Spawn.position;
		p2.transform.position = p2Spawn.position;
		
		//Time.timeScale = 1f;
	}

	void GameOver()
	{

	}
}
