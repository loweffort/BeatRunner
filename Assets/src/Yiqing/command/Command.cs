using UnityEngine;
using System.Collections;
//Command class that we will inherit from
//command pattern - Behavioral Patterns

public class Command{

	public virtual void execute(Receiver avator){} 
	public virtual void undo(Receiver avator){}
}
