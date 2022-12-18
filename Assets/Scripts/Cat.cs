using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Cat : MonoBehaviour
{
    [Header("Nav")] 
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private AgentLinkMover _linkMover;
    [Header("Animator")] 
    [SerializeField] private Animator _animator;
    [Header("UI")] 
    [SerializeField] private CatLike[] _catLikes;

    private CatState _catState;
    private Coroutine _catRandom;
    private Coroutine _likeCoroutine;
    
    public Animator Animator => _animator;
    public NavMeshAgent NavMeshAgent => _agent;

    public void Init()
    {
        _linkMover.OnJumpBegin += OnJumpBegin;
        _linkMover.OnJumpEnd += OnJumpEnd;
        _catRandom = StartCoroutine(RandomCat());
    }

    public void StopRandom()
    {
        _linkMover.OnJumpBegin -= OnJumpBegin;
        _linkMover.OnJumpEnd -= OnJumpEnd;
        StopCoroutine(_catRandom);
    }
    
    private void Update()
    {
        _animator.SetBool("IsWalking", _agent.velocity.magnitude > 0.01f);
    }

    private IEnumerator RandomCat()
    {
        Array values = Enum.GetValues(typeof(CatState));
        
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 60));
            _catState = (CatState) values.GetValue(Random.Range(0, values.Length));
            switch (_catState)
            {
                case CatState.Walking:
                    _agent.SetDestination(RandomNavmeshLocation(10));
                    break;
                case CatState.Sleep:
                    _animator.SetTrigger("Sleep");
                    break;
                case CatState.BeCute:
                    _animator.SetTrigger("BeCute" + Random.Range(1, 4));
                    break;
            }
        }
    }
    
    private Vector3 RandomNavmeshLocation(float radius) {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
            finalPosition = hit.position;            
        }
        return finalPosition;
    }

    private void OnJumpBegin()
    {
        _animator.SetTrigger("Jump");
    }

    private void OnJumpEnd()
    {
        _animator.SetTrigger("Land");
    }

    private void OnMouseDown()
    {
        _likeCoroutine ??= StartCoroutine(ShowLikes());
    }

    private IEnumerator ShowLikes()
    {
        Array.ForEach(_catLikes, c => c.gameObject.SetActive(true));
        yield return new WaitForSeconds(3);
        Array.ForEach(_catLikes, c => c.gameObject.SetActive(false));
        _likeCoroutine = null;
        GameController.Instance.HP += 25;
        GameController.Instance.Energy -= 5;
    }
}
