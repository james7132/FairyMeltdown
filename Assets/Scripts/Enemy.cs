using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

  public enum EnemyTarget {
    None, Player, Reactor
  }

  public EnemyTarget Target;
  public float MovementSpeed = 5f;
  public float DamageDealt = 5f;
  public SpriteRenderer[] Renderers;
  public GameObject[] DeathEffects;

  Transform Player;
  Transform Reactor;

  /// <summary>
  /// Awake is called when the script instance is being loaded.
  /// </summary>
  void Awake() {
    Player = GameObject.FindWithTag("Player").transform;
    Reactor = GameObject.FindWithTag("Reactor").transform;
  }

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update() {
    Transform target = GetTarget();
    if (target == null) return;
    transform.position = Vector3.MoveTowards(transform.position, target.position, MovementSpeed * Time.deltaTime);
  }

  public void Kill() {
    foreach (var effect in DeathEffects) {
      if (effect == null) continue;
      Instantiate(effect, transform.position, effect.transform.rotation);
    }
    Destroy(gameObject);
  }

  Transform GetTarget() {
    switch (Target) {
      case EnemyTarget.Player:
        return Player;
      case EnemyTarget.Reactor:
        return Reactor;
      default:
        return null;
    }
  }

}
