using UnityEngine;

namespace Morganheim.ScriptableEvents
{
    [System.Serializable]
    public class BoolMessage : GameEventMessage
    {
        [SerializeField] private bool _boolValue;

        public bool BoolValue { get => _boolValue; }

        public BoolMessage(bool boolValue)
        {
            _boolValue = boolValue;
        }

        public BoolMessage(string eventName, bool boolValue) : base(eventName)
        {
            _boolValue = boolValue;
        }
    }
}