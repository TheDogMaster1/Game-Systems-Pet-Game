using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonBehaviour : MonoBehaviour
{
    private Button button;
    public enum ButtonBehaviours { feedButton, soothButton, wakeButton };

    [SerializeField]
    private ButtonBehaviours buttonBehaviours = ButtonBehaviours.feedButton;
    [SerializeField]
    private PetVariable sadness;

    private float timer;

    void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void SwitchButtonInteraction(bool pBool)
    {
        button.interactable = !button.interactable;
    }

    private void TurnButtonOff()
    {
        button.interactable = false;
    }

    public void LowerSadness()
    {
        if (timer >= 10)
        {
            sadness.ChangeValue(-10);
            timer = 0;
        }
    }

    private void OnEnable()
    {
        switch (buttonBehaviours)
        {
            case ButtonBehaviours.feedButton:
                SleepAnimationBehaviour.OnSleep += SwitchButtonInteraction;
                PetTripController.onTrip += TurnButtonOff;
                break;
            case ButtonBehaviours.soothButton:
                SleepAnimationBehaviour.OnSleep += SwitchButtonInteraction;
                break;
            case ButtonBehaviours.wakeButton:
                SleepAnimationBehaviour.OnSleep += SwitchButtonInteraction;
                break;
        }
    }

    private void OnDisable()
    {
        switch (buttonBehaviours)
        {
            case ButtonBehaviours.feedButton:
                SleepAnimationBehaviour.OnSleep -= SwitchButtonInteraction;
                PetTripController.onTrip -= TurnButtonOff;
                break;
            case ButtonBehaviours.soothButton:
                SleepAnimationBehaviour.OnSleep -= SwitchButtonInteraction;
                break;
            case ButtonBehaviours.wakeButton:
                SleepAnimationBehaviour.OnSleep -= SwitchButtonInteraction;
                break;
        }
    }
}
