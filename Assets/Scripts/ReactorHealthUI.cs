using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactorHealthUI : MonoBehaviour {

  public Reactor Reactor;
  public Image HealthBar;
  public Image Nuclear;

  public float MaxSinusoidSpeed = 5;
  public Gradient NuclearGradient;

	// Use this for initialization
	void Start () {
    if (Reactor == null) {
      Reactor = GameObject.FindWithTag("Reactor").GetComponent<Reactor>();
    }
	}

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update() {
    UpdateHealthBar();
    UpdateNuclear();
  }

  void UpdateHealthBar() {
    if (HealthBar == null) return;
    HealthBar.fillAmount = Reactor.ReactorCurrentHealth / Reactor.ReactorHealth;
  }

  void UpdateNuclear() {
    if (Nuclear == null) return;
    var fraction = 1 - Reactor.ReactorCurrentHealth / Reactor.ReactorHealth;
    var sinusoid = Mathf.Sin(Time.unscaledTime * MaxSinusoidSpeed * fraction);
    var amount =  sinusoid / 2 + 0.5f;
    Nuclear.color = NuclearGradient.Evaluate(amount);
  }


}
