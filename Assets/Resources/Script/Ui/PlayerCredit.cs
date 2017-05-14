using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCredit : MonoBehaviour {

	public static PlayerCredit Instance;

	protected Text m_CreditValue;

	// Use this for initialization
	void Awake () {
		Instance = this;
		m_CreditValue = transform.Find ("Value").GetComponent<Text> ();
		m_CreditValue.text = "0";
	}
	
	public void updateCreditValue(int value)
	{
		m_CreditValue.text = value.ToString();
	}
}
