using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class RotateCmd : ICommand
{
    private Transform camRig;
    private Transform target;
    public Vector3 angleInterval;
    public string targetTag = "Player";
    public override void Setup()
    {
        camRig = GameObject.FindGameObjectWithTag("CamRig").transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override IEnumerator Execute()
    {
        Vector3 desiredAngle = camRig.eulerAngles + angleInterval;
        camRig.rotation = Quaternion.Euler(desiredAngle);
        Debug.Log("Desired " + desiredAngle + ", camRig " + camRig.eulerAngles);
        yield return null;
    }
}
