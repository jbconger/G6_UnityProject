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

	public GameObject roundOverUI;

	public int pointsToWin = 3;
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
			p2Score++;
		else
			p1Score++;

		// show win message

		if (p1Score >= pointsToWin || p2Score >= pointsToWin)
		{
			// end game
			GameOver();
		}
		else
		{
			//Time.timeScale = 0f;
			// Reset positions
			Invoke("Respawn", roundStartDelay);
		}

		//Invoke("Respawn", roundStartDelay);

	}

	void Respawn()
	{
		Debug.Log("Respawning");
		// destroy all arrows

		p1.transform.position = p1Spawn.position;
		p2.transform.position = p2Spawn.position;
		
		Time.timeScale = 1f;
	}

	public void PlayAgain()
	{
		p1Score = 0;
		p2Score = 0;
		roundOverUI.SetActive(false);
		Respawn();
	}

	void GameOver()
	{
		Debug.Log("GameOver");
		roundOverUI.SetActive(true);
		Time.timeScale = 0f;
	}
}
