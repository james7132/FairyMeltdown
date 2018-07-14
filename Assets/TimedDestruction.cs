using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestruction : MonoBehaviour {

  public float Lifetime;

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update() {
    Lifetime -= Time.deltaTime;
    if (Lifetime <= 0) Destroy(gameObject);
  }

}
