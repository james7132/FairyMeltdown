using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDialogue : MonoBehaviour {

  public void GameOver() {
    Time.timeScale = 0f;
    gameObject.SetActive(true);
  }

  public void ResetTimescale() {
    Time.timeScale = 1f;
  }

  public void LoadScene(string scene) => SceneManager.LoadScene(scene);

}
