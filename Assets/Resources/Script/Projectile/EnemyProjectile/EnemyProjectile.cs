using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

	protected Rigidbody m_RigidBody;
	public float m_Speed;
	public int m_Damages;

	// Use this for initialization
	protected virtual void Awake () {
		m_RigidBody = transform.GetComponent<Rigidbody> ();
		m_Speed = 50;
	}

	void Start()
	{
		m_RigidBody.velocity = this.transform.forward * m_Speed;
	}

	void OnTriggerEnter(Collider collider)
	{
		IDamageable target = collider.GetComponent<IDamageable> ();
		if (target != null && collider.transform.tag=="Player") {
			target.takeDamage (m_Damages,0);
			Destroy (this.gameObject);
		}
		if (collider.transform.tag == "Wall") {
			Destroy (this.gameObject);
		}
	}
}
