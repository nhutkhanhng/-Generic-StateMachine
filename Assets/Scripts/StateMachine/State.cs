using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<_Target> : ScriptableObject
{
    #region Transition handler
    [Header("Condition to change state of skill")]
    public List<_Transition<_Target, State<_Target>>> Transitions;
    #endregion


    public List<Activity<_Target>> Actions;

    public virtual void DoActions(StateController<_Target, State<_Target>> controller)
    {
        if (Actions.Available())
        {
            foreach (var act in this.Actions)
            {
                act.Act(controller);
            }
        }
    }

    public virtual void Initialize(StateController<_Target, State<_Target>> controller)
    {
        if (Transitions.Available())
        {
            foreach (var trans in Transitions)
            {
                trans.Init(controller);
            }
        }
    }
}

public abstract class ___State : ScriptableObject
{

}

/// <summary>
/// Sử dụng StateTarget như một StatePattern
/// Kế thừa StateTarget và sử dụng Transition để mở rộng thành State Machine.
/// </summary>
/// <typeparam name="Target"></typeparam>
public abstract class __StateTarget<Target> : ___State
{
    public void Enter(StateController<Target> stateController)
    {

    }
}

public abstract class __StateTransition<_Target, _Transition>
    : __StateTarget<_Target>
    where _Transition : KTransition<__StateTarget<_Target>>
{

}
public abstract class __StateActivation<_Target, _Act> : __StateTarget<_Target> where _Act : Activity<_Target>
{
    public List<_Act> _Actions;
}

public abstract class MyTransition : ScriptableObject
{

}

public abstract class __State<_Target, _Activity, _Transition> : __StateActivation<_Target, _Activity>
    where _Activity : Activity<_Target>
{
    public _Transition Trans;
}

public class TransitionController<_Target, _Decision> where _Decision : __Decision<_Target>
{
    public List<_Decision> _Decisions;
}
public class TestActivity : Activity<CCharacter>
{
    public override void Act(StateController<CCharacter> controller)
    {
        // Do something
    }
}

