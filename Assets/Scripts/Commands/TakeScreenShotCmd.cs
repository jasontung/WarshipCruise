using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Recorder;
using UnityEngine;
[CreateAssetMenu]
public class TakeScreenShotCmd : ICommand {

    public override IEnumerator Execute()
    {
        var recorderWindow = EditorWindow.GetWindow<RecorderWindow>();
        recorderWindow.StartRecording();
        while (recorderWindow.m_State != RecorderWindow.State.Idle)
            yield return null;
    }
}
