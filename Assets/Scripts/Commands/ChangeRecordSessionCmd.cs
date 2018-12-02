using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Recorder;
using UnityEngine;
[CreateAssetMenu]
public class ChangeRecordSessionCmd : ICommand
{
    public string sessionName;
    public override IEnumerator Execute()
    {
        var recorderWindow = EditorWindow.GetWindow<RecorderWindow>();
        RecorderWindow.savePathWildcard = sessionName + DateTime.UtcNow.ToString("yy-MM-dd-ss");
        recorderWindow.ChangeTakeNumber(0);
        yield return null;
    }
}
