using UnityEngine;
using System.Collections;

public class Enemy : Actor, IDamageable {

	public int m_LifePoints;
	public float m_MoveRange;
	public EnemyWeapon m_Weapon;
	public ActorUiBar m_UiBar;
	public int m_Credit;

	// Use this for initialization
	protected override void  Awake () {
		base.Awake ();
		m_Weapon = transform.GetComponent<EnemyWeapon> ();
	}

	protected void init (int lifePoints, int moverange, int credit)
	{
		m_LifePoints = lifePoints;
		m_MoveRange = moverange;
		m_Credit = credit;
		m_UiBar = UiManager.Instance.spawnActorUiBar (this.transform.position, m_LifePoints);
	}

	public void shoot()
	{

		if (canShoot()) {
			m_Weapon.use ();
			m_IsShooted = true;
		}
	}

	public void takeDamage(int damages,float creditMultiplicator)
	{
		UiManager.Instance.spawnFloatingText (this.transform.position, "-", damages);
		m_LifePoints -= damages;
		if (m_LifePoints <= 0) {
			PlayerCredit.Instance.updateCreditValue (Mathf.RoundToInt(m_Credit * creditMultiplicator));
			Destroy (m_UiBar.gameObject);
			Destroy (this.gameObject);

		} else {
			m_UiBar.updateUiBar (this.transform.position, m_LifePoints);
		}
	}

	public void updateUiBar()
	{
		m_UiBar.updateUiBar (this.transform.position, m_LifePoints);
	}
}
