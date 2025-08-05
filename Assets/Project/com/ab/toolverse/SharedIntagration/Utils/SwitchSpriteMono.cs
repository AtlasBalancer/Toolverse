using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace com.ab.toolverse.shared.integration
{
    public class SwitchSpriteMono : MonoBehaviour
    {
        public float SwitchDelay;
        public SpriteRenderer[] Sprites;

        int globalThreadDebug;
        CancellationTokenSource _spriteSwitchCts;

        void OnEnable()
        {
            Cancel();
            RunSwitch().Forget();
        }

        void OnDisable() =>
            Cancel();

        async UniTaskVoid RunSwitch()
        {
            if (Sprites.Length < 1)
                return;

            if (Sprites.Length == 1)
            {
                Sprites.First().enabled = true;
                return;
            }

            int spriteCurrentIndex = 0;
            _spriteSwitchCts = new CancellationTokenSource();
            foreach (var sprite in Sprites) sprite.enabled = false;

            globalThreadDebug++;
            int threadDebug = globalThreadDebug;

            while (true)
            {
                var spriteLastIndex = GetLastIndex(spriteCurrentIndex);
                Sprites[spriteLastIndex].enabled = false;

                spriteCurrentIndex = (spriteCurrentIndex + 1) % Sprites.Length;
                Sprites[spriteCurrentIndex].enabled = true;

                Debug.Log($"th: {threadDebug}. Current: {spriteCurrentIndex}; Last: {spriteLastIndex};");

                await UniTask.Delay(
                    TimeSpan.FromSeconds(SwitchDelay),
                    DelayType.DeltaTime,
                    PlayerLoopTiming.FixedUpdate,
                    _spriteSwitchCts.Token);
            }
        }

        void Cancel()
        {
            if (_spriteSwitchCts != null)
            {
                _spriteSwitchCts.Cancel();
                _spriteSwitchCts = null;
            }
        }

        int GetLastIndex(int currentIndex)
        {
            var last = currentIndex % Sprites.Length;
            return last < 0 ? Sprites.Length - 1 : last;
        }
    }
}