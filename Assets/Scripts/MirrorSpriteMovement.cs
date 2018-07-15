using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorSpriteMovement : MonoBehaviour {

  public SpriteRenderer[] Renderers;
  public bool Inverse;

  bool facing;
  Vector3 oldPosition;

  /// <summary>
  /// Start is called on the frame when a script is enabled just before
  /// any of the Update methods is called the first time.
  /// </summary>
  void Start() {
    oldPosition = transform.position;
  }

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update() {
    var diff = transform.position - oldPosition;
    if (diff.x > 0) {
      facing = Inverse ? true : false;
    } else if (diff.x < 0) {
      facing = Inverse ? false : true;
    }
    foreach (var renderer in Renderers) {
      renderer.flipX = facing;
    }
    oldPosition = transform.position;
  }

}
