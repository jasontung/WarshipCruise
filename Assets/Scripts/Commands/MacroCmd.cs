using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Recorder;
using UnityEngine;
[CreateAssetMenu]
public class MacroCmd : ICommand
{
    public int loopTimes;
    public ICommand[] commands;

    public override void Setup()
    {
        foreach (var cmd in commands)
        {
            cmd.Setup();
        }
    }

    public override IEnumerator Execute()
    {
        for (int i = 0; i < loopTimes; i++)
        {
            foreach (var cmd in commands)
            {
                yield return cmd.Execute();
            }
        }
    }
}
