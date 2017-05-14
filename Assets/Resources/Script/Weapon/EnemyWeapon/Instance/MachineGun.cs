using UnityEngine;
using System.Collections;

public class MachineGun : EnemyWeapon {

	protected override void Awake () {
		initWeapon (4, 6, 1);
	}
}
