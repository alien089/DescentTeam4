using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GreenAiBaseState
{
    public abstract void EnterState(GreenAiManager ai);
    public abstract void UpdateState(GreenAiManager ai);
}
