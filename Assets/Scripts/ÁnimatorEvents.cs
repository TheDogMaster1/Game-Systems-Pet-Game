using UnityEngine;

public class ÁnimatorEvents : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetBoolTrue(string name)
    {
        _animator.SetBool(name, true);
    }

    public void SetBoolFalse(string name)
    {
        _animator.SetBool(name, false);
    }
}
