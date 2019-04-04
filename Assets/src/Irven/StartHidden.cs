using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHidden : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        Panel.gameObject.SetActive(false);
    }


}
