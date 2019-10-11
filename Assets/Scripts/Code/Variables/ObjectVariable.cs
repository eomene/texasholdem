
using UnityEngine;


[CreateAssetMenu]
public class ObjectVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public GameObject Value;

    public void SetValue(GameObject value)
    {
        Value = value;
    }

    public void SetValue(ObjectVariable value)
    {
        Value = value.Value;
    }

}