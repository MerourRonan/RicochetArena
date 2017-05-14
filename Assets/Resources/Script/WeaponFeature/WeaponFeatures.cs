using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponFeatures {

	public string m_WeaponName;
	public string m_ProjectileName;
	public int m_EnergyCost;
	public int m_Damage;
	public int m_ShotNumber;
	public int m_BounceNumber;
	public float m_CreditMultiplicator;
	public bool m_IsPiercing;
	public List<WeaponEffect> m_WeaponEffects;

	public WeaponFeatures()
	{

	}

	public WeaponFeatures(WeaponFeatures weaponFeatures)
	{
		m_WeaponName = weaponFeatures.m_WeaponName;
		m_ProjectileName = weaponFeatures.m_ProjectileName;
		m_EnergyCost = weaponFeatures.m_EnergyCost;
		m_Damage = weaponFeatures.m_Damage;
		m_ShotNumber = weaponFeatures.m_ShotNumber;
		m_BounceNumber = weaponFeatures.m_BounceNumber;
		m_CreditMultiplicator = weaponFeatures.m_CreditMultiplicator;
		m_IsPiercing = weaponFeatures.m_IsPiercing;
		m_WeaponEffects = new List<WeaponEffect>(weaponFeatures.m_WeaponEffects);

	}

}
