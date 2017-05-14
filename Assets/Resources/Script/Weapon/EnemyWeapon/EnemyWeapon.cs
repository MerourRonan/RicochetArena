using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour {

	public Actor m_Actor;
	Transform m_SpawnPoint;
	GameObject m_Projectile;

	public float m_Range;
	public int m_Damages;
	public int m_NbShots;

	public Actor m_Target;

	protected virtual void Awake () {
		initWeapon (0,0,0);
	}

	void Start()
	{
		findTarget ();
	}

	protected void initWeapon(int damage, int range, int nbShots)
	{
		m_Actor = this.transform.GetComponent<Actor> ();
		m_SpawnPoint = transform.Find ("SpawnPoint");
		m_Projectile = Resources.Load ("Prefab/Projectile/EnemyBullet") as GameObject;

		m_Range = range;
		m_Damages = damage;
		m_NbShots = nbShots;
	}

	protected void findTarget()
	{
		m_Target = Player.Instance;
	}

	public void use()
	{
		LayerMask layerMask = 1<<LayerMask.NameToLayer ("Wall");
		RaycastHit hit;
		float targetDistance = Vector3.Distance (m_Target.transform.position, m_Actor.transform.position);
		Vector3 rayDir = (m_Target.transform.position - m_Actor.transform.position).normalized;
		Vector3 rayStart = this.transform.position;
		if (targetDistance <= m_Range && !Physics.Raycast (rayStart, rayDir, out hit, m_Range, layerMask)) {
			m_Actor.transform.rotation = Quaternion.LookRotation (rayDir);
			GameObject instance = Instantiate (m_Projectile, m_SpawnPoint.position, Quaternion.LookRotation (rayDir)) as GameObject;
			instance.GetComponent<EnemyProjectile> ().m_Damages = m_Damages;
		}
	}

	public Actor getTarget()
	{
		if (m_Target == null) {
			findTarget ();
		}
		return m_Target;
	}
}
