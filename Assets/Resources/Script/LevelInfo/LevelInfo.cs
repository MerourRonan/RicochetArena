using UnityEngine;
using System.Collections;

public class LevelInfo : MonoBehaviour {

	public static LevelInfo Instance;

	public int m_TurnNumber;
	public int m_Credit;

	// Use this for initialization
	void Awake () {
		Instance = this;
		m_TurnNumber = 1;
		m_Credit = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void reset()
	{
		m_TurnNumber = 1;
		m_Credit = 0;
	}

	public void gainCredit(int value)
	{
		m_Credit += value;
		PlayerCredit.Instance.updateCreditValue (m_Credit);
	}
}
