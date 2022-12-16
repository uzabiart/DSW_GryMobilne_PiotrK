using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DebugSpawner : MonoBehaviour
{
    public DebugSpawnedObj prefab;
    public int amountSpawns = 50;
    public float clickTime = 0.1f;
    public bool isDestroyInstantiate;
    public bool isPooling;

    List<DebugSpawnedObj> poolObjects = new List<DebugSpawnedObj>();

    [Button]
    public void InstantiateDestroy()
    {
        StopAllCoroutines();
        SpawnRecursive();
        //StartCoroutine(SpawnRecursive());
    }

    private void FixedUpdate()
    {
        if (isPooling)
        {
            for (int i = 0; i < poolObjects.Count; i++)
            {
                if (poolObjects[i].IsActive()) continue;
                poolObjects[i].RandomizePosition();
                poolObjects[i].Show();
                poolObjects[i].DisableAfterTime();
                break;
            }
        }
        else if (isDestroyInstantiate)
        {
            DebugSpawnedObj obj = Instantiate(prefab, transform);
            obj.RandomizePosition();
            obj.DestroyAfterTime();
        }
    }

    private async void SpawnRecursive()
    {
        DebugSpawnedObj obj = Instantiate(prefab, transform);
        obj.RandomizePosition();
        obj.DestroyAfterTime();
        await Task.Delay(1);
        //yield return new WaitForSeconds(clickTime);
        SpawnRecursive();
        //StartCoroutine(SpawnRecursive());
    }

    // Pooling v-v
    [Button]
    public void PoolInit()
    {
        for (int i = 0; i < amountSpawns; i++)
        {
            DebugSpawnedObj obj = Instantiate(prefab, transform);
            obj.RandomizePosition();
            obj.Hide();
            poolObjects.Add(obj);
        }
    }

    [Button]
    public void StartPool()
    {
        StopAllCoroutines();
        PoolingRecursive();
    }
    [Button]
    public void StopPool()
    {
        StopAllCoroutines();
    }

    private async void PoolingRecursive()
    {
        while (true)
        {
            for (int i = 0; i < poolObjects.Count; i++)
            {
                if (poolObjects[i].IsActive()) continue;
                poolObjects[i].RandomizePosition();
                poolObjects[i].Show();
                poolObjects[i].DisableAfterTime();
                break;
            }
            await Task.Delay(1);
            //yield return new WaitForSeconds(clickTime);
        }
        //StartCoroutine(SpawnRecursive());
    }
}