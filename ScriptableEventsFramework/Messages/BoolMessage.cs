using UnityEngine;

namespace Morganheim.ScriptableEvents
{
    [System.Serializable]
    public class BoolMessage : IGameEventMessage
    {
        [field: SerializeField] public bool BoolValue { get; private set; }

        public BoolMessage(bool boolValue)
        {
            BoolValue = boolValue;
        }
    }
}