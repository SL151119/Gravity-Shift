using DG.Tweening;
using TMPro;
using UnityEngine;

public class DamageText : IDamageText
{
    private readonly TextMeshPro _textMeshPro;

    private readonly float _shakeAmount;
    private readonly float _shakeDuration;

    private GameObject TextObject => _textMeshPro.gameObject;

    public DamageText(float shakeAmount, float shakeDuration, TextMeshPro textMeshPro)
    {
        _shakeAmount = shakeAmount;
        _shakeDuration = shakeDuration;
        _textMeshPro = textMeshPro;

        TextObject.SetActive(false);
    }

    public void ShowDamageText(string text)
    {
        _textMeshPro.text = text;
        TextObject.SetActive(true);

        // Fly and shake animations
        var sequence = DOTween.Sequence();

        sequence
            .Join(TextObject.transform.DOShakePosition(_shakeDuration, _shakeAmount))
            .OnComplete
            ( 
                () => TextObject.SetActive(false)
            );
    }
}
