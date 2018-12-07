using System.Collections.Generic;
using UnityEngine;

public class HurdleController : MonoBehaviour
{
    [SerializeField] private Hurdle hurdlePrefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField, Range(0, 5)] private float spawnIntervalTime;

    private List<Hurdle> hurdleList;
    private List<Hurdle> poolingList;
    private float coolTime;

    private void Awake()
    {
        hurdleList = new List<Hurdle>();
        poolingList = new List<Hurdle>();
        coolTime = 0.0f;
    }

    private void FixedUpdate()
    {
        if (coolTime <= 0.0f)
        {
            coolTime = spawnIntervalTime;
            var newHurdle = GetHurdle();
            newHurdle.transform.position = spawnPosition.position;
        }
        else
        {
            coolTime -= Time.fixedDeltaTime;
        }
    }

    private Hurdle GetHurdle()
    {
        if (poolingList.Count > 0)
        {
            poolingList[0].gameObject.SetActive(true);
            return poolingList[0];
        }
        else
        {
            return Instantiate(hurdlePrefab, this.transform) as Hurdle;
        }
    }
}
