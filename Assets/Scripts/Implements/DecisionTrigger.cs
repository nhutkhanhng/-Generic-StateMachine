using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecisionTrigger<V> : __Decision<V>
{
    public StateController<V> ControllerOwner;

    protected int Counter;

    public System.Action<StateController<V>> TrueRaise;
    public abstract void Init(StateController<V> controller);

    public virtual void Reset()
    {
        Counter = 0;
        TrueRaise = null;
    }
}