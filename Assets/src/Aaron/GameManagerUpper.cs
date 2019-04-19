using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerUpper : MonoBehaviour
{
   public void StartFrameTest(){
       SceneManager.LoadScene(sceneName: "GameManagerUpperBoundaryTesting");
   }
}
