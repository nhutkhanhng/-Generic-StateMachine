using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activity<Target> : ScriptableObject
{
    public abstract void Act(StateController<Target> controller);
}



public abstract class __Decision<Target> : ScriptableObject
{
    public abstract bool Decide(StateController<Target> controller);
}
