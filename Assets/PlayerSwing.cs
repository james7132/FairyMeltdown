using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour {

  public GameObject Player;
  public float RepelSpeed = 5f;

  /// <summary>
  /// Awake is called when the script instance is being loaded.
  /// </summary>
  void Awake() {
    Player = GameObject.FindWithTag("Player");
  }

  /// <summary>
  /// Sent when another object enters a trigger collider attached to this
  /// object (2D physics only).
  /// </summary>
  /// <param name="other">The other Collider2D involved in this collision.</param>
  void OnTriggerEnter2D(Collider2D other) => Trigger(other);

  /// <summary>
  /// Sent each frame where another object is within a trigger collider
  /// attached to this object (2D physics only).
  /// </summary>
  /// <param name="other">The other Collider2D involved in this collision.</param>
  void OnTriggerStay2D(Collider2D other) => Trigger(other);

  void Trigger(Collider2D other ) {
    if (!other.CompareTag("Enemy")) return;
    var rigidbody = other.GetComponent<Rigidbody2D>();
    if (rigidbody == null) return;
    var diff = Player.transform.position - other.transform.position;
    var dir = -diff.normalized;
    rigidbody.velocity = RepelSpeed * dir;
  }

}
