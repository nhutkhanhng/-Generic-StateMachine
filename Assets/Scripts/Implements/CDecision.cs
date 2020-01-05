using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "KSkill/CDecision/Decision")]
public class CDecision : CDecisionTrigger
{
    public float Condition = 5;
    /// <summary>
    /// Cái này đơcj dùng nếu muố update liên tục khi mà callback không có.
    /// Nhưng nếu làm vầy thì class này chứa quá nhiều thông tin.
    /// </summary>
    /// <param name="controller"></param>
    /// <returns></returns>
    public override bool Decide(StateController<CCharacter> controller)
    {
        return OnDecide(controller._Owner);
    }

    protected bool OnDecide(CCharacter target)
    {
        if (target.A == Condition)
        {
            TrueRaise?.Invoke(this.ControllerOwner);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Init của TransitionTrigerr là để callback when attribute changed
    /// </summary>
    /// <param name="controller"></param>
    public override void Init(StateController<CCharacter> controller)
    {
        this.ControllerOwner = controller;

        // Set up deltege from owner;
        this.ControllerOwner._Owner.callback += OnDecide;
    }
}
