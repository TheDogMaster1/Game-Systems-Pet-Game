using UnityEngine;

public class AnimationSettings : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    //private void Update()
    //{
    //    if (!_animator.GetBool("Walking") && Mathf.Abs(transform.position.y - 0.6f) > 0.01)
    //    {
    //        transform.Translate(new Vector3(0, Mathf.Sign(transform.position.y - 0.6f) * -5f * Time.deltaTime, 0));
    //    }
    //}

    public void SetParameterToTrue(string parName)
    {
        if (!_animator.GetBool(parName)) _animator.SetBool(parName, true);
    }

    public void SetParameterToFalse(string parName)
    {
        if (_animator.GetBool(parName)) _animator.SetBool(parName, false);
    }

    public void SetRootMotionToTrue()
    {
        _animator.applyRootMotion = true;
    }
    public void SetRootMotionToFalse()
    {
        _animator.applyRootMotion = false;
    }

    public void SetObjectToInactive(string objectName)
    {
        GameObject obj = GameObject.Find(objectName);
        obj.SetActive(false);
    }
}
