using Cinemachine;
using UnityEngine;

public class CameraShake : ICameraShake
{
    private readonly CinemachineVirtualCamera _virtualCamera;

    private readonly float _shakeIntensity;
    private readonly float _shakeDuration;

    private float _shakeTimer;
    private float _shakeTimerTotal;
    private float _startingIntensity;

    public CameraShake(CinemachineVirtualCamera virtualCamera, float shakeIntensity, float shakeDuration)
    {
        _virtualCamera = virtualCamera;
        _shakeIntensity = shakeIntensity;
        _shakeDuration = shakeDuration;
    }

    public void Shake()
    {
        var multiChannel = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); //we need use MultiChannelPerlin,
                                                                                                         //because DOShake doesn't work with Cinemachine
        if (multiChannel == null) return;

        multiChannel.m_AmplitudeGain = _shakeIntensity;

        _startingIntensity = _shakeIntensity;
        _shakeTimerTotal = _shakeDuration;
        _shakeTimer = _shakeDuration;
    }

    public void UpdateShake()
    {
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;

            var multiChannel = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            if (multiChannel == null) return;

            multiChannel.m_AmplitudeGain = Mathf.Lerp(_startingIntensity, 0f, 1 - (_shakeTimer / _shakeTimerTotal));
        }
    }
}
