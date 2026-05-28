using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace Morganheim.ScriptableEvents
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private List<EventListenerResponse> _eventResponses;

        private readonly Dictionary<ScriptableGameEvent, EventListenerResponse> _responses = new();

        private void OnEnable()
        {
            _responses.Clear();

            for (int i = 0; i < _eventResponses.Count; i++)
            {
                _responses.TryAdd(_eventResponses[i].ScriptableEvent, _eventResponses[i]);
                _eventResponses[i].ScriptableEvent.SubscribeListener(this);
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < _eventResponses.Count; i++)
                _eventResponses[i].ScriptableEvent.UnsubscribeListener(this);

            _responses.Clear();
        }

        public void OnEventEmitted(ScriptableGameEvent sourceEvent, GameEventEmitter emitter, IGameEventMessage message = null)
        {
            if (_responses.TryGetValue(sourceEvent, out var response))
                response.Invoke(message);
        }
    }


    [Serializable]
    public struct EventListenerResponse
    {
        [SerializeField] private ScriptableGameEvent _scriptableEvent;
        [SerializeField] private UnityMessageEvent _responseEvnet;

        public readonly ScriptableGameEvent ScriptableEvent => _scriptableEvent;

        public readonly void Invoke(IGameEventMessage message)
        {
            _responseEvnet.Invoke(message);
        }
    }


    [Serializable]
    public class UnityMessageEvent : UnityEvent<IGameEventMessage> { }
}