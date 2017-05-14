using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerProjectile : MonoBehaviour {

	protected Rigidbody m_RigidBody;
	public float m_Speed = 75;
	public List<Vector3> m_BouncePoints;
	public List<Vector3> m_BounceDirections;
	protected int m_PointIndex;
	protected int m_DirectionIndex;
	protected float m_LastDistanceBeforeDeflect;
	protected Vector3 nextBouncePoint ;
	protected Vector3 nextBounceDirection;

	public WeaponFeatures m_ProjectileFeatures;
	public float m_CreditMultiplicator;

	void Update()
	{
		CheckBounce ();
	}

	public void init(WeaponFeatures projectileFeatures,List<Vector3> bouncePoints,List<Vector3> bounceDirections)
	{
		m_RigidBody = transform.GetComponent<Rigidbody> ();
		m_RigidBody.velocity = this.transform.forward * m_Speed;
		m_BouncePoints = bouncePoints;
		m_BounceDirections = bounceDirections;
		m_ProjectileFeatures = new WeaponFeatures(projectileFeatures);
		m_PointIndex = 0;
		m_DirectionIndex = 0;
		nextBouncePoint = m_BouncePoints [m_PointIndex];
		nextBounceDirection = m_BounceDirections [m_DirectionIndex];
		m_LastDistanceBeforeDeflect = Mathf.Infinity;
		m_CreditMultiplicator = 1;
	}

	public void CheckBounce()
	{
		
		float currentDistance = Vector3.Distance (this.transform.position, nextBouncePoint);
		if (currentDistance > m_LastDistanceBeforeDeflect) {
			if (m_PointIndex < m_BouncePoints.Count) {
				this.transform.position= nextBouncePoint;
				this.transform.rotation = Quaternion.LookRotation (nextBounceDirection);
				Debug.DrawRay (nextBouncePoint, nextBounceDirection, Color.red);
				m_RigidBody.velocity = this.transform.forward * m_Speed;
				ComputeNextBounce ();
				bouncing ();
			} else {
				Destroy (this.gameObject);

			}
		} else {
			m_LastDistanceBeforeDeflect = currentDistance;
		}
	}

	protected void ComputeNextBounce()
	{
		m_PointIndex++;
		m_DirectionIndex++;
		if (m_PointIndex < m_BouncePoints.Count) {
			Debug.Log ("new bounce point");
			nextBouncePoint = m_BouncePoints [m_PointIndex];
			nextBounceDirection = m_BounceDirections [m_DirectionIndex];
			m_LastDistanceBeforeDeflect = Mathf.Infinity;
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		IDamageable target = collider.GetComponent<IDamageable> ();
		if (target != null) {
			hitDamageable ();
			target.takeDamage (m_ProjectileFeatures.m_Damage,m_CreditMultiplicator);
			if (!m_ProjectileFeatures.m_IsPiercing) {
				Destroy (this.gameObject);
			}
		}
	}

	protected void bouncing()
	{
		m_CreditMultiplicator *= m_ProjectileFeatures.m_CreditMultiplicator;
		foreach (WeaponEffect effect in m_ProjectileFeatures.m_WeaponEffects) {
			Debug.Log ("trigger");
			effect.triggerEffect (new BounceTrigger (),this);
		}
	}

	protected void hitDamageable()
	{
		m_CreditMultiplicator *= m_ProjectileFeatures.m_CreditMultiplicator;
		foreach (WeaponEffect effect in m_ProjectileFeatures.m_WeaponEffects) {
			effect.triggerEffect (new HitTrigger ());
		}
	}
}
