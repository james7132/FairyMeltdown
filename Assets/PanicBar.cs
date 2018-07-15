using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanicBar : MonoBehaviour {

  public PlayerAttack Attack;
  public Image Image;
  public Gradient FillColor;

	// Update is called once per frame
	void Update () {
    Image.fillAmount = 1 - Attack.PanicTimer / Attack.PanicDelay;
    Image.color = FillColor.Evaluate(Image.fillAmount);
	}

}
