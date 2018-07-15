using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Reactor : MonoBehaviour {

  public UnityEvent ReactorDestroyed;

  public float ReactorHealth = 100f;
  public float DefaultEnemyDamage = 5f;

  [System.NonSerialized]
  public float ReactorCurrentHealth;

  /// <summary>
  /// Awake is called when the script instance is being loaded.
  /// </summary>
  void Awake() {
    ReactorCurrentHealth = ReactorHealth;
  }

  /// <summary>
  /// Sent when another object enters a trigger collider attached to this
  /// object (2D physics only).
  /// </summary>
  /// <param name="other">The other Collider2D involved in this collision.</param>
  void OnTriggerEnter2D(Collider2D other) {
    if (!other.CompareTag("Enemy")) return;

    var damage =  DefaultEnemyDamage;
    var enemy = other.GetComponentInChildren<Enemy>();
    if (enemy != null) {
      damage = enemy.DamageDealt;
    }
    ReactorCurrentHealth -= damage;
    if (ReactorCurrentHealth <= 0) {
      ReactorDestroyed.Invoke();
      Debug.Log("Game over!");
      Debug.Break();
    }

    Destroy(other.gameObject);
  }

}
