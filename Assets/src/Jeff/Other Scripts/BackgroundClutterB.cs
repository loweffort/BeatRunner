using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace FactoryPattern
{
    public class BackgroundClutterB : MonoBehaviour
    {
        public Debree1 myObject;
        public Debree2 myObject2;
        public FlyingJunk myObject3;
    
        // Start is called before the first frame update
        void Start()
        {
            gameObject.SetActive(false);
            gameObject.SetActive(false);
            gameObject.SetActive(false);
            }

    }
}
