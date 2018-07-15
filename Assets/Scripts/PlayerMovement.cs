using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour {

  public UnityEvent OnDeath;

  public Rigidbody2D Rigidbody;
  public float MovementSpeed;

	void Update () {
    var movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    Rigidbody.velocity = movement * MovementSpeed;
	}

  /// <summary>
  /// Sent when an incoming collider makes contact with this object's
  /// collider (2D physics only).
  /// </summary>
  /// <param name="other">The Collision2D data associated with this collision.</param>
  void OnCollisionEnter2D(Collision2D other) {
    if (!other.gameObject.CompareTag("Enemy")) return;
    if (other.gameObject.GetComponent<Enemy>() != null) {
      OnDeath.Invoke();
    }
  }

}
