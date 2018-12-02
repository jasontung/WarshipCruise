using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour {
    public ICommand[] commands;
    public bool executeByManual;

    private void Start()
    {
        Setup();
        if(!executeByManual)
            Execute();
    }

    public void Setup()
    {
        foreach (var cmd in commands)
        {
            cmd.Setup();
        }
    }

    [ContextMenu("Execute")]
	public void Execute()
    {
        StartCoroutine(ProcessCmd());
    }

    private IEnumerator ProcessCmd()
    {
        foreach (var cmd in commands)
        {
            yield return cmd.Execute();
        }
        Debug.LogWarning("[CommandManager] Finish All Commands");
    }
}
