﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cannon0Features : WeaponFeatures {

	public Cannon0Features()
	{
		m_WeaponName = "Cannon0";
		m_ProjectileName = "Bullet";
		m_EnergyCost = 2;
		m_Damage = 1;
		m_BounceNumber = 1;
		m_CreditMultiplicator = 1.5f;
		m_IsPiercing = true;
		m_ShotNumber = 1;
		m_WeaponEffects = new List<WeaponEffect> ();

		m_WeaponEffects.Add (new AdditiveDamageEffect (1));
	}
}
