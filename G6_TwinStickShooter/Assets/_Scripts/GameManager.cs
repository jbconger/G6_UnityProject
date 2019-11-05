using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;

	public GameObject p1;
	private Transform p1Spawn;
	
	public GameObject p2;
	private Transform p2Spawn;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}

	void NewRound()
	{

	}
}
