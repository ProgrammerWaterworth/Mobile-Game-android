using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Deactivates level parts when trigger collider detects objects with tag "LevelPart" and component "LevelPart"
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class LevelPartDeactivator : MonoBehaviour
{
    LevelManager levelManager;

    private void Start()
    {
        Collider2D _collider = GetComponent<Collider2D>();
        if (_collider != null) _collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        LevelPart _part = collision.GetComponent<LevelPart>();

        if (_part != null)
        {
            _part.DisableAsset();
            levelManager.SpawnLevelPart(true);
        }

        Fruit _fruit = collision.GetComponent<Fruit>();

        if (_fruit != null)
        {
            _fruit.DisableAsset();
        }
    }

    public void SetLevelManager(LevelManager _manager)
    {
        levelManager = _manager;
    }
}
