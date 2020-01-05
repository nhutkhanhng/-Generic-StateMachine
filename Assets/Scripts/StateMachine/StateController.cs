using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacter
{
    protected float _A;

    public System.Func<CCharacter, bool> callback;

    protected void OnAChanged()
    {
        callback?.Invoke(this);
    }

    public float A
    {
        get { return _A; }
        set
        {
            _A = value;

            OnAChanged();
        }
    }
}
public abstract class StateController
{

}

public abstract class StateController<Target> : StateController
{
    public Target _Owner;

    public virtual void EndState() { }
}
/// <summary>
/// 
/// </summary>
public abstract class StateController<Target, _State> : StateController<Target>
    //where _State: ___State
{
    
    public _State Current;
    [Space][Space][Space]
    public _State _Init;
    public _State _End;
    public abstract void TransitionToState(_State nextState);

    public void Init(Target owner)
    {
        this._Owner = owner;
        TransitionToState(_Init);
    }
}



public abstract class TransitionController<_Transition> : ScriptableObject
{
    public enum ETypeCondition : byte
    {
        AND,
        OR
    }

    public List<_Transition> _Transitions;

}
