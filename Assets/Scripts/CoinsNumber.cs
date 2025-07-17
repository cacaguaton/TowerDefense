using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class CoinsNumber : MonoBehaviour
{
    [SerializeField]
    private int _coins = 0;
    [SerializeField]
    private UnityEvent<int> _onCoinsUpdated;
    public void AddCoins(int amount)

    {
        _coins += amount;
        _onCoinsUpdated?.Invoke(_coins);
    }

    public void SetCoin(int amount)
    {
        _coins = amount;
        _onCoinsUpdated?.Invoke(_coins);
    }
        public void SubstractCoins(int amount)
    {
        _coins -= amount;
        _onCoinsUpdated?.Invoke(_coins);
    }
}
