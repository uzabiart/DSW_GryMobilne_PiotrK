using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptimizationExamples : MonoBehaviour
{
    private void Update()
    {
    }

    public void Debug()
    {
    }
}

public class Gameplay
{
    public ZerglingData zerglingData;

    public void CreateNewZergling()
    {
        Zergling newZergling = new Zergling(zerglingData);
    }
}

[CreateAssetMenu(menuName = "UMI/NewZergling")]
public class ZerglingData : ScriptableObject
{
    public int maxHp = 10;
    public float movSpeed = 3.4f;
    public string unitName = "Zergling";
}

public class Zergling
{
    public ZerglingData data;

    public Zergling(ZerglingData data)
    {
        this.data = data;
        curHp = data.maxHp;
    }

    public int curHp;
}