using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsManager : MonoBehaviour
{
    public void OnButtonPress()
    {
        switch (this.gameObject.name) {
            case "PlayButtonManager":
                SceneManager.LoadScene("LevelOne");
                break;
            case "ExitButtonManager":
                Application.Quit();
                break;
        }
    }
}
