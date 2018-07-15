using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDialogue : MonoBehaviour {

  public AudioSource BGM;
  public AudioClip GameOverBGM;

  public void GameOver() {
    Time.timeScale = 0f;
    gameObject.SetActive(true);
    BGM.Stop();
    BGM.clip = GameOverBGM;
    BGM.Play();
  }

  public void ResetTimescale() {
    Time.timeScale = 1f;
  }

  public void LoadScene(string scene) => SceneManager.LoadScene(scene);

}
