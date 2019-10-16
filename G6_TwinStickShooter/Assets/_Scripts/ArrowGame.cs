using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArrowGame : MonoBehaviour
{
	//private GameObject[] players;

	private GameObject winUI;
	private Text winText;

	//private bool roundOver = false;

    // Start is called before the first frame update
    void Awake()
    {
		//players = GameObject.FindGameObjectsWithTag("Player");
		winUI = GameObject.Find("WinMessage");
		winText = winUI.GetComponent<Text>();

		winText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
  //      if (players.Length == 1)
		//{
		//	roundOver = true;
		//}

		//if (roundOver)
		//{
		//	SceneManager.LoadScene("Menus");
		//}
    }

	public void GameOver()
	{
		winText.enabled = true;
	}
}
