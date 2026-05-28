using UnityEngine;

namespace Morganheim.ScriptableEvents
{
    [System.Serializable]
    public class IntMessage : IGameEventMessage
    {
        [field: SerializeField] public int IntValue { get; private set; }

        public StringMessage(int intValue)
        {
            IntValue = intValue;
        }
    }
}