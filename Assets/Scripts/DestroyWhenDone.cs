using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenDone : MonoBehaviour {

  public Animator Animator;
  public AudioSource AudioSource;
	
	// Update is called once per frame
	void Update () {
    bool keepGameObject = false;
    if (AudioSource != null) {
      keepGameObject |= AudioSource.isPlaying;
    }
    if (Animator != null)  {
      keepGameObject |= Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f;
    }
    if (!keepGameObject) {
      Destroy(gameObject);
    }
	}

}
