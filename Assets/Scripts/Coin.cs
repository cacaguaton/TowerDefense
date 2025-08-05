using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private string _appeaAnimationName = "CoinAppear";
    [SerializeField]
    private string _dissappesrAnimationName = "CoinDisappear";
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _timeToDisappear;
    [SerializeField]
    private UnityEvent _onCoinCollected;
    private Collider _collider;

    void Awake()
    {
        _collider = GetComponent<Collider>();
    }
    void OnEnable()
    {

        _collider.enabled = true;
        StartCoroutine(AppearCoroutine());
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }
    public void Collect()
    {
        StartCoroutine(DisappearCoroutine());
        _onCoinCollected?.Invoke();
    }
    private IEnumerator AppearCoroutine()
    {
        _animator.Play(_appeaAnimationName);
        yield return new WaitForSeconds(_timeToDisappear);
        StartCoroutine(DisappearCoroutine());
    }
    private IEnumerator DisappearCoroutine()
    {
        _collider.enabled = false;
        _animator.Play(_dissappesrAnimationName);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
        
    }
}
