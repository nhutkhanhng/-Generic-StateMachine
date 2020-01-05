using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[CreateAssetMenu(menuName = "KSkill/StateController/Controller")]
[System.Serializable]
public class CStateController : StateController<CCharacter, CState>
{
    public override void TransitionToState(CState nextState)
    {
        this.Current = (CState)nextState;

        if (this.Current.transitions.Available())
        {
            foreach(var transition in this.Current.transitions)
            {
                transition.Init(this);
            }
        }
    }
}
