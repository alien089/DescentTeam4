using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSearchState : AiBaseState
{
    static Dictionary<int, Vector3> cachedDirections = new Dictionary<int, Vector3>();
    float timer = 0;

    public override void EnterState(AiStateManager ai)
    {
        ai.StartCoroutine(CheckAndDestroy(ai));
    }

    /// <summary>
    /// Go in random Direction, wait a few +seconds and repeat
    /// </summary>
    /// <param name="ai"></param>
    public override void UpdateState(AiStateManager ai)
    {
        if (!ai.IsSpawned)
            return;

        timer += Time.deltaTime;

        if (timer >= ai.TimeToMove)
        {
            timer = 0;
            ai.StartCoroutine(StopAddingForce(ai.StartCoroutine(AddingForce(ai)), ai));
        }
    }

    private Vector3 RandomVector(AiStateManager ai)
    {
        cachedDirections = new Dictionary<int, Vector3>()
        {
            {0 , ai.transform.up },
            {1, ai.transform.right },
            {2, ai.transform.forward },
        };

        return cachedDirections[Random.Range(0, cachedDirections.Keys.Count)];
    }

    IEnumerator AddingForce(AiStateManager ai)
    {
        Vector3 target = RandomVector(ai);
        for (; ; )
        {
            ai.Body.AddForce(ai.WanderMovingSpeed * 1000f * Time.fixedDeltaTime * target);
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator StopAddingForce(Coroutine coroutine, AiStateManager ai)
    {
        yield return new WaitForSeconds(ai.MovingTime);
        ai.StopCoroutine(coroutine);
    }
    IEnumerator CheckAndDestroy(AiStateManager ai)
    {
        while (!ai.IsSpawned)
        {
            ai.IsSpawned = ai.FOV.AiCanSee;
            yield return float.NegativeInfinity;
        }
    }
}