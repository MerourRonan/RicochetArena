using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour,IPointerClickHandler {

	public int m_WeaponNumber;
	protected Button m_Button;

	void Awake()
	{
		m_Button = this.transform.GetComponent<Button> ();
	}

	public void init(int number)
	{
		m_WeaponNumber = number;
	}

	public void OnPointerClick(PointerEventData data)
	{
		PlayerController.Instance.selectWeapon (m_WeaponNumber);
	}

	public void activeButton(bool active)
	{
		m_Button.interactable = active;
	}

}
