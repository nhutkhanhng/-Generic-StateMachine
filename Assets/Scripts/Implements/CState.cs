using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "KSkill/CState/State")]
public class CState : __StateActivation<CCharacter, Activity<CCharacter>>
{
    public List<CTransition> transitions;
}
