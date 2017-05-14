using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	public static PlayerController Instance;

	public Player m_PlayerActor;
	public PlayerWeapon m_WeaponSelected;
	public bool m_MoveMode;

	// Use this for initialization
	void Awake () {
		Instance = this;
		m_PlayerActor = transform.GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.m_PlayerPhase == true && !EventSystem.current.IsPointerOverGameObject()) {
			if (Input.GetMouseButton (1) && m_MoveMode) {
				playerMove ();
			} else if (Input.GetMouseButton (1) && m_WeaponSelected!=null) {
				if (m_PlayerActor.canShoot ()) {
					m_WeaponSelected.use ();
					resetWeapon ();
				}
			}
		}
	}

	protected void playerMove()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = Camera.main.transform.position.y;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		mousePos.y = 0;
		m_PlayerActor.move (mousePos);
	}

	public void selectMove()
	{
		resetWeapon ();
		if (m_MoveMode) {
			m_MoveMode = false;
		} else {
			m_MoveMode = true;
		}
	}

	public void selectWeapon(int number)
	{
		reset ();
		m_WeaponSelected = m_PlayerActor.m_PlayerWeapons [number];
		m_WeaponSelected.selectWeapon (true);
	}

	public void resetWeapon()
	{
		if (m_WeaponSelected != null) {
			m_WeaponSelected.stopRoutines ();
			m_WeaponSelected.selectWeapon (false);
			m_WeaponSelected = null;
		}
	}

	public void resetMove()
	{
		m_MoveMode = false;
	}

	public void reset()
	{
		resetWeapon ();
		resetMove ();
	}


}
