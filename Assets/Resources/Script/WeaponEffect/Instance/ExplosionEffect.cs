using UnityEngine;
using System.Collections;

public class ExplosionEffect : WeaponEffect {

	protected int m_ExplosionDamage;

	public ExplosionEffect(int value)
	{
		m_PassiveName = "ExplosionPassive";
		m_PassiveValue = "+1";
		m_ExplosionDamage = value;
	}

	public override void triggerEffect (ActionTrigger trigger,PlayerProjectile projectile)
	{
		Debug.Log ("ExplosionEffect");
		if (trigger.m_ActionType == "HitTrigger") {
			Debug.Log ("ExplosionEffect");
			//projectile.m_ProjectileFeatures.m_Damage += m_ExplosionDamage;
			//UiManager.Instance.spawnFloatingText (projectile.transform.position, "+", m_ExplosionDamage);
		}
	}
}
