using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    Transform UIPanel;

    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        UIPanel.gameObject.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If escape(on keyboard) or start(on controller) are pressed, make the game object active
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused || Input.GetKeyDown(KeyCode.Joystick1Button7) && !isPaused || Input.GetKeyDown(KeyCode.Joystick2Button7) && !isPaused)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused || Input.GetKeyDown(KeyCode.Joystick1Button7) && isPaused || Input.GetKeyDown(KeyCode.Joystick2Button7) && isPaused)
        {
            UnPause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        UIPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        isPaused = false;
        UIPanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        // TODO: Will need to find the logic to restart a match rather than restart the entire application.
        // Application.LoadLevel(0); <--This looks correct, but just needs the right scene number, however will it still have the players loaded in?
    }
}
