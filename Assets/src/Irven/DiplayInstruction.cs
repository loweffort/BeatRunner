using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiplayInstruction : MonoBehaviour
{
    public GameObject InstructionImage;

    void Start()
    {
       InstructionImage.gameObject.SetActive(false);
    }

    public void openImage()
    {
        InstructionImage.SetActive(!InstructionImage.activeSelf);

    }
}
