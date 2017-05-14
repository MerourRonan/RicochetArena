using UnityEngine;
using System.Collections;

public class WeaponEffect {

	protected string m_PassiveName;
	protected string m_PassiveValue;

	public virtual void triggerEffect(ActionTrigger trigger)
	{
	}
	public virtual void triggerEffect(ActionTrigger trigger, PlayerProjectile projectile)
	{
	}

	public string getPassiveName()
	{
		return m_PassiveName;
	}
	public string getPassiveValue()
	{
		return m_PassiveValue;
	}
}
