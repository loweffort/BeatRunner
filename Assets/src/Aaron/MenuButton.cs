using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MenuButtonBase : MonoBehaviour
{
    public abstract void changeScene();
}

public class MenuButton : MenuButtonBase
{
    public override void changeScene()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }
}