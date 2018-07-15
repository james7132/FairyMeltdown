using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenDone : MonoBehaviour {

  public Animator Animator;
  public Animation Animation;
  public AudioSource AudioSource;
  public ParticleSystem ParticleSystem;
	
	// Update is called once per frame
	void Update () {
    bool keepGameObject = false;
    if (AudioSource != null) {
      keepGameObject |= AudioSource.isPlaying;
    }
    if (Animator != null)  {
      keepGameObject |= Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f;
    }
    if (ParticleSystem != null) {
      keepGameObject |= ParticleSystem.isPlaying;
    }
    if (Animation != null) {
      keepGameObject |= Animation.isPlaying;
    }
    if (!keepGameObject) {
      Destroy(gameObject);
    }
	}

}
