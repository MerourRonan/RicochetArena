using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour {

	protected Transform m_LifePointParent;
	protected List<Image> m_LifePointImages;
	public int m_MaxPoints;

	protected Color m_LifeColor;
	protected Color m_DamageColor;

	// Use this for initialization
	void Awake () {
		m_LifePointImages = new List<Image> ();
		m_LifePointParent = this.transform;
		m_DamageColor = new Color (219, 219, 219, 255) / 255;
		m_LifeColor = new Color (69, 212, 0, 255) / 255;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void initLifeBar(int lifePoints)
	{
		GameObject prefab = Resources.Load ("Prefab/Ui/LifePoint") as GameObject;
		m_MaxPoints = lifePoints;
		for (int iter = 0; iter < lifePoints; iter++) {
			GameObject instance = Instantiate (prefab, Vector3.zero, Quaternion.identity) as GameObject;
			m_LifePointImages.Add (instance.GetComponent<Image> ());
			instance.transform.SetParent (m_LifePointParent,false);
		}
	}

	public void updateLifeBar(int lifePoints)
	{
		if (lifePoints >= m_MaxPoints) {
			foreach (Image image in m_LifePointImages) {
				image.color = m_LifeColor;
			}
		} else {
			for (int iter = m_MaxPoints - 1; iter >= lifePoints; iter--) {
				m_LifePointImages [iter].color = m_DamageColor;
			}
		}

	}
}
