using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour,IPointerClickHandler {

	public static MoveButton Instance;

	protected Button m_Button;

	void Awake()
	{
		Instance = this;
		m_Button = this.transform.GetComponent<Button> ();
	}

	public void OnPointerClick(PointerEventData data)
	{
		PlayerController.Instance.selectMove ();
	}

	public void activeButton(bool active)
	{
		m_Button.interactable = active;
	}
}
