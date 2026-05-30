using System.Collections.Generic;
using UnityEngine;

namespace Morganheim.ScriptableEvents
{
    public class GameEventEmitter : MonoBehaviour
    {
        [SerializeField] private EventEmitterResponse[] _emitterResponses;

        private readonly Dictionary<StringId, EventEmitterResponse> _responses = new();

        private void OnEnable()
        {
            _responses.Clear();

            for (int i = 0; i < _emitterResponses.Length; i++)
            {
                _responses.TryAdd(_emitterResponses[i].ResponseName, _emitterResponses[i]);
                _emitterResponses[i].SubscribeEmitter(this);
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < _emitterResponses.Length; i++)
                _emitterResponses[i].UnsubscribeEmitter(this);

            _responses.Clear();
        }

        public void EmitAll(IGameEventMessage message = null)
        {
            for (int i = 0; i < _emitterResponses.Length; i++)
                _emitterResponses[i].Emit(this, message);
        }

        public void Emit(string eventName, IGameEventMessage message = null)
        {
            if (!_responses.TryGetValue(eventName, out var response))
            {
                Debug.LogWarning($"Event \"{eventName}\" does not exist on this ({gameObject.name}) emitter.");
                return;
            }

            response.Emit(this, message);
        }
    }


    [System.Serializable]
    public struct EventEmitterResponse
    {
        [field: SerializeField] public string ResponseName { get; private set; }
        [SerializeField] private ScriptableGameEvent[] _scriptableEvents;

        public readonly void SubscribeEmitter(GameEventEmitter emitter)
        {
            for (int i = 0; i < _scriptableEvents.Length; i++)
                _scriptableEvents[i].SubscribeEmitter(emitter);
        }

        public readonly void UnsubscribeEmitter(GameEventEmitter emitter)
        {
            for (int i = 0; i < _scriptableEvents.Length; i++)
                _scriptableEvents[i].UnsubscribeEmitter(emitter);
        }

        public readonly void Emit(GameEventEmitter emitter, IGameEventMessage message)
        {
            for (int i = 0; i < _scriptableEvents.Length; i++)
                _scriptableEvents[i].Emit(emitter, message);
        }
    }
}