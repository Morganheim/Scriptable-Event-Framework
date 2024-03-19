using System.Collections.Generic;
using UnityEngine;

namespace Morganheim.ScriptableEvents
{
    public class GameEventEmitter : MonoBehaviour
    {
        /**************************************** INSPECTOR VARIABLES ****************************************/
        [SerializeField] private List<EventEmitterResponse> _emitterResponses;

        /**************************************** UNITY CALLBACKS ****************************************/
        private void OnEnable()
        {
            for (int i = 0; i < _emitterResponses.Count; i++)
                _emitterResponses[i].SubscribeEmitter(this);
        }

        private void OnDisable()
        {
            for (int i = 0; i < _emitterResponses.Count; i++)
                _emitterResponses[i].UnsubscribeEmitter(this);
        }

        /**************************************** PUBLIC METHODS ****************************************/
        public void EmitAll(GameEventMessage message = null)
        {
            for (int i = 0; i < _emitterResponses.Count; i++)
                _emitterResponses[i].Emit(this, message);
        }

        public void Emit(GameEventMessage message)
        {
            for (int i = 0; i < _emitterResponses.Count; i++)
            {
                if (_emitterResponses[i].ResponseName != message.EventName)
                    continue;

                _emitterResponses[i].Emit(this, message);
            }
        }

        public void Emit(string name, GameEventMessage message = null)
        {
            for (int i = 0; i < _emitterResponses.Count; i++)
            {
                if (_emitterResponses[i].ResponseName != name)
                    continue;

                _emitterResponses[i].Emit(this, message);
            }
        }
    }



    [System.Serializable]
    public struct EventEmitterResponse
    {
        /**************************************** INSPECTOR VARIABLES ****************************************/
        [field: SerializeField] public string ResponseName { get; private set; }
        [SerializeField] private List<GameEvent> _scriptableEvents;

        /**************************************** PUBLIC METHODS ****************************************/
        public void SubscribeEmitter(GameEventEmitter emitter)
        {
            for (int i = 0; i < _scriptableEvents.Count; i++)
                _scriptableEvents[i].SubscribeEmitter(emitter);
        }

        public void UnsubscribeEmitter(GameEventEmitter emitter)
        {
            for (int i = 0; i < _scriptableEvents.Count; i++)
                _scriptableEvents[i].UnsubscribeEmitter(emitter);
        }

        public void Emit(GameEventEmitter emitter, GameEventMessage message)
        {
            for (int i = 0; i < _scriptableEvents.Count; i++)
                _scriptableEvents[i].Emit(emitter, message);
        }
    }
}