using UnityEngine;
using System.Collections;

public class ScoutEnemy :  Enemy {

	protected override void Awake()
	{
		base.Awake ();
		init (2, 10, 10);
	}
}
