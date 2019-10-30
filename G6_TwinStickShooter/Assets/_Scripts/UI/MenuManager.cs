using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If escape(on keyboard) or start(on controller) are pressed, make the game object active
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7))
        {
            pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
        }

    }
}
