using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPlayer : MonoBehaviour {

  public Transform Player;
  float zIndex;

  /// <summary>
  /// Awake is called when the script instance is being loaded.
  /// </summary>
  void Awake() {
    if (Player == null) {
      Player = GameObject.FindWithTag("Player").transform;
    }
    zIndex = transform.position.z;
  }

	// Update is called once per frame
	void Update () {
    var pos = Player.position;
    pos.z = zIndex;
    transform.position = pos;
	}

}
