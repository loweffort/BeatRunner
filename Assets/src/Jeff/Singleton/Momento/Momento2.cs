using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Momento2 : MonoBehaviour
{
        public string _name;
        public double _score;
        public double _multiplier;

        // Constructor
        public Momento2(string name, double score, double multiplier)
        {
            this._name = name;
            this._score = score;
            this._multiplier = multiplier;
        }

        // Gets or sets name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Gets or set phone

        public double Score
        {
            get { return _score; }
            set { _score = value; }
        }

        // Gets or sets budget

        public double Multiplier
        {
            get { return _multiplier; }
            set { _multiplier = value; }
        }
    }
