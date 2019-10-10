
using UnityEngine;


    [System.Serializable]
    public class Thing : MonoBehaviour
    {
        public ThingRuntimeSet RuntimeSet;

        private void OnEnable()
        {
            RuntimeSet.Add(this.transform);
        }

        private void OnDisable()
        {
            RuntimeSet.Remove(this.transform);
        }
    }
