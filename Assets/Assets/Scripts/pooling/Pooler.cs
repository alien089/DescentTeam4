using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{

    public PoolObject poolableObject;
    public int spawnNumber;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< spawnNumber; i++)
        {
            SpawnNewObjectPool();
        }
    }

    public void GetObject(Transform player)
    {
        for(int i = 0; i< transform.childCount; i++)
        {
            if (!transform.GetChild(i).gameObject.activeInHierarchy)
            {
                transform.GetChild(i).position = player.position;
                transform.GetChild(i).rotation = player.rotation;
                transform.GetChild(i).SetParent(player);
                return;
            }
        }
        var go = SpawnNewObjectPool();
        go.transform.SetParent(player);
        go.gameObject.SetActive(true);
    }

    public PoolObject SpawnNewObjectPool()
    {
        var pool = Instantiate(poolableObject, transform);
        pool.pooler = this;
        pool.gameObject.SetActive(false);
        return pool;
    }
}
