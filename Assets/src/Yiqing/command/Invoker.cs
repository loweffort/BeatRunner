using UnityEngine;
using System.Collections;

public class Invoker : MonoBehaviour{

	Command command;
	//get command
	public void setCommand(Command command){
		this.command = command;
	}
	//execute command
	public void action(Receiver avator){
		this.command.execute (avator);
	}
}

