using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsOnDeath : MonoBehaviour {

  public GameObject[] DeathEffects;

  /// <summary>
  /// This function is called when the behaviour becomes disabled or inactive.
  /// </summary>
  void OnDisable()
  {
    if (!Application.isPlaying) return;
    foreach (var effect in DeathEffects) {
      if (effect == null) continue;
      Instantiate(effect, transform.position, Quaternion.identity);
    }
  }

}
