using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEnemy { }
public interface IPlayer { }
public interface IDamageable 
{
    void Damage(int damage);
    void LifeCheck();
}
public interface IBullet { }