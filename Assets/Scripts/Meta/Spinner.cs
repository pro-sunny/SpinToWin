using DG.Tweening;
using UnityEngine;
using Zenject;

public class Spinner : MonoBehaviour
{
    [SerializeField] private Transform _wheel;
    [SerializeField] private int _spins;
    [SerializeField] private float _randomSpeedMargin;
    [SerializeField] private float _duration;
    [SerializeField] private Ease _slowEase;

    [SerializeField] private ParticleSystem _coinsPS;
    [SerializeField] private ParticleSystem _wheelPS;
    
    private ISpinRewardGiver _spinRewardGiver;
    private ISpinnerSoundsHandler _spinnerSoundsHandler;

    [Inject]
    private void Construct(ISpinRewardGiver spinRewardGiver, ISpinnerSoundsHandler spinnerSoundsHandler)
    {
        _spinRewardGiver = spinRewardGiver;
        _spinnerSoundsHandler = spinnerSoundsHandler;
    }
    
    public void Spin()
    {
        // destinationAngle could be adjusted to define at what angle(cell) stop the wheel
        var destinationAngle = Random.Range(-_randomSpeedMargin, _randomSpeedMargin);
        var finalAngle = _spins * 360 + destinationAngle;
        
        _spinnerSoundsHandler.PlaySpinStartSound();
        
        var sequence = DOTween.Sequence();
        sequence.Append(
                _wheel.DORotate(new Vector3(0, 0, finalAngle), _duration, RotateMode.FastBeyond360)
                    .SetEase(_slowEase)
            )
            .AppendCallback(FireSpinningFinished);
    }

    private void FireSpinningFinished()
    {
        _coinsPS.Play();
        
        _spinnerSoundsHandler.PlaySpinFinishSound();
        
        _spinRewardGiver.GiveSpinReward();
        _wheelPS.Play();
    }
}
