using UnityEngine;
using System.Collections;
//Command class that we will inherit from
public class Command{

	public virtual void execute(Receiver avator){}
	public virtual void undo(Receiver avator){}
}
