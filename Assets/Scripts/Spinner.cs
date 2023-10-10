using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private Transform _wheel;
    [SerializeField] private float _speed;
    [SerializeField] private float _duration;
    [SerializeField] private float _slowDuration;
    [SerializeField] private float _slowSpeed;

    private bool _isSpinning;
    private float _currentDuration;
    
    public void Spin()
    {
        _isSpinning = true;
        _currentDuration = _duration + _slowDuration;
    }

    private void Update()
    {
        if (!_isSpinning)
        {
            return;
        }

        if (_currentDuration < 0)
        {
            _isSpinning = false;
            return;
        }

        _currentDuration -= Time.deltaTime;

        var currentSpeed = _speed;
        if (_currentDuration < _duration)
        {
            currentSpeed -= _slowSpeed * Time.deltaTime;
        }
        
        _wheel.Rotate(Vector3.forward, currentSpeed * Time.deltaTime);
    }
}
