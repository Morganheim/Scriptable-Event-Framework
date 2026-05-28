using UnityEngine;

namespace Morganheim.ScriptableEvents
{
    [System.Serializable]
    public class StringMessage : IGameEventMessage
    {
        [field: SerializeField] public string StringValue { get; private set; }

        public StringMessage(string stringValue)
        {
            StringValue = stringValue;
        }
    }
}