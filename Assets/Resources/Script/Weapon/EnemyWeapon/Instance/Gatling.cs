using UnityEngine;
using System.Collections;

public class Gatling : EnemyWeapon {

	protected override void Awake () {
		initWeapon (2, 7, 3);
	}
}
