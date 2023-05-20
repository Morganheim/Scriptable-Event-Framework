using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEventsFramework
{
    public class GameEventListener : MonoBehaviour
    {
        /**************************************** INSPECTOR VARIABLES ****************************************/
        [SerializeField] private List<EventListenerResponse> _eventResponses;

        /**************************************** UNITY CALLBACKS ****************************************/
        private void OnEnable()
        {
            for (int i = 0; i < _eventResponses.Count; i++)
            {
                _eventResponses[i].ScriptableEvent.SubscribeListener(this);
            }
        }
        private void OnDisable()
        {
            for (int i = 0; i < _eventResponses.Count; i++)
            {
                _eventResponses[i].ScriptableEvent.UnsubscribeListener(this);
            }
        }

        /**************************************** EVENT CALLBACKS ****************************************/
        public void OnEventEmitted(GameEvent sourceEvent, GameEventEmitter emitter, GameEventMessage message = null)
        {
            //Debug.Log($"Event from {emitter.gameObject.name} received.");
            //Debug.Log($"Message received. -> {message == null}");
            for (int i = 0; i < _eventResponses.Count; i++)
            {
                _eventResponses[i].Invoke(sourceEvent, message);
            }
        }
    }

    [System.Serializable]
    public struct EventListenerResponse
    {
        /**************************************** INSPECTOR VARIABLES ****************************************/
        [SerializeField] private GameEvent _scriptableEvent;
        [SerializeField] private List<UnityMessageEvent> _responseEvnets;

        /**************************************** PROPERTIES ****************************************/
        public GameEvent ScriptableEvent
        {
            get => _scriptableEvent;
        }

        /**************************************** PUBLIC METHODS ****************************************/
        public void Invoke(GameEvent sourceEvent, GameEventMessage message)
        {
            for (int i = 0; i < _responseEvnets.Count; i++)
            {
                if (_scriptableEvent != sourceEvent)
                    continue;

                _responseEvnets[i].Invoke(message);
            }
        }
    }

    [System.Serializable]
    public class UnityMessageEvent : UnityEvent<GameEventMessage> { }
}