using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerWeapon : MonoBehaviour {

	private float m_RoF=0.3f;

	public Player m_Player;
	Transform m_SpawnPoint;
	GameObject m_Projectile;
	List<Vector3> m_BouncePoints;
	List<Vector3> m_BounceDirections;
	WeaponFeatures m_WeaponFeatures;

	bool m_IsActive;
	bool m_IsUseable;

	public WeaponButton m_Button;
	public WeaponDescription m_Description;

	public void init(WeaponFeatures weaponFeatures)
	{
		m_Player = this.transform.GetComponent<Player> ();
		m_BouncePoints = new List<Vector3> ();
		m_BounceDirections = new List<Vector3> ();
		m_SpawnPoint = transform.Find ("SpawnPoint");
		m_Projectile = Resources.Load ("Prefab/Projectile/"+weaponFeatures.m_ProjectileName) as GameObject;
		m_WeaponFeatures = weaponFeatures;
		m_IsActive = true;

	}

	void Start()
	{
		initDescription ();
	}

	public void selectWeapon(bool active)
	{
		m_Description.gameObject.SetActive (active);
		if (active) {
			if (m_Player.m_EnergyCurrent >= m_WeaponFeatures.m_EnergyCost && m_IsActive) {
				StartCoroutine (aimRoutine ());
				m_IsUseable = true;
			} else {
				m_IsUseable = false;
			}
		}
	}

	public IEnumerator aimRoutine()
	{
		while (true) {
			m_Player.m_AimRay.SetVertexCount (0);
			m_BouncePoints.Clear ();
			m_BounceDirections.Clear ();
			if (GameManager.Instance.m_PlayerPhase) {
				LayerMask layerMask = 1 << LayerMask.NameToLayer ("Wall");
				RaycastHit hit;
				Vector3 mousePos = Input.mousePosition;
				mousePos.z = Camera.main.transform.position.y;
				mousePos = Camera.main.ScreenToWorldPoint (mousePos);
				mousePos.y = transform.position.y;
				Vector3 rayDir = (mousePos - transform.position).normalized;
				Vector3 rayStart = this.transform.position;
				m_Player.m_AimRay.SetVertexCount (m_WeaponFeatures.m_BounceNumber + 2);
				m_Player.m_AimRay.SetPosition (0, this.transform.position);
				m_Player.transform.rotation = Quaternion.LookRotation (rayDir);
				for (int bounce = 1; bounce <= m_WeaponFeatures.m_BounceNumber + 1; bounce++) {
					if (Physics.Raycast (rayStart, rayDir, out hit, Mathf.Infinity, layerMask)) {
						//Debug.Log ("collider hit = " + hit.collider.transform.name);
						m_Player.m_AimRay.SetPosition (bounce, hit.point);
						rayStart = hit.point;
						rayDir = Vector3.Reflect (rayDir, hit.normal);
						m_BouncePoints.Add (rayStart);
						m_BounceDirections.Add (rayDir);
					}
				}
			}
			yield return new WaitForEndOfFrame ();
		}

	}

	public void use()
	{
		if (m_IsUseable) {
			this.stopRoutines ();
			m_Player.updateEnergy (m_WeaponFeatures.m_EnergyCost);
			GameObject projInstance = Instantiate (m_Projectile, m_SpawnPoint.position, Quaternion.LookRotation (this.transform.forward)) as GameObject;
			projInstance.GetComponent<PlayerProjectile> ().init (m_WeaponFeatures, m_BouncePoints, m_BounceDirections);
			m_IsActive = false;
			m_IsUseable = false;
			m_Button.activeButton (false);
		}
	}

	public void turnReset()
	{
		m_IsActive = true;
		m_Button.activeButton (true);
	}

	public void stopRoutines()
	{
		this.StopAllCoroutines ();
		m_Player.m_AimRay.SetVertexCount (0);
	}

	public void initDescription()
	{
		m_Description = UiManager.Instance.spawnWeaponDescription ();
		m_Description.setDamage (m_WeaponFeatures.m_Damage,m_WeaponFeatures.m_ShotNumber);
		m_Description.setEnergy (m_WeaponFeatures.m_EnergyCost);
		if (m_WeaponFeatures.m_IsPiercing) {
			m_Description.addPassive ("PiercePassive");
		}
		foreach (WeaponEffect effect in m_WeaponFeatures.m_WeaponEffects) {
			m_Description.addPassive (effect.getPassiveName (), effect.getPassiveValue ());
		}
		m_Description.gameObject.SetActive (false);
	}

	public string getName()
	{
		return m_WeaponFeatures.m_WeaponName;
	}
}
