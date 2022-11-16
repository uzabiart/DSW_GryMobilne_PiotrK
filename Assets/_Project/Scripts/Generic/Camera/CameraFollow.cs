using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    public Camera camera;
    public Player player;
    public Vector3 positionMod;

    private void Start()
    {
        Debug.Log("Small change");
        camera = FindObjectOfType<Camera>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        //camera.transform.position = player.transform.position + positionMod;
        camera.transform.DOMove(player.transform.position + positionMod, 1f);
    }
}
