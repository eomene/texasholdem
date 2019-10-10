using UnityEngine;


    [CreateAssetMenu]
    public class GameObjectList : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public GameObject[] Value;

    }
