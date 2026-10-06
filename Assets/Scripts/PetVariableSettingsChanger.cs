using UnityEngine;

public class PetVariableSettingsChanger : MonoBehaviour
{
    private PetVariable petVariable;

    [SerializeField]
    private string checkedVariableName;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private int intToCheck = 0;

    [SerializeField]
    private int newChangePerSecond = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        petVariable = GetComponent<PetVariable>();
    }
    void Update()
    {
        if (_animator.GetFloat(checkedVariableName) <= intToCheck)
        {
            petVariable.changePerSecond = newChangePerSecond;
        }
        else
        {
            petVariable.changePerSecond = 0;
        }
    }
}
