using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar : MonoBehaviour
{
    public GameObject slideBar;

    void Start()
    {
        slideBar.gameObject.SetActive(false);
    }

    public void openToolbar()
    {
        slideBar.SetActive(!slideBar.activeSelf);

    }
}