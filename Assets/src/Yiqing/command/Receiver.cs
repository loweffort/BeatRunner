using UnityEngine;
using System.Collections;
// Receive class - this handles what a move command actually does
public class Receiver : MonoBehaviour {
	
	public void move(Vector3 T){
		transform.Translate (T);
	}
}
