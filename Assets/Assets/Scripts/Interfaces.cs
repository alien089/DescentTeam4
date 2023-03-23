using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEnemy { }
public interface IPlayer { }
public interface IDamageable 
{
    /// <summary>
    /// Function for calculate health after take damage
    /// </summary>
    /// <param name="damage"></param>
    void Damage(int damage);

    /// <summary>
    /// Check if the entity is alive and what happens if it isn't
    /// </summary>
    void LifeCheck();
}
public interface IBullet { }