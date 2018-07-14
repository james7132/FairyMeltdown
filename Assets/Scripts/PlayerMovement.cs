using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

  public Rigidbody2D Rigidbody;
  public Bounds PlayerBounds;
  public Bounds MovementBounds;
  public float MovementSpeed;

	void Update () {
    var movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    Rigidbody.velocity = movement * MovementSpeed;
	}

  /// <summary>
  /// Callback to draw gizmos that are pickable and always drawn.
  /// </summary>
  void OnDrawGizmos() {
    Gizmos.DrawWireCube(MovementBounds.center, MovementBounds.extents);
    var matrix = Gizmos.matrix;
    Gizmos.matrix = transform.localToWorldMatrix;
    Gizmos.DrawWireCube(PlayerBounds.center, PlayerBounds.extents);
    Gizmos.matrix = matrix;
  }
}
