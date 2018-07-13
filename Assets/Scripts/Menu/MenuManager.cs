using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

  public GameObject CurrentMenu;

  public void SetMenu(GameObject go) {
    if (CurrentMenu != null) {
      CurrentMenu.SetActive(false);
    }
    CurrentMenu = go;
    if (CurrentMenu != null) {
      CurrentMenu.SetActive(true);
    }
  }

  public void QuitGame() => Application.Quit();

  public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);

}
