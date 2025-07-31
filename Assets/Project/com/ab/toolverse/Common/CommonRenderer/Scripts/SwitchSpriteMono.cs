using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SwitchSpriteMono : MonoBehaviour
{
    public float SwitchDelay;
    public SpriteRenderer[] Sprites;

    int _spriteCurrentIndex;

    void Start()
    {
        if (Sprites.Length < 1)
            return;

        if (Sprites.Length == 1)
        {
            Sprites.First().enabled = true;
            return;
        }

        RunSwitch().Forget();
    }

    async UniTaskVoid RunSwitch()
    {
        foreach (var sprite in Sprites) sprite.enabled = false;

        while (true)
        {
            var _spriteLastIndex = GetLastIndex();
            Sprites[_spriteCurrentIndex].enabled = false;
            
            var sprite = Sprites[_spriteCurrentIndex];
            _spriteCurrentIndex = (_spriteCurrentIndex + 1) % Sprites.Length;
            Sprites[_spriteCurrentIndex].enabled = true;
            
            await UniTask.Delay(
                TimeSpan.FromSeconds(SwitchDelay),
                DelayType.DeltaTime,
                PlayerLoopTiming.FixedUpdate,
                this.GetCancellationTokenOnDestroy());
        }
    }

    int GetLastIndex()
    {
        var last = _spriteCurrentIndex % Sprites.Length - 1;
        return last < 0 ? Sprites.Length : last;
    }
}