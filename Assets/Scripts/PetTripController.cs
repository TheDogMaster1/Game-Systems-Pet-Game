using UnityEngine;
using UnityEngine.Events;

public class PetTripController : MonoBehaviour
{
    [SerializeField]
    private float timer = 0;
    private Animator animator;

    [SerializeField]
    private float timeToPass = 20;

    [SerializeField, Range(0, 100)]
    private int tripChance = 10;

    [SerializeField]
    private UnityEvent tripEvent;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator.GetFloat("Sadness") < 20) timer += Time.deltaTime;

        if (timer > timeToPass)
        {
            timer = 0;
            float tripNumber = Random.Range(1, 100);
            if (tripNumber <= tripChance)
            {
                Debug.Log("Tripped D:");
                tripEvent?.Invoke();
            }

        }
    }
}
