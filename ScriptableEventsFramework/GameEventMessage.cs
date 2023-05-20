using UnityEngine;

namespace ScriptableEventsFramework
{
    [System.Serializable]
    public class GameEventMessage
    {

    }

    [System.Serializable]
    public class StringGameEventMessage : GameEventMessage
    {
        private string _value;

        public string Value
        {
            get => _value;
        }

        public StringGameEventMessage(string val)
        {
            _value = val;
        }
    }

    [System.Serializable]
    public class FloatGameEventMessage : GameEventMessage
    {
        private float _value;

        public float Value
        {
            get => _value;
        }

        public FloatGameEventMessage(float val)
        {
            _value = val;
        }
    }
}
