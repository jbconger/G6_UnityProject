using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
	public GameObject titleUI;

	PlayerControls controls;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void PlayGame()
	{
		SceneManager.LoadScene("Wind1");
	}

	public void QuitGame()
	{
		Debug.Log("Quit");
		Application.Quit();
	}

	// other items
	private void OnEnable() { controls.Enable(); }
	private void OnDisable() { controls.Disable(); }
}
