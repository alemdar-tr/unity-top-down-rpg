using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

[IncludeInSettings(true)]
public static class XScriptMachine
{ 
    public static void InstantiateMachine(GameObject target, ScriptGraphAsset macro)
    {
        target.AddComponent<ScriptMachine>().nest.SwitchToMacro(macro);
    }

}