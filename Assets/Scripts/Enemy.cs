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
    var diff = target.position - transform.position;
 
    foreach (var renderer in Renderers) {
      renderer.flipX = diff.x > 0;
    }

    transform.position = Vector3.MoveTowards(transform.position, target.position, MovementSpeed * Time.deltaTime);
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
