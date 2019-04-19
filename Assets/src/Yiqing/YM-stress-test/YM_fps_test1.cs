using UnityEngine;
using UnityEngine.UI;

public class YM_fps_test1 : MonoBehaviour
{
    public static int avgFrameRate;
    public Text display_Text;

    public void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString() + " FPS";
    }

}
