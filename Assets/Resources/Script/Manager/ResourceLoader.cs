using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceLoader : MonoBehaviour {

	public static ResourceLoader Instance;

	Dictionary<string,GameObject> m_ResourceLoaded;

	private string HEAVY_ENEMY_KEY = "HeavyEnemy";
	private string SCOUT_ENEMY_KEY = "ScoutEnemy";
	private string ASSAULT_ENEMY_KEY = "AssaultEnemy";
	private string SNIPER_ENEMY_KEY = "SniperEnemy";


	void Awake () {
		Instance = this;
	}

	protected void loadAllPrefab()
	{
		m_ResourceLoaded = new Dictionary<string, GameObject> ();
		m_ResourceLoaded [HEAVY_ENEMY_KEY] = Resources.Load ("Prefab/Actor/Enemy/" + HEAVY_ENEMY_KEY) as GameObject;
		m_ResourceLoaded [SCOUT_ENEMY_KEY] = Resources.Load ("Prefab/Actor/Enemy/" + SCOUT_ENEMY_KEY) as GameObject;
		m_ResourceLoaded [ASSAULT_ENEMY_KEY] = Resources.Load ("Prefab/Actor/Enemy/" + ASSAULT_ENEMY_KEY) as GameObject;
		m_ResourceLoaded [SNIPER_ENEMY_KEY] = Resources.Load ("Prefab/Actor/Enemy/" + SNIPER_ENEMY_KEY) as GameObject;

	}

	public GameObject getPrefab(string key)
	{
		if (m_ResourceLoaded == null) {
			loadAllPrefab ();
		}
		return m_ResourceLoaded [key];
	}
	

}
