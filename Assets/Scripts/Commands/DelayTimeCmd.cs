using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class DelayTimeCmd : ICommand {
    public float delayTime = 5f;

    public override IEnumerator Execute()
    {
        yield return new WaitForSeconds(delayTime);
    }
}
