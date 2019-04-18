using UnityEngine;
using System.Collections;

public class CommandMove : Command {
    
    Vector3 trans;

    public CommandMove(Vector3 m){
        trans = m;
    }

    public override void execute (Receiver avator){
        avator.move (trans);
    }

    public override void undo (Receiver avator){
        avator.move (-trans);
    }
}
