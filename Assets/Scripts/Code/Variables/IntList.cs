using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu]
public class IntList : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public List<int> Value = new List<int>();

}

