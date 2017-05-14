using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

	public static SpawnManager Instance;

	protected string[] m_EnemyKeys;
	protected GameObject m_PlayerPrefab;

	protected List<Transform> m_SpawnPointList;
	protected Transform m_PlayerSpawn;

	protected Transform m_EnemyParent;
	protected Transform m_PlayerParent;

	int m_EnemyID;

	void Awake () {
		Instance = this;
		m_EnemyKeys = new string[4]{"HeavyEnemy","ScoutEnemy","AssaultEnemy","SniperEnemy" };
		m_PlayerPrefab = Resources.Load ("Prefab/Actor/Player") as GameObject;
		m_EnemyParent = GameObject.Find ("Actors/Enemies").transform;
		m_PlayerParent = GameObject.Find ("Actors").transform;
		m_EnemyID = 0;
		initSpawnPoints ();
	}
	
	public void spawnEnemies(){
		int enemyCount = GameManager.Instance.m_AiList.Count;
		int enemyCountMax = 9;
		if (enemyCount < enemyCountMax) {

			int nbEnemies = Random.Range (3, Mathf.Min(4,enemyCountMax-enemyCount));
			for (int iter = 0; iter < nbEnemies; iter++) {
				int rand = Random.Range (0, m_SpawnPointList.Count);
				Vector3 randomPos = m_SpawnPointList [rand].position + Random.insideUnitSphere * 3;
				NavMeshHit hit;
				NavMesh.SamplePosition (randomPos, out hit, 4, NavMesh.AllAreas);
				string key = m_EnemyKeys [Random.Range (0, 4)];
				GameObject prefab = ResourceLoader.Instance.getPrefab (key);
				GameObject enemyInstance = Instantiate (prefab, hit.position, Quaternion.identity) as GameObject;
				AiController controller = enemyInstance.GetComponent<AiController> ();
				GameManager.Instance.m_AiList.Add (controller);
				enemyInstance.transform.SetParent (m_EnemyParent);
				enemyInstance.name = "Enemy" + m_EnemyID.ToString ();
				m_EnemyID++;
			}
		}
	}

	public void spawnPlayer(){

		Vector3 randomPos = m_PlayerSpawn.position+Random.insideUnitSphere*3;
		NavMeshHit hit;
		NavMesh.SamplePosition (randomPos, out hit, 4, NavMesh.AllAreas);
		GameObject instance = Instantiate (m_PlayerPrefab, hit.position, Quaternion.identity) as GameObject;
		instance.transform.SetParent (m_PlayerParent);
	}

	protected void initSpawnPoints()
	{
		m_SpawnPointList = new List<Transform> ();
		m_PlayerSpawn = GameObject.Find ("Spawners/PlayerSpawn").transform;
		foreach (Transform spawnPoint in GameObject.Find("Spawners/EnemySpawn").transform) {
			m_SpawnPointList.Add (spawnPoint);
		}
	}
		
}
