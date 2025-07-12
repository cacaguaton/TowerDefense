using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private string _appearAnimationName = "CoinAppear";
    [SerializeField]
    private string _disapearAnimationName = "CoinDisappear";
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _timeToDisapper = 3f;
    [SerializeField]
    private UnityEvent _onCoinCollected;
    
    private Collider _collider;

    private void Awake()
    {

        _collider = GetComponent<Collider>();

    }

    private void OnEnable()
    {
        _collider.enabled = true;
        StartCoroutine(AooearCoroutine());
    }

    private void OnDisable()
    {

        StopAllCoroutines();

    }
    public void Collect()
    {
        StartCoroutine(DisappearCoroutine());
        _onCoinCollected?.Invoke();
    }

    private IEnumerator AooearCoroutine()
    {
        _animator.Play(_appearAnimationName);
        yield return new WaitForSeconds(_timeToDisapper);
        StartCoroutine(DisappearCoroutine());
    }
    private IEnumerator DisappearCoroutine()
    {
        _collider.enabled = false;
        _animator.Play(_disapearAnimationName);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
    }

}
