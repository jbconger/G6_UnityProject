using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Replay()
	{
		SceneManager.LoadScene("LvL_v1");
	}

	public void StartGame()
	{
		SceneManager.LoadScene("LvL_v1");
		//SceneManager.SetActiveScene(SceneManager.GetSceneByName("LvL_v1"));
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
