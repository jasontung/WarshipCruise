using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICommand : ScriptableObject
{
    public virtual void Setup() { }
    public abstract IEnumerator Execute();
}
