using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

  public Animator Animator;

  bool PlayerFacing;
  Vector3 oldPosition;

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update() {
    oldPosition = transform.position;
  }

  /// <summary>
  /// LateUpdate is called every frame, if the Behaviour is enabled.
  /// It is called after all Update functions have been called.
  /// </summary>
  void LateUpdate() {
    var diff = transform.position - oldPosition;
    if (diff.x > 0) {
      PlayerFacing = true;
    } else if (diff.x < 0) {
      PlayerFacing = false;
    }
    Animator.SetBool("Facing", PlayerFacing);
  }

}
