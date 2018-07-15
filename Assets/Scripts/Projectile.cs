using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

  public Vector2 Movement;

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update() {
    transform.Translate(Movement * Time.deltaTime);
  }

  /// <summary>
  /// Sent when another object enters a trigger collider attached to this
  /// object (2D physics only).
  /// </summary>
  /// <param name="other">The other Collider2D involved in this collision.</param>
  void OnTriggerEnter2D(Collider2D other) {
    if (!other.CompareTag("Enemy")) return;
    var enemy = other.GetComponent<Enemy>();
    if (enemy != null) {
      enemy.Kill();
    } else {
      Destroy(other.gameObject);
    }
  }

}
