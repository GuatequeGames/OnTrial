using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingBox : MonoBehaviour
{
    [SerializeField] private Transform nextPosition;
    [SerializeField] private float speed;


    private void Start()
    {
        StartCoroutine(GoToNextPosition());
    }
    public void SetNextPosition(Transform _position)
    {
        nextPosition = _position;
    }

    IEnumerator GoToNextPosition()
    {

        Vector3 posToGo = new Vector3(nextPosition.position.x, transform.position.y, nextPosition.position.z);
        float distance = Vector3.Distance(posToGo, transform.position);
        float time = distance * 1.0f / speed;
        transform.DOMove(posToGo, time).SetEase(Ease.Linear);
        yield return new WaitForSeconds(time);

        StartCoroutine(GoToNextPosition());
    }
}
