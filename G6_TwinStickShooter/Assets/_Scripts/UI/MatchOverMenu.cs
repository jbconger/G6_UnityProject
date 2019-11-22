using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MatchOverMenu : MonoBehaviour
{
	GameControls controls;

	public GameObject matchOverUI;
	public Button playAgain;
	public Button levelSelect;
	public Button quitToTitle;

	private void Awake()
	{
		controls = new GameControls();
		controls.UI.Navigate.started += OnNavigate;
	}

	public void MatchOver()
	{
		matchOverUI.SetActive(true);
		Time.timeScale = 0f;
	}

	public void OnNavigate(InputAction.CallbackContext ctx)
	{
		Vector2 direction = ctx.ReadValue<Vector2>();

		if (direction == Vector2.up) { playAgain.Select(); }
		else if (direction == Vector2.right) { quitToTitle.Select(); }
		else if (direction == -Vector2.right) { levelSelect.Select(); }
		else { return; }
	}
}
