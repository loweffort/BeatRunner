using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace FactoryPattern
{
    public class BackgroundClutterA : MonoBehaviour
    {
        public Debree1 myObject;
        public Debree2 myObject2;
        public Debree3 myObject3;

        // Start is called before the first frame update
        void Start()
        {
            gameObject.SetActive(true);
            gameObject.SetActive(true);
            gameObject.SetActive(true);
        }

    }
}
