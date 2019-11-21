using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	// PLAYER INFORMATION
	public Color m_PlayerColor;
	public Transform m_SpawnPoint;

	[HideInInspector] public int m_PlayerNumber;
	[HideInInspector] public string m_ColoredPlayerText;
	[HideInInspector] public GameObject m_Instance;
	[HideInInspector] public int m_Wins;

	private ArcherMovement m_Movement;
	private ArcherShooting m_Shooting;
	private GameObject m_GameUI;

	public void Setup()
	{
		// establish component connections
		m_Movement = m_Instance.GetComponent<ArcherMovement>();
		m_Shooting = m_Instance.GetComponent<ArcherShooting>();
		m_GameUI = m_Instance.GetComponentInChildren<Canvas>().gameObject;

		// set player numbers
		m_Movement.playerNumber = m_PlayerNumber;
		m_Shooting.playerNumber = m_PlayerNumber;

		// setup player ui label
		m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";

		// change indicator color
		m_Instance.GetComponentInChildren<SpriteRenderer>().color = m_PlayerColor;
	}

	// Used during the phases of the game where the player shouldn't be able to control their tank.
	public void DisablePlayer()
	{
		m_Movement.enabled = false;
		m_Shooting.enabled = false;

		m_GameUI.SetActive(false);
	}

	// Used during the phases of the game where the player should be able to control their tank.
	public void EnablePlayer()
	{
		m_Movement.enabled = true;
		m_Shooting.enabled = true;

		m_GameUI.SetActive(true);
	}

	// Used at the start of each round to put the tank into it's default state.
	public void Reset()
	{
		m_Instance.transform.position = m_SpawnPoint.position;
		m_Instance.transform.rotation = m_SpawnPoint.rotation;

		m_Instance.SetActive(false);
		m_Instance.SetActive(true);
	}
}
