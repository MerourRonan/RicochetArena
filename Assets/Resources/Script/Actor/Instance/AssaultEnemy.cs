using UnityEngine;
using System.Collections;

public class AssaultEnemy : Enemy {

	protected override void Awake()
	{
		base.Awake ();
		init (3, 8, 15);
	}
}
