using System;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
[System.Serializable]
public class SerializedDictionary<TKey, TValue>
{
    [SerializeField, HideInInspector] private TKey[] keyData;
    [SerializeField, HideInInspector] private TValue[] valueData;
    [SerializeField, HideInInspector] private int count;

    public TValue this[TKey key]
    {
        get
        {
            int index = FindIndex(key);
            if (index >= 0)
                return valueData[index];
            throw new KeyNotFoundException(key.ToString());
        }
        set { Insert(key, value); }
    }

    public SerializedDictionary()
        : this(20)
    {
    }
    public SerializedDictionary(int capacity)
    {
        Resize(capacity);
        ResetIndexer();
    }

    public void Add(TKey key, TValue value)
    {
        if (FindIndex(key) != -1)
            throw new Exception(" Can't add new value, key exsist in dictionary");

        if (AreFully())
            ResizeAndCopy(count * 2);

        keyData[count] = key;
        valueData[count] = value;
        IncreaseIndexer();
    }

    public void DisplayDictionary()
    {
        for (int i = 0; i < count; i++)
        {
            Debug.Log("Key: " + keyData[i] + " Value: " + valueData[i]);
        }
    }
    public bool Remove(TKey key)
    {
        int index = FindIndex(key);
        if (index < 0)
            return false;
        count--;
        for (int i = index; i < count; i++)
        {
            keyData[i] = keyData[i + 1];
            valueData[i] = valueData[i + 1];
        }

        return true;
    }
    public bool ContainsKey(TKey key)
    {
        if (FindIndex(key) != -1)
            return true;
        return false;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        value = default;

        int index = FindIndex(key);
        if (index < 0)
            return false;
        value = valueData[index];
        return true;
    }

    public int Count { get => count; }
    public void Clear()
    {
        for (int i = 0; i < keyData.Length; i++)
        {
            keyData[i] = default;
            valueData[i] = default;
        }
        count = 0;
    }
    private void Resize(int newSize)
    {
        keyData = new TKey[newSize];
        valueData = new TValue[newSize];
    }
    private void ResizeAndCopy(int newSize)
    {
        TKey[] keyDataCopy = new TKey[newSize];
        TValue[] valueDataCopy = new TValue[newSize];

        Array.Copy(keyData, 0, keyDataCopy, 0, count);
        Array.Copy(valueData, 0, valueDataCopy, 0, count);

        keyData = keyDataCopy;
        valueData = valueDataCopy;
    }
    private void Insert(TKey key, TValue value)
    {
        int index = FindIndex(key);
        if (index < 0)
            throw new KeyNotFoundException(key.ToString());

        valueData[index] = value;
    }
    private int FindIndex(TKey key)
    {
        for (int i = 0; i < count; i++)
        {
            if (keyData[i].Equals(key))
            {
                return i;
            }
        }
        return -1;
    }
    private void ResetIndexer()
    {
        count = 0;
    }
    private void IncreaseIndexer()
    {
        count++;
    }
    private bool AreFully()
    {
        if (count > keyData.Length - 1)
            return true;
        return false;
    }
}