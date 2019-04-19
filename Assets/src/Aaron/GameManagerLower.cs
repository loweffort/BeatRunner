using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerLower : MonoBehaviour
{
   public void StartFrameTest(){
       SceneManager.LoadScene(sceneName: "GameManagerLowerBoundaryTesting");
   }
}
