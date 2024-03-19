using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Morganheim.ScriptableEvents
{
    public class GameEventListener : MonoBehaviour
    {
        /**************************************** INSPECTOR VARIABLES ****************************************/
        [SerializeField] private List<EventListenerResponse> _eventResponses;

        /**************************************** UNITY CALLBACKS ****************************************/
        private void OnEnable()
        {
            for (int i = 0; i < _eventResponses.Count; i++)
                _eventResponses[i].ScriptableEvent.SubscribeListener(this);
        }

        private void OnDisable()
        {
            for (int i = 0; i < _eventResponses.Count; i++)
                _eventResponses[i].ScriptableEvent.UnsubscribeListener(this);
        }

        /**************************************** EVENT CALLBACKS ****************************************/
        public void OnEventEmitted(GameEvent sourceEvent, GameEventEmitter emitter, GameEventMessage message = null)
        {
            for (int i = 0; i < _eventResponses.Count; i++)
            {
                if (_eventResponses[i].ScriptableEvent != sourceEvent)
                    continue;

                _eventResponses[i].Invoke(message);
            }
        }
    }



    [System.Serializable]
    public struct EventListenerResponse
    {
        /**************************************** INSPECTOR VARIABLES ****************************************/
        [field: SerializeField] public GameEvent ScriptableEvent { get; private set; }
        [SerializeField] private List<UnityMessageEvent> _responseEvnets;

        /**************************************** PUBLIC METHODS ****************************************/
        public void Invoke(GameEventMessage message)
        {
            for (int i = 0; i < _responseEvnets.Count; i++)
                _responseEvnets[i].Invoke(message);
        }
    }



    [System.Serializable]
    public class UnityMessageEvent : UnityEvent<GameEventMessage> { }
}