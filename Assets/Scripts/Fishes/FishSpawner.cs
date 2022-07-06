using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private Fish _fishPrefab;
    [SerializeField] private int _cost;
    [SerializeField] private int _fishCount;
    [SerializeField] private List<Fish> _fishList = new List<Fish>();
    [SerializeField] private bool _isBuyed;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] float _spawnRadius;
    [SerializeField] int _spawnTime;

    private Coroutine _coroutine;

    private void Start()
    {
        StartCircleSpawn(); 
    }

    private bool CheckFishCount()
    {
        for (int i = 0; i < _fishList.Count; i++)
        {
            if (_fishList[i] == null)
            {
                _fishList.RemoveAt(i);
            }
        }

        return _fishList.Count >= _fishCount ? true : false;
    }

    private IEnumerator CircleSpawn()
    {
        var waitThreeSeconds = new WaitForSeconds(_spawnTime);

        while(CheckFishCount() == false)
        {
            Fish prefab = Instantiate(_fishPrefab,GetRandomPoint(),Quaternion.identity,_spawnPoint.transform);

            prefab.transform.position = new Vector3(prefab.transform.position.x,_spawnPoint.transform.position.y ,prefab.transform.position.z);

            prefab.SetSpawner(this);

            _fishList.Add(prefab);

            yield return waitThreeSeconds;
        }
        yield break;
    }

    public void StartCircleSpawn()
    {
        _coroutine = StartCoroutine(CircleSpawn());
    }

    public Vector3 GetRandomPoint()
    {
        return new Vector3(_spawnPoint.position.x + Random.insideUnitSphere.x * _spawnRadius,_spawnPoint.position.y, _spawnPoint.localPosition.z + Random.insideUnitSphere.z * _spawnRadius);
    }
}
