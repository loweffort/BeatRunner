using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//character jump
public class Client : MonoBehaviour {
	// Use this for initialization
	public Receiver avator;
	Stack<Command> commandStack;
	Command cmd;
	Invoker invoker;
	bool isjump = false;

	//binding command
    private KeyCode left = KeyCode.A;
    private KeyCode right = KeyCode.D;
    private KeyCode jump = KeyCode.Space;

	void Start () {
		avator = gameObject.GetComponent<Receiver> ();
		commandStack = new Stack<Command> ();
		invoker = new Invoker ();
	}
	
	// Update is called once per frame
	void Update () {
		cmd = Inputhander ();
		invoker.setCommand (cmd);
		if (!isjump) {
			control ();
		} else {
			runCallBack ();
		}
	}

		
	void control(){
		if (cmd!=null) {
			commandStack.Push (cmd);
			invoker.action (avator);
		}
	}

	void runCallBack(){
		if (commandStack.Count > 0) {
			commandStack.Pop ().undo (avator);
		}
	}
		

	//callback execute command
	public void callBack(){
		isjump = false;
	}

	//run
	public void run(){
		isjump = true;
	}

	//input jump command
	//the character height is 5.5 should make should the transform position of y 
	//is not larger than 5.5 so it can do jump movement
	//the character will jump 25 height which will not jump out of camera
	Command Inputhander(){
		if (Input.GetKey (jump) && transform.position.y < 6 ) {
			Debug.Log ("Jump sucess");
			return new CommandMove(new Vector3(GetComponent<Rigidbody>().velocity.x, 25, 0));
		}
		return null;
	}
		
}
