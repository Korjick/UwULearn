using System;
using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private Cat _cat;

    private Coroutine _foodCoroutine;
    
    private void OnMouseDown()
    {
        _foodCoroutine ??= StartCoroutine(FoodCoroutine());
    }

    private IEnumerator FoodCoroutine()
    {
        _cat.StopRandom();
        _cat.NavMeshAgent.SetDestination(transform.position);
        yield return new WaitUntil(() => Vector3.Distance(transform.position, _cat.transform.position) < 1f);
        _cat.Animator.SetTrigger("Drink");
        yield return new WaitForSeconds(3f);
        _cat.Init();
        _foodCoroutine = null;
        GameController.Instance.Food += 25;
        GameController.Instance.Energy -= 5;
    }
}