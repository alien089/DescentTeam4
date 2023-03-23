using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiBaseState
{
    public abstract void EnterState(AiStateManager ai);
    public abstract void UpdateState(AiStateManager ai);
}
