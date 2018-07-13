using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenDone : MonoBehaviour {

  public Animator Animator;
	
	// Update is called once per frame
	void Update () {
    if (Animator == null) Destroy(gameObject);
    if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f) {
      Destroy(gameObject);
    }
	}

}
