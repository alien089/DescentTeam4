using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAbleAmmo : MonoBehaviour
{
    public PickableType PickableType;
    public int Amount;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IPlayer player))
        {
            PlayerShooting playerShooting = other.GetComponent<PlayerShooting>();
            switch (PickableType)
            {
                case PickableType.LaserAmmo:
                    ((Laser)playerShooting.PrimaryList[0]).AmmoCount += Amount;
                    break;
                case PickableType.VulcanAmmo:
                    ((Vulcan)playerShooting.PrimaryList[1]).AmmoCount += Amount;
                    break;
                case PickableType.ConcussionMissileAmmo:
                    ((ConcussionMissile)playerShooting.SecondaryList[0]).AmmoCount += Amount;
                    break;
                case PickableType.HomingMissileAmmo:
                    ((HomingMissile)playerShooting.SecondaryList[1]).AmmoCount += Amount;
                    break;
                case PickableType.Shield:
                    other.GetComponent<PlayerStats>().Shield += Amount;
                    break;
                case PickableType.Vulcan:
                    playerShooting.VulcanEnable = true;
                    break;
                case PickableType.Hostage:
                    StageManager.instance.HostagesCount++;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
