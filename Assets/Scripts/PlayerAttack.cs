using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

  public GameObject ProjectilePrefab;
  public float MinDelayProjectile;
  public float ShotSpeed = 5;
  public float BlastBulletCount = 8;
  public float PanicDelay = 15f;
  [System.NonSerialized] public float PanicTimer;

  bool firedSinceLastTimer;
  float timer;
  float panicTimer;
  bool fireBlast;

	// Update is called once per frame
	void Update () {
    timer -= Time.deltaTime;
    PanicTimer -= Time.deltaTime;
    FireCheck("Fire1", false);
    FireCheck("Fire2", true, PanicTimer < 0);
    if (timer > 0f || !firedSinceLastTimer) return;
    if (fireBlast) {
      FireBlast();
    } else {
      FireSingle();
    }
	}

  void FireCheck(string input, bool blast, bool prereq = true) {
    if (!prereq) return;
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
    PanicTimer = PanicDelay;
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
