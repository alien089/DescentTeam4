using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum WichEnemy
{
    yellow,
    blue,
    green
}
public class KilledEnemy : MonoBehaviour
{
    [SerializeField]
    private WichEnemy current;

    private void OnDestroy()
    {
        switch (current)
        {
            case WichEnemy.yellow:
                ScoreSaver.Instance.MyObs.KilledYellowEnemy += 1;
                break;
            case WichEnemy.blue:
                ScoreSaver.Instance.MyObs.KilledBlueEnemy += 1;
                break;
            case WichEnemy.green:
                ScoreSaver.Instance.MyObs.KilledGreenEnemey += 1;
                break;
        }
    }
}
