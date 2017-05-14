using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour {

	protected Transform m_BarPointParent;
	protected List<Image> m_BarPoints;
	protected string m_PointName;
	public int m_MaxPoints;

	protected Color m_ActiveColor;
	protected Color m_DisableColor;

	public void initBar(int maxPoint)
	{
		GameObject prefab = Resources.Load ("Prefab/Ui/"+m_PointName) as GameObject;
		m_MaxPoints = maxPoint;
		for (int iter = 0; iter < maxPoint; iter++) {
			GameObject instance = Instantiate (prefab, Vector3.zero, Quaternion.identity) as GameObject;
			m_BarPoints.Add (instance.GetComponent<Image> ());
			instance.transform.SetParent (m_BarPointParent,false);
		}
	}

	public void updateBar(int currentPoint)
	{
		if (currentPoint >= m_MaxPoints) {
			foreach (Image image in m_BarPoints) {
				image.color = m_ActiveColor;
			}
		} else {
			for (int iter = m_MaxPoints - 1; iter >= currentPoint; iter--) {
				m_BarPoints [iter].color = m_DisableColor;
			}
		}

	}
}
