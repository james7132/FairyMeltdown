using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

  public Animator Animator;

  Vector2 lastMovement;

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update() {
    var movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    if (movement != Vector2.zero) {
      lastMovement = movement;
    }
    var absX = Mathf.Abs(lastMovement.x);
    var absY = Mathf.Abs(lastMovement.y);
    int vertical = 0;
    if (absX < absY) {
      vertical = movement.y > 0 ? 1 : 2;
    }
    Animator.SetInteger("vertical", vertical);
    if (Input.GetButtonDown("Fire1")) {
      Animator.SetTrigger("attack");
    }
    if (Input.GetButtonDown("Fire2")) {
      Animator.SetTrigger("rangedAttack");
    }
  }

}
