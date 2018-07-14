using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

  public GameObject ProjectilePrefab;
  public float MinDelayProjectile;
  public KeyCode FireKey = KeyCode.E;
  public float ShotSpeed = 5;

  bool firedSinceLastTimer;
  float timer;

  Vector2 oldPosition;
  Vector2 direction;

  /// <summary>
  /// Awake is called when the script instance is being loaded.
  /// </summary>
  void Awake() {
    oldPosition = transform.position;
    direction = -Vector2.right;
  }

	// Update is called once per frame
	void Update () {
    var diff = (Vector2)transform.position - oldPosition;
    if (diff != Vector2.zero) {
      direction = diff.normalized;
    }
    firedSinceLastTimer |= Input.GetKeyDown(FireKey);
    timer -= Time.deltaTime;
    if (timer <= 0f && firedSinceLastTimer) {
      firedSinceLastTimer = false;
      timer = MinDelayProjectile;
      var projectile = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
      projectile.GetComponent<Projectile>().Movement = ShotSpeed * direction;
    }
    oldPosition = transform.position;
	}

}
