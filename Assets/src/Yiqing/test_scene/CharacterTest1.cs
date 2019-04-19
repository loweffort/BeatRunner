using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterTest1 : MonoBehaviour
{
    public void startTest()
    {
        Debug.Log("character test load");
        SceneManager.LoadScene(sceneName: "YM_testselect1");
    }
}
