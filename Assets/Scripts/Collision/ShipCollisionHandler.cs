using Cysharp.Threading.Tasks;
using UnityEngine;

public class ShipCollisionHandler : ICollisionHandler
{
    private readonly ICameraShake _cameraShake;
    private readonly IDamageText _damageText;
    private readonly IShipKnockback _shipKnockback;
    private readonly ILevelRestarter _levelRestarter;

    private readonly int _delayInMilliSeconds = 1000;
    private readonly int _damage = 10;

    private bool _isCollisionCooldown; //To prevent multiple collisions

    public ShipCollisionHandler(ICameraShake cameraShake, IDamageText damageText, IShipKnockback shipKnockback, ILevelRestarter levelRestarter)
    {
        _cameraShake = cameraShake;
        _damageText = damageText;
        _shipKnockback = shipKnockback;
        _levelRestarter = levelRestarter;
    }

    public async void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Asteroid _))
        {
            if (!_isCollisionCooldown)
            {
                HandleCollisionEffects(collision);
            }

            await SetCollisionCooldown();
        }

        if (collision.gameObject.TryGetComponent(out RestartObject _))
        {
            _levelRestarter.RestartLevel();
        }
    }

    private void HandleCollisionEffects(Collision collision)
    {
        _cameraShake.Shake();
        _shipKnockback.ApplyKnockback(collision);
        _damageText.ShowDamageText(_damage.ToString());
    }

    private async UniTask SetCollisionCooldown()
    {
        _isCollisionCooldown = true;
        await UniTask.Delay(_delayInMilliSeconds);
        _isCollisionCooldown = false;
    }
}
