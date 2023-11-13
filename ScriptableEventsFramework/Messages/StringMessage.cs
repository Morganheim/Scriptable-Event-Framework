using UnityEngine;

namespace Morganheim.ScriptableEvents
{
    [System.Serializable]
    public class StringMessage : GameEventMessage
    {
        [SerializeField] private string _stringValue;

        public string StringValue { get => _stringValue; }

        public StringMessage(string stringValue)
        {
            _stringValue = stringValue;
        }

        public StringMessage(string eventName, string stringValue) : base(eventName)
        {
            _stringValue = stringValue;
        }
    }
}