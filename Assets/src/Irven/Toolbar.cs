using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar : MonoBehaviour
{
    public GameObject Slider;

    void Start()
    {
        Slider.gameObject.SetActive(false);
    }

    public void openToolbar()
    {
        Slider.SetActive(!Slider.activeSelf);

    }
}