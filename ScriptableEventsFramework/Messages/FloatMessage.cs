using UnityEngine;

namespace Morganheim.ScriptableEvents
{
    [System.Serializable]
    public class FloatMessage : IGameEventMessage
    {
        [field: SerializeField] public float FloatValue { get; private set; }

        public FloatMessage(float floatValue)
        {
            FloatValue = floatValue;
        }
    }
}