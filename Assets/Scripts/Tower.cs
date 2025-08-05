 using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onInitalize;
    [SerializeField]
    private UnityEvent _onHidden;
    public void Initialize()
    {
        _onInitalize?.Invoke();
    }
}
