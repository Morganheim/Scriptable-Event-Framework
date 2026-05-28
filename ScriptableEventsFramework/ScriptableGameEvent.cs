using System.Collections.Generic;
using UnityEngine;

namespace Morganheim.ScriptableEvents
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Scriptable Events/Game Event")]
    public class ScriptableGameEvent : ScriptableObject
    {
        private readonly HashSet<GameEventEmitter> _emitters = new();
        private readonly HashSet<GameEventListener> _listeners = new();

        public void SubscribeEmitter(GameEventEmitter emitter)
        {
            if (emitter == null || _emitters.Contains(emitter))
                return;

            _emitters.Add(emitter);
        }

        public void UnsubscribeEmitter(GameEventEmitter emitter)
        {
            if (!_emitters.Contains(emitter))
                return;

            _emitters.Remove(emitter);
        }

        public void SubscribeListener(GameEventListener listener)
        {
            if (listener == null || _listeners.Contains(listener))
                return;

            _listeners.Add(listener);
        }

        public void UnsubscribeListener(GameEventListener listener)
        {
            if (!_listeners.Contains(listener))
                return;

            _listeners.Remove(listener);
        }

        public void Emit(GameEventEmitter emitter, IGameEventMessage message = null)
        {
            if (emitter == null)
                return;

            foreach (var listener in _listeners)
                listener.OnEventEmitted(this, emitter, message);
        }
    }
}