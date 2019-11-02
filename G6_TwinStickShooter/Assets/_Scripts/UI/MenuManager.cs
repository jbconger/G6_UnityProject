using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	//[SerializeField]
	//Transform UIPanel;

	public GameObject pauseMenuUI;

    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

	// input handler for pausing the game
	public void OnPause(InputAction.CallbackContext ctx)
	{
		if (ctx.phase is InputActionPhase.Started)
		{
			if (isPaused)
				UnPause();
			else
				Pause();
		}
	}

	public void Pause()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
		Debug.Log("Quit");
        Application.Quit();
    }

    public void Restart()
    {
		SceneManager.LoadScene("LvL_v1");
        // TODO: Will need to find the logic to restart a match rather than restart the entire application.
        // Application.LoadLevel(0); <--This looks correct, but just needs the right scene number, however will it still have the players loaded in?
    }
}
