using UnityEngine;

namespace Morganheim.ScriptableEvents
{
    [System.Serializable]
    public class FloatMessage : GameEventMessage
    {
        [SerializeField] private float _floatValue;

        public float FloatValue { get => _floatValue; }

        public FloatMessage(float floatValue)
        {
            _floatValue = floatValue;
        }

        public FloatMessage(string eventName, float floatValue) : base(eventName)
        {
            _floatValue = floatValue;
        }
    }
}