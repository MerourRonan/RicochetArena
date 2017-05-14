using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerEnergyBar : PlayerBar {

	public static PlayerEnergyBar Instance;

	void Awake () {
		Instance = this;
		m_BarPoints = new List<Image> ();
		m_BarPointParent = this.transform;
		m_DisableColor = new Color (219, 219, 219, 255) / 255;
		m_ActiveColor = new Color (250, 234, 0, 255) / 255;
		m_PointName = "EnergyPoint";
	}

}
