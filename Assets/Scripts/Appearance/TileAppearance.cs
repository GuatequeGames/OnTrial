using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TileAppearance : MonoBehaviour
{
    [SerializeField] private Transform inferiorTile;
    [SerializeField] private Vector3 inferiorTileOriginalPos;
    [SerializeField] private float timeToAppear;
    [SerializeField] private int NCreatorsOnArea;
    [SerializeField] private List<string> tagsToActivate;


    bool moving;
    private void Start()
    {
        inferiorTileOriginalPos = inferiorTile.position;
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Collision");
        TileCreator tileCreator = other.GetComponent<TileCreator>();
        if (tileCreator == null || !tileCreator.isActiveAndEnabled) return;

        NCreatorsOnArea++;
        inferiorTile.gameObject.SetActive(true);
        inferiorTile.DOMove(transform.position, timeToAppear).SetEase(Ease.OutCubic).SetId("Move");

    }

    IEnumerator Appear()
    {
        inferiorTile.gameObject.SetActive(true);
        inferiorTile.DOMove(transform.position, timeToAppear).SetEase(Ease.OutCubic).SetId("Move");
        yield return new WaitForSeconds(timeToAppear);

    }

    void CheckPosition()
    {
        if(NCreatorsOnArea <= 0 )
        {
            inferiorTile.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        TileCreator tileCreator = other.GetComponent<TileCreator>();
        if (tileCreator == null) return;

        NCreatorsOnArea--;
        if (NCreatorsOnArea > 0) return;
        inferiorTile.DOMove(inferiorTileOriginalPos, timeToAppear).SetEase(Ease.InCubic).OnComplete(CheckPosition);

    }



}