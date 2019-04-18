using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMemory : MonoBehaviour
{
    // caretaker
        public Momento2 _memento;

        // Property

        public Momento2 Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
}

