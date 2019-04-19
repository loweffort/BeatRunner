using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleManagerBase 
{
    public abstract void Operation();
}
public class ObstacleManager : ObstacleManagerBase
{
    public GameObject masterBar;
    public GameObject masterWall;
    public GameObject[] obstacles = new GameObject[3];

    public override void Operation(){
        Debug.Log("TEST");

    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

public abstract class ObstacleManagerDecoratorBase : ObstacleManager {
    private ObstacleManager component;

    public ObstacleManagerDecoratorBase( ObstacleManager givenManager )
    {
        component = givenManager;
    }

    public override void Operation()
    {
        component.Operation();
    }
}

public class ObstacleManagerDecorator : ObstacleManagerDecoratorBase{

    private static ObstacleManagerDecorator obstacleManagerDecoratorInstance = null;
    private static readonly object padlock = new object();
    private ObstacleManagerDecorator( ObstacleManager component) : base(component){}

    public static ObstacleManagerDecorator getInstance(ObstacleManager givenManager)
    {
        lock(padlock)
        {
            if(obstacleManagerDecoratorInstance == null)
            {
                obstacleManagerDecoratorInstance = new ObstacleManagerDecorator(givenManager);
            }
            return obstacleManagerDecoratorInstance;
        }
    }

    public override void Operation()
    {
        base.Operation();
        Debug.Log("(modified)");
    }


}

