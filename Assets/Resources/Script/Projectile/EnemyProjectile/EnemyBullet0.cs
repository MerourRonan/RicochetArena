using UnityEngine;
using System.Collections;

public class EnemyBullet0 : EnemyProjectile {

	protected override void Awake () {
		base.Awake ();
		m_Speed = 25;
		m_Damages = 1;
	}
}
