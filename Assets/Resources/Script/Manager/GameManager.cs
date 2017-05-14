using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public bool m_PlayerPhase;
	public List<AiController> m_AiList;

	// Use this for initialization
	void Awake () {
		Screen.orientation = ScreenOrientation.Landscape;
		Instance = this;
		m_PlayerPhase = true;
		m_AiList = new List<AiController> ();
	}

	void Start()
	{
		SpawnManager.Instance.spawnEnemies ();
		SpawnManager.Instance.spawnPlayer ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void nextTurn()
	{
		if (m_PlayerPhase) {
			m_PlayerPhase = false;
			UiManager.Instance.m_EndTurn.interactable = false;
			StartCoroutine (aiTurn ());
		} else {
			m_PlayerPhase = true;
			UiManager.Instance.m_EndTurn.interactable = true;
			Player.Instance.turnReset ();
		}
	}

	protected IEnumerator aiTurn()
	{
		foreach (AiController ai in m_AiList) {
			yield return StartCoroutine (ai.aiCoroutine ());
		}
		SpawnManager.Instance.spawnEnemies ();
		nextTurn ();
	}
}
