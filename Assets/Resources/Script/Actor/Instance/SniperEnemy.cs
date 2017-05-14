using UnityEngine;
using System.Collections;

public class SniperEnemy :  Enemy {

	protected override void Awake()
	{
		base.Awake ();
		init (1, 6, 20);
	}
}
