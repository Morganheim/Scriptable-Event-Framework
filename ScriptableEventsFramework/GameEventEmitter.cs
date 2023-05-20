using System.Collections.Generic;
using UnityEngine;

namespace ScriptableEventsFramework
{
    public class GameEventEmitter : MonoBehaviour
    {
        /**************************************** INSPECTOR VARIABLES ****************************************/
        [SerializeField] private List<EventEmitterResponse> _emitterResponses;

        /**************************************** UNITY CALLBACKS ****************************************/
        private void OnEnable()
        {
            for (int i = 0; i < _emitterResponses.Count; i++)
            {
                _emitterResponses[i].SubscribeEmitter(this);
            }
        }
        private void OnDisable()
        {
            for (int i = 0; i < _emitterResponses.Count; i++)
            {
                _emitterResponses[i].UnsubscribeEmitter(this);
            }
        }

        /**************************************** PUBLIC METHODS ****************************************/
        public void Emit(GameEventMessage message = null)
        {
            //Debug.Log($"Emitter {gameObject.name} emits event.");

            for (int i = 0; i < _emitterResponses.Count; i++)
            {
                _emitterResponses[i].Emit(this, message);
            }
        }
        public void Emit(string name, GameEventMessage message = null)
        {
            //Debug.Log($"Emitter {gameObject.name} emits event by name.");

            for (int i = 0; i < _emitterResponses.Count; i++)
            {
                _emitterResponses[i].Emit(name, this, message);
            }
        }
    }

    [System.Serializable]
    public struct EventEmitterResponse
    {
        /**************************************** INSPECTOR VARIABLES ****************************************/
        [SerializeField] private string _responseName;
        [SerializeField] private List<GameEvent> _scriptableEvents;

        /**************************************** PUBLIC METHODS ****************************************/
        public void SubscribeEmitter(GameEventEmitter emitter)
        {
            for (int i = 0; i < _scriptableEvents.Count; i++)
            {
                _scriptableEvents[i].SubscribeEmitter(emitter);
            }
        }
        public void UnsubscribeEmitter(GameEventEmitter emitter)
        {
            for (int i = 0; i < _scriptableEvents.Count; i++)
            {
                _scriptableEvents[i].UnsubscribeEmitter(emitter);
            }
        }
        public void Emit(GameEventEmitter emitter, GameEventMessage message)
        {
            for (int i = 0; i < _scriptableEvents.Count; i++)
            {
                _scriptableEvents[i].Emit(emitter, message);
            }
        }
        public void Emit(string eventName, GameEventEmitter emitter, GameEventMessage message)
        {
            for (int i = 0; i < _scriptableEvents.Count; i++)
            {
                if (_responseName != eventName)
                    continue;

                _scriptableEvents[i].Emit(emitter, message);
            }
        }
    }
}