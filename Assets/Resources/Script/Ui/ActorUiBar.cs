using UnityEngine;
using System.Collections;

public class ActorUiBar : MonoBehaviour {

	public LifeBar m_LifeBar;

	// Use this for initialization
	void Awake () {
		
	}

	public void initUiBar(Vector3 pos,int lifePoints)
	{
		m_LifeBar = transform.Find ("Life").GetComponent<LifeBar> ();
		m_LifeBar.initLifeBar (lifePoints);
		updateUiBar (pos, lifePoints);
	}

	public void updateUiBar(Vector3 pos,int lifePoints)
	{
		transform.position =  Camera.main.WorldToScreenPoint (pos);
		m_LifeBar.updateLifeBar (lifePoints);
	}
}
