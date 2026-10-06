using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PetTripController : MonoBehaviour
{

    public static event Action onTrip;

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
        if (animator.GetFloat("Sadness") < 20 && animator.GetFloat("Hunger") > 50) timer += Time.deltaTime;

        if (timer > timeToPass)
        {
            timer = 0;
            float tripNumber = Random.Range(1, 100);
            if (tripNumber <= tripChance)
            {
                PutPetOnGround();
                Debug.Log("Tripped D:");
                tripEvent?.Invoke();
                onTrip?.Invoke();
            }

        }
    }

    public void PutPetOnGround()
    {
        transform.position = new Vector3(transform.position.x, 0.6f, transform.position.z);
    }
}
