using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonBehaviour : MonoBehaviour
{

    private Button button;

    [SerializeField]
    private PetVariable petVariable;
    [SerializeField]
    private float numberStop;
    void Start()
    {
        button = GetComponent<Button>();
    }

    private void OnTrip()
    {
        button.interactable = false;
    }

    private void OnEnable()
    {
        PetTripController.onTrip += OnTrip;
    }

    private void OnDisable()
    {
        PetTripController.onTrip -= OnTrip;
    }
}
