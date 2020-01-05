using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Transition
[System.Serializable]
public class KTransition<T> where T : class
{
    protected bool _IsTrue;
    public bool IsTrue
    {
        get { return _IsTrue; }
    }
    public T TrueState;
    [Header("Hiện tại chưa dùng đâu")]
    public T FalseState;
}

public enum TypeCondition : byte
{
    AND = 1,
    OR = 2,
}

public class _Transition<Target, State> : KTransition<State> where State : class
{
    public virtual void Init(StateController<Target, State<Target>> controler)
    {

    }

    public virtual void Exit(StateController<Target, State<Target>> controller)
    {

    }

    public virtual void WhenTriggerIsTrue(StateController<Target, State<Target>> controller)
    {

    }
}
#endregion
[System.Serializable]
public class TransitionCondition<_Decision, Target, _State> : KTransition<_State>
                                                where _State : ___State
                                              where _Decision : DecisionTrigger<Target>
{
    protected int CountTriggerIsTrue;
    [Header("Add | OR bit condition")]
    public TypeCondition condition;
    public List<_Decision> Conditions;

    public void TransitionToState(StateController<Target> controller)
    {
        _IsTrue = true;
        Exit(controller);

        /// Chổ này cứ thấy nguy hiểm sao sao á.
        try
        {
            ((StateController<Target, _State>)controller).TransitionToState(this.TrueState);
        }
        catch(Exception Ex)
        {
            Debug.LogError(Ex.Message);
            controller.EndState();
        }

    }

    public virtual void WhenTriggerIsTrue(StateController<Target> controller)
    {
        CountTriggerIsTrue++;
        if (condition == TypeCondition.AND)
        {
            if (CountTriggerIsTrue == Conditions.Count)
            {
                TransitionToState(controller);
            }

            return;
        }

        TransitionToState(controller);
    }
    public virtual void Init(StateController<Target> controller)
    {
        CountTriggerIsTrue = 0;
        _IsTrue = false;

        if (Conditions.Available())
        {
            foreach (var trigger in Conditions)
            {
                trigger.Init(controller);
                trigger.TrueRaise += WhenTriggerIsTrue;
            }
        }
    }

    public virtual void Exit(StateController<Target> controller)
    {
        CountTriggerIsTrue = 0;

        foreach (var trigger in Conditions)
        {
            trigger.TrueRaise -= WhenTriggerIsTrue;
        }
    }
}
