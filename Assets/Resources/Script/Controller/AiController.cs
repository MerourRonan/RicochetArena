using UnityEngine;
using System.Collections;

public class AiController : MonoBehaviour {

	public Enemy m_Actor;

	// Use this for initialization
	void Awake () {
		m_Actor = transform.GetComponent<Enemy> ();
	}

	void Start()
	{
	}

	public IEnumerator aiCoroutine()
	{
		//Debug.Log (transform.name + " playing");
		m_Actor.turnReset ();
		yield return StartCoroutine (aiMove ());
		yield return new WaitForSeconds (0.3f);
		yield return StartCoroutine (aiShoot ());
		yield return new WaitForSeconds (0.3f);
	}
	public IEnumerator aiMove()
	{
		m_Actor.m_UiBar.gameObject.SetActive (false);
		//Debug.Log (transform.name + " moving");
		Vector3 startPos = this.transform.position;
		Vector3 currentPos = this.transform.position;
		Vector3 destination = m_Actor.m_Weapon.getTarget().transform.position;
		m_Actor.getNavAgent ().enabled = true;
		m_Actor.move (destination);
		float distanceTraveled = 0;
		float distanceToTarget = Vector3.Distance (currentPos, destination);
		while (distanceTraveled < m_Actor.m_MoveRange && !(isTargetInRange() && isTargetInSight()) ) {
			currentPos = this.transform.position;
			distanceTraveled = Vector3.Distance (startPos, currentPos);
			distanceToTarget = Vector3.Distance (currentPos, destination);
			yield return new WaitForEndOfFrame ();
		}
		m_Actor.getNavAgent ().enabled = false;
		m_Actor.m_UiBar.gameObject.SetActive (true);
		m_Actor.updateUiBar ();

	}
	public IEnumerator aiShoot()
	{
		//Debug.Log (transform.name + " shooting");
		m_Actor.shoot ();
		yield return true;
	}

	public bool isTargetInSight()
	{
		LayerMask layerMask = 1<<LayerMask.NameToLayer ("Wall");
		RaycastHit hit;
		Vector3 targetPos = m_Actor.m_Weapon.getTarget().transform.position;
		float targetDistance = Vector3.Distance (targetPos, m_Actor.transform.position);
		Vector3 rayDir = (targetPos - m_Actor.transform.position).normalized;
		Vector3 rayStart = this.transform.position;
		if (!Physics.Raycast (rayStart, rayDir, out hit, targetDistance, layerMask)) {
			return true;
		} else {
			return false;
		}
	}
	public bool isTargetInRange()
	{
		Vector3 targetPos = m_Actor.m_Weapon.getTarget().transform.position;
		float targetDistance = Vector3.Distance (targetPos, m_Actor.transform.position);
		if (targetDistance <= m_Actor.m_Weapon.m_Range ) {
			return true;
		} else {
			return false;
		}
	}

	void OnDestroy()
	{
		GameManager.Instance.m_AiList.Remove (this);
	}
}
