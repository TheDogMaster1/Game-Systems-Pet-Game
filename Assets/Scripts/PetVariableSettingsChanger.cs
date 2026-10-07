using UnityEngine;

public class PetVariableSettingsChanger : MonoBehaviour
{
    private PetVariable petVariable;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private string parameter;

    public enum AnimationState { sleep, sulk }

    public AnimationState state;

    [SerializeField]
    private int newChangePerSecond = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        petVariable = GetComponent<PetVariable>();
    }

    private void Update()
    {
        if (_animator == null) return;
        if (_animator.GetFloat(parameter) <= 5)
        {
            ChangePerSecond(false);
        }
        else
        {
            ChangePerSecond(true);
        }
    }

    private void ChangePerSecond(bool pBool)
    {
        if (!pBool)
        {
            petVariable.changePerSecond = newChangePerSecond;
        }
        else
        {
            petVariable.changePerSecond = 0;
        }
    }

    private void OnEnable()
    {
        if (state == AnimationState.sleep)
        {
            SleepAnimationBehaviour.OnSleep += ChangePerSecond;
        }
    }
    private void OnDisable()
    {
        if (state == AnimationState.sleep)
        {
            SleepAnimationBehaviour.OnSleep -= ChangePerSecond;
        }
    }
}
