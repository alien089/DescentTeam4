using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableAmmo : MonoBehaviour
{
    public PickableType PickableType;
    public int Amount;
    public float TimerPopUp;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IPlayer player))
        {
            PlayerShooting playerShooting = other.GetComponent<PlayerShooting>();
            switch (PickableType)
            {
                case PickableType.LaserAmmo:
                    ((Laser)playerShooting.PrimaryList[0]).AmmoCount += Amount;
                    UI.instance.Notification.text = "Energy increased to " + (int)(((Laser)playerShooting.PrimaryList[0]).AmmoCount);
                    StartCoroutine(TimerNotification());
                    break;
                case PickableType.VulcanAmmo:
                    ((Vulcan)playerShooting.PrimaryList[1]).AmmoCount += Amount;
                    UI.instance.Notification.text = "Vulcan Ammo!";
                    StartCoroutine(TimerNotification());
                    break;
                case PickableType.ConcussionMissileAmmo:
                    ((ConcussionMissile)playerShooting.SecondaryList[0]).AmmoCount += Amount;
                    UI.instance.Notification.text = Amount + " concussion missile!";
                    StartCoroutine(TimerNotification());
                    break;
                case PickableType.HomingMissileAmmo:
                    ((HomingMissile)playerShooting.SecondaryList[1]).AmmoCount += Amount;
                    UI.instance.Notification.text = Amount + " homing missile!";
                    StartCoroutine(TimerNotification());
                    break;
                case PickableType.Shield:
                    other.GetComponent<PlayerStats>().Shield += Amount;
                    UI.instance.Notification.text = "Shield increased to " + other.GetComponent<PlayerStats>().Shield;
                    StartCoroutine(TimerNotification());
                    break;
                case PickableType.Vulcan:
                    playerShooting.VulcanEnable = true;
                    UI.instance.Notification.text = "Vulcan Gun!";
                    break;
                case PickableType.Hostage:
                    StageManager.instance.HostagesCount++;
                    StartCoroutine(TimerNotification());
                    break;
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator TimerNotification()
    {
        yield return new WaitForSeconds(TimerPopUp);
        UI.instance.Notification.text = "";
    }
}
