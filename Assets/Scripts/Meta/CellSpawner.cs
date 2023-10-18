using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    [SerializeField] private Transform _cellParent;
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private int _cellsAmount;

    private List<Cell> _cells = new ();

    private int _amountMargin = 1000;
    
    public void SpawnCell()
    {
        var rotationStep = 360f / _cellsAmount;
        for (int i = 0; i < _cellsAmount; i++)
        {
            var cell = Instantiate(_cellPrefab, _cellParent);

            var angle = rotationStep * i - rotationStep / 2f;
            cell.transform.Rotate(Vector3.forward, angle);
            if (i % 2 == 1)
            {
                cell.SetBlackTextColor();
            }

            var amount = GenerateAmount();
            cell.SetAmount(amount);
            
            _cells.Add(cell);
        }
    }

    private int GenerateAmount()
    {
        int minValue = 10;
        int maxValue = 1000;
        int amount = Random.Range(minValue, maxValue) * 100;

        if (_cells.Any(c => c.Amount == amount) || _cells.Any(c => Mathf.Abs(c.Amount - amount) < _amountMargin))
        {
            amount = GenerateAmount();
        }

        return amount;
    }
}

public interface ISpinRewardGiver
{
    public void GiveSpinReward();
}

public class GameBoardHandler : ISpinRewardGiver
{
    private List<Cell> _cells = new ();
    
    public void GiveSpinReward()
    {
        var amount = _cells.OrderBy(c => c.UpAngleDelta).First();
    }
}