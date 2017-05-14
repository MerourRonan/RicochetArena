using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Actor, IDamageable {

	public static Player Instance;
	public LineRenderer m_AimRay;

	public List<PlayerWeapon> m_PlayerWeapons;

	public int m_LifeMax;
	public int m_LifeCurrent;
	public int m_EnergyMax;
	public int m_EnergyCurrent;

	// Use this for initialization
	protected override void  Awake () {
		base.Awake ();
		Instance = this;
		m_PlayerWeapons = new List<PlayerWeapon> ();
		m_AimRay = transform.GetComponent<LineRenderer> ();

		m_LifeMax = 10;
		m_LifeCurrent = m_LifeMax;
		m_EnergyMax = 5;
		m_EnergyCurrent = m_EnergyMax;

	}

	protected void Start()
	{
		PlayerLifeBar.Instance.initBar(m_LifeMax);
		PlayerEnergyBar.Instance.initBar (m_EnergyMax);
		initWeapons ();
		m_AimRay.SetVertexCount (0);
	}

	public void initWeapons()
	{
		int weaponIndex = 0;
		foreach (PlayerWeapon weapon in this.transform.GetComponents<PlayerWeapon>()) {
			m_PlayerWeapons.Add (weapon);
			weapon.m_Button = UiManager.Instance.spawnWeaponButton (weaponIndex,weapon.getName());
			weaponIndex++;
		}
	}

	public override void move(Vector3 destination)
	{
		if(!m_IsMoved || DevTools.Instance.m_NoLimitMove)
		{
			m_NavAgent.SetDestination (destination);
			m_IsMoved = true;
			MoveButton.Instance.activeButton (false);
		}
	}

	public override bool canShoot()
	{
		if (m_NavAgent.velocity == Vector3.zero && !m_IsShooted || DevTools.Instance.m_NoLimitShot) {
			return true;
		} else {
			return false;
		}
	}

	public void takeDamage(int damages, float creditMultiplicator)
	{
		m_LifeCurrent -= damages;
		PlayerLifeBar.Instance.updateBar (m_LifeCurrent);
		if (m_LifeCurrent <= 0) {
			Destroy (this.gameObject);
		}
	}

	public void updateEnergy(int value)
	{
		m_EnergyCurrent -= value;
		PlayerEnergyBar.Instance.updateBar (m_EnergyCurrent);
	}

	public override void turnReset()
	{
		base.turnReset ();
		m_EnergyCurrent = m_EnergyMax;
		PlayerEnergyBar.Instance.updateBar (m_EnergyCurrent);
		PlayerController.Instance.reset ();
		MoveButton.Instance.activeButton (true);
		foreach (PlayerWeapon weapon in m_PlayerWeapons) {
			weapon.turnReset ();
		}
	}
}
