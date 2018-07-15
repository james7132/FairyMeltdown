using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

  public GameObject ProjectilePrefab;
  public float MinDelayProjectile;
  public float ShotSpeed = 5;
  public float BlastBulletCount = 8;

  bool firedSinceLastTimer;
  float timer;
  bool fireBlast;

	// Update is called once per frame
	void Update () {
    FireCheck("Fire1", false);
    FireCheck("Fire2", true);
    timer -= Time.deltaTime;
    if (timer > 0f || !firedSinceLastTimer) return;
    Debug.Log(fireBlast);
    if (fireBlast) {
      FireBlast();
    } else {
      FireSingle();
    }
	}

  void FireCheck(string input, bool blast) {
    var check = Input.GetButtonDown(input);
    firedSinceLastTimer |= check;
    if (check) {
      fireBlast = blast;
    }
  }

  void FireBlast() {
    for (var i = 0; i < BlastBulletCount; i++) {
      var angle = i * Mathf.PI * 2 / BlastBulletCount;
      var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
      Fire(ProjectilePrefab, direction);
    }
  }

  void FireSingle() {
    var camera = Camera.main;
    var mousePosition = (Vector2)camera.ScreenToWorldPoint(Input.mousePosition);
    var direction = (mousePosition - (Vector2)transform.position).normalized;
    Fire(ProjectilePrefab, direction);
  }

  void Fire(GameObject prefab, Vector2 direction) {
    var projectile = Instantiate(prefab, transform.position, Quaternion.identity);
    projectile.GetComponent<Projectile>().Movement = ShotSpeed * direction;
    firedSinceLastTimer = false;
    timer = MinDelayProjectile;
  }

}
