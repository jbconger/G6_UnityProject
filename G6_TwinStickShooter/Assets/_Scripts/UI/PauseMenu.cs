using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	GameControls controls;

	public GameObject pauseMenuUI;
    public static bool isPaused;

	private void Awake()
	{
		controls = new GameControls();
		controls.UI.Pause.started += OnPause;
	}

	void Start()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

	// pause functions
	public void OnPause(InputAction.CallbackContext ctx)
	{
		if (isPaused)
			UnPause();
		else
			Pause();
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

	// other items
	private void OnEnable() { controls.Enable(); }
	private void OnDisable() { controls.Disable(); }
}
