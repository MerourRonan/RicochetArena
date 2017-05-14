using UnityEngine;
using System.Collections;

public class DevTools : MonoBehaviour {

	public static DevTools Instance;

	//player
	public bool m_NoLimitShot;
	public bool m_NoLimitMove;

	void Awake()
	{
		Instance = this;
	}
}
