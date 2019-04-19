using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditBackground : MonoBehaviour
{
    public GameObject creditImage;

    void Start()
    {
       creditImage.gameObject.SetActive(false);
    }

    public void openToolbar()
    {
        creditImage.SetActive(!creditImage.activeSelf);

    }
}
