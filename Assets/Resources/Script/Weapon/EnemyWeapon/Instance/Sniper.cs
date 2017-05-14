using UnityEngine;
using System.Collections;

public class Sniper : EnemyWeapon {

	protected override void Awake () {
		initWeapon (5, 18, 1);
	}
}
