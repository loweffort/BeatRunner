using UnityEngine;
using System.Collections;
//Command class that we will inherit from
//command pattern - Behavioral Patterns

public class Command{

	//All clients of Command objects treat each object as a "black box" by simply 
	//invoking the object's virtual execute() method whenever the client requires the object's "service".
	public virtual void execute(Receiver avator){} 
	public virtual void undo(Receiver avator){}
}
