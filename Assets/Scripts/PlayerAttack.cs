using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

  public GameObject ProjectilePrefab;
  public GameObject SwingPrefab;
  public float MinDelayProjectile;
  public float ShotSpeed = 5;
  public float BlastBulletCount = 8;
  public float PanicDelay = 15f;
  public float MeleeDelay;
  public float SwingDistance = 1.5f;
  [System.NonSerialized] public float PanicTimer;

  bool firedSinceLastTimer;
  float timer;
  float panicTimer;
  float meleeTimer;
  bool fireBlast;

	// Update is called once per frame
	void Update () {
    timer -= Time.deltaTime;
    PanicTimer -= Time.deltaTime;
    FireCheck("Fire1", false);
    MeleeCheck("Fire2");
    FireCheck("Fire3", true, PanicTimer < 0);
    if (timer > 0f || !firedSinceLastTimer) return;
    if (fireBlast) {
      FireBlast();
    } else {
      FireSingle();
    }
	}

  void MeleeCheck(string input) {
    meleeTimer -= Time.deltaTime;
    if (meleeTimer >= 0f || !Input.GetButtonDown(input)) return;
    var mouseDir = GetMouseDir();
    var position = (Vector2)transform.position + mouseDir * SwingDistance;
    var angle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
    Instantiate(SwingPrefab, position, Quaternion.Euler(0, 0, angle - 90f));
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

  Vector2 GetMouseDir() {
    var camera = Camera.main;
    var mousePosition = (Vector2)camera.ScreenToWorldPoint(Input.mousePosition);
    return (mousePosition - (Vector2)transform.position).normalized;
  }

  void FireSingle() => Fire(ProjectilePrefab, GetMouseDir());

  void Fire(GameObject prefab, Vector2 direction) {
    var projectile = Instantiate(prefab, transform.position, Quaternion.identity);
    projectile.GetComponent<Projectile>().Movement = ShotSpeed * direction;
    firedSinceLastTimer = false;
    timer = MinDelayProjectile;
  }

}
