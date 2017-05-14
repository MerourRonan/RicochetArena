using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

	protected NavMeshAgent m_NavAgent;

	public bool m_IsMoved;
	public bool m_IsShooted;



	// Use this for initialization
	protected virtual void Awake () {
		m_NavAgent = transform.GetComponent<NavMeshAgent> ();

	}

	public virtual void move(Vector3 destination)
	{
		if(!m_IsMoved)
		{
			m_NavAgent.SetDestination (destination);
			m_IsMoved = true;
		}
	}

	public virtual void turnReset()
	{
		m_IsMoved = false;
		m_IsShooted = false;
	}

	public virtual bool canShoot()
	{
		if (m_NavAgent.velocity == Vector3.zero && !m_IsShooted) {
			return true;
		} else {
			return false;
		}
	}

	public NavMeshAgent getNavAgent()
	{
		return m_NavAgent;
	}
}
