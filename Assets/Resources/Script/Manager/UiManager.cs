using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

	public static UiManager Instance;

	public  Button m_EndTurn;

	protected Transform m_CanvasParent;
	protected Transform m_WeaponButtonParent;
	protected Transform m_WeaponDescriptionParent;
	protected Transform m_EnemyLifeBarParent;


	// Prefab
	private GameObject m_ActorUiBarPrefab;
	private GameObject m_FloatingDisplayPrefab;
	private GameObject m_WeaponButtonPrefab;
	private GameObject m_WeaponDescriptionPrefab;

	void Awake () {
		InitManager ();
	}
	


	protected void InitManager()
	{
		Instance = this;
		m_EndTurn = GameObject.Find ("Canvas/PlayerUi/EndTurnButton").GetComponent<Button> ();
		m_EnemyLifeBarParent = GameObject.Find ("Canvas/EnemyLifeBar").transform;
		m_CanvasParent = GameObject.Find ("Canvas").transform;
		m_WeaponButtonParent = GameObject.Find ("Canvas/PlayerUi/WeaponButtons").transform;
		m_WeaponDescriptionParent = GameObject.Find ("Canvas/PlayerUi").transform;

		m_ActorUiBarPrefab = Resources.Load ("Prefab/Ui/ActorUiBar") as GameObject;
		m_FloatingDisplayPrefab = Resources.Load ("Prefab/Ui/FloatingDisplay") as GameObject;
		m_WeaponButtonPrefab = Resources.Load ("Prefab/Ui/WeaponButton") as GameObject;
		m_WeaponDescriptionPrefab = Resources.Load ("Prefab/Ui/WeaponDescription") as GameObject;
	}

	public ActorUiBar spawnActorUiBar(Vector3 pos,int lifePoint)
	{
		GameObject instance = Instantiate (m_ActorUiBarPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		instance.transform.SetParent (m_EnemyLifeBarParent,false);
		ActorUiBar uiBar = instance.GetComponent<ActorUiBar> ();
		uiBar.initUiBar (pos, lifePoint);
		return uiBar;
	}

	public void spawnFloatingText(Vector3 pos,string symbol, int value)
	{
		GameObject instance = Instantiate (m_FloatingDisplayPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		instance.transform.SetParent (m_CanvasParent,false);
		instance.GetComponent<FloatingDisplay> ().init (pos, symbol, value);
	}

	public WeaponButton spawnWeaponButton(int weaponNumber, string buttonName)
	{
		GameObject instance = Instantiate (m_WeaponButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		instance.transform.SetParent (m_WeaponButtonParent,false);
		instance.GetComponentInChildren<Text> ().text = buttonName;
		WeaponButton button = instance.GetComponent<WeaponButton> ();
		button.init (weaponNumber);
		return button;
	}

	public WeaponDescription spawnWeaponDescription()
	{
		GameObject instance = Instantiate (m_WeaponDescriptionPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		instance.transform.SetParent (m_WeaponDescriptionParent,false);
		WeaponDescription script = instance.GetComponent<WeaponDescription> ();
		script.init ();
		return script;
	}
}
