using UnityEngine;
using System.Collections;

public class Rifle : EnemyWeapon {

	protected override void Awake () {
		initWeapon (1, 12, 1);
	}
}
