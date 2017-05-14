using UnityEngine;
using System.Collections;

public class AdditiveDamageEffect : WeaponEffect {

	protected int m_BonusDamage;

	public AdditiveDamageEffect(int value)
	{
		m_PassiveName = "AdditiveDamagePassive";
		m_PassiveValue = "+"+value.ToString();
		m_BonusDamage = value;
	}

	public override void triggerEffect (ActionTrigger trigger,PlayerProjectile projectile)
	{
		Debug.Log ("AdditiveDamageEffect");
		if (trigger.m_ActionType == "Bounce") {
			Debug.Log ("AdditiveDamageEffect");
			projectile.m_ProjectileFeatures.m_Damage += m_BonusDamage;
			UiManager.Instance.spawnFloatingText (projectile.transform.position, "+", m_BonusDamage);
		}
	}
}
