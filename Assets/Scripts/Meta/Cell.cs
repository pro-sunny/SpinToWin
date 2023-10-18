using DG.Tweening;
using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private TMP_Text _caption;
    [SerializeField] private Color _flashColor;
    [SerializeField] private float _flashDuration;
    
    public int Amount { get; private set; }

    public float UpAngleDelta
    {
        get
        {
            var angle = transform.rotation.eulerAngles.z;
            angle = angle > 180 ? 360 - angle : angle;
            return angle;
        }
    }

    public void SetAmount(int amount)
    {
        Amount = amount;
        _caption.text = amount.ToString();
    }
    
    public void SetBlackTextColor()
    {
        _caption.color = Color.black;
    }

    public void FlashText()
    {
        var initColor = _caption.color;
        var inColorTween = _caption.DOColor(_flashColor, _flashDuration);
        var outColorTween = _caption.DOColor(initColor, _flashDuration);
        
        var sequence = DOTween.Sequence();
        sequence.Append(inColorTween).Append(outColorTween)
            .Append(inColorTween).Append(outColorTween)
            .Append(inColorTween).Append(outColorTween);
    }
}
