using UnityEngine;

namespace Morganheim.ScriptableEvents
{
    [System.Serializable]
    public class GameEventMessage
    {
        [SerializeField] private string _eventName;

        public string EventName { get => _eventName; }

        public GameEventMessage()
        {

        }

        public GameEventMessage(string eventName)
        {
            _eventName = eventName;
        }
    }
}
