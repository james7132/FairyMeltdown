using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorSpriteMovement : MonoBehaviour {

  public SpriteRenderer[] Renderers;
  public bool Inverse;

  bool facing;
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
      facing = Inverse ? true : false;
    } else if (diff.x < 0) {
      facing = Inverse ? false : true;
    }
    foreach (var renderer in Renderers) {
      renderer.flipX = facing;
    }
  }

}
