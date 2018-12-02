using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class DistanceFromCamCmd : ICommand
{
    public float distance;
    private Transform camRig;
    private Transform cam;
    public string targetTag = "Player";

    public override void Setup()
    {
        camRig = GameObject.FindGameObjectWithTag("CamRig").transform;
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    public override IEnumerator Execute()
    {
        Vector3 lookDir = cam.position - camRig.position;
        lookDir = lookDir.normalized;
        cam.position = lookDir * distance;
        yield return null;
    }
}
