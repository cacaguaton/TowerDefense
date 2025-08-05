using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuyGun : MonoBehaviour
{
    [SerializeField]
    private int _gunCost = 100;
    [SerializeField]
    private InstantiatePoolObject _gunPoolObject;
    [SerializeField]
    private CoinsNumber _coinsNumber;
    [SerializeField]
    private UnityEvent<Transform> _OnGunPurchased;
    [SerializeField]
    private Text _costText;
    void Start()
    {
        _costText.text = _gunCost.ToString();
    }

    public void TryBuyGun()
    {
        if (_coinsNumber.BuyObject(_gunCost))
        {
            _gunPoolObject.InstantiateObject(transform);
            GameObject gun = _gunPoolObject.GetCurrentObject();
            _OnGunPurchased?.Invoke(gun.transform);
        }
    }
}
