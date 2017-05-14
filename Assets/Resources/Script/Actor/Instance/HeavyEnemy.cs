using UnityEngine;
using System.Collections;

public class HeavyEnemy :  Enemy {

	protected override void Awake()
	{
		base.Awake ();
		init (4, 6, 30);
	}
}
