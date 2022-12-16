using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpawnedObj : MonoBehaviour
{
    int randomPos = 100;
    public Action OnTimePassed;

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(CallbackAfterTime());
    }

    public void DestroyAfterTime()
    {
        OnTimePassed = () => { Destroy(gameObject); };
    }

    public void DisableAfterTime()
    {
        OnTimePassed = () => { gameObject.SetActive(false); };
    }

    private IEnumerator CallbackAfterTime()
    {
        yield return new WaitForSeconds(2f);
        OnTimePassed?.Invoke();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }

    public void RandomizePosition()
    {
        transform.position = new Vector3(UnityEngine.Random.Range(-randomPos, randomPos), UnityEngine.Random.Range(-randomPos, randomPos), UnityEngine.Random.Range(-randomPos, randomPos));
    }
}