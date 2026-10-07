using UnityEngine;
using UnityEngine.Events;

public class BlinkController : MonoBehaviour
{
    [SerializeField]
    private float timer = 0;
    private Animator animator;

    [SerializeField]
    private float timeToPass = 20;

    private float initialTimeToPass = 20;

    [SerializeField, Range(0, 100)]
    private int BlinkChance = 10;

    [SerializeField]
    private UnityEvent blinkEvent;

    private bool sleeping = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        initialTimeToPass = timeToPass;
    }

    void Update()
    {
        if (animator.GetFloat("Sadness") < 20 && !sleeping) timer += Time.deltaTime;

        if (timer > timeToPass)
        {
            timer = 0;
            timeToPass = Random.Range(initialTimeToPass - 0.3f, initialTimeToPass + 0.3f);
            float tripNumber = Random.Range(1, 100);
            if (tripNumber <= BlinkChance)
            {
                Debug.Log("Blinked");
                blinkEvent?.Invoke();
            }

        }
    }
    public void ChangeIsSleeping(bool pBool)
    {
        sleeping = pBool;
    }

    private void OnEnable()
    {
        SleepAnimationBehaviour.OnSleep += ChangeIsSleeping;
    }

    private void OnDisable()
    {
        SleepAnimationBehaviour.OnSleep -= ChangeIsSleeping;
    }
}
