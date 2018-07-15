using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveText : MonoBehaviour {

  public Text UIText;

  string formatString;

  string GetFormatString() {
    if (formatString == null) {
      formatString = UIText.text;
    }
    return formatString;
  }

  public void SetWaveCount(int count) => UIText.text = string.Format(GetFormatString(), count);

}
