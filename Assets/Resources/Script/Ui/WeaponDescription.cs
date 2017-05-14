using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponDescription : MonoBehaviour {

	protected Text m_Damage;
	protected Text m_Energy;
	protected Transform m_PassiveParent;


	// Use this for initialization
	void Awake () {
	
	}
	
	public void init()
	{
		m_Damage = transform.Find ("Damage/Text").GetComponent<Text> ();
		m_Energy = transform.Find ("Energy/Text").GetComponent<Text> ();
		m_PassiveParent = transform.Find ("Passives");
	}
	public void setDamage(int damage,int nbProj)
	{
		m_Damage.text = nbProj.ToString ()+"x"+damage.ToString ();
	}
	public void setEnergy(int value)
	{
		m_Energy.text = value.ToString ();
	}
	public void addPassive(string passiveName, string passiveValue="")
	{
		GameObject passivePrefab = Resources.Load ("Prefab/Ui/Passives/" + passiveName) as GameObject;
		GameObject instance = Instantiate (passivePrefab, Vector3.zero, Quaternion.identity) as GameObject;
		instance.transform.SetParent (m_PassiveParent, false);
		instance.transform.Find ("Value").GetComponent<Text> ().text = passiveValue;
	}
}
