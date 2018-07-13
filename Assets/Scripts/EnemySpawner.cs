using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

  [System.Serializable]
  public struct EnemySpawn {
    public float Weight;
    public GameObject EnemyPrefab;
  }

  public EnemySpawn[] Spawns;
  public float SpawnTimer = 0.2f;

  float TotalWeight;
  float TimeSinceLastSpawn;

  /// <summary>
  /// Awake is called when the script instance is being loaded.
  /// </summary>
  void Awake() {
    TimeSinceLastSpawn = SpawnTimer;
    TotalWeight = Spawns.Where(s => s.EnemyPrefab != null).Sum(s => s.Weight);
  }

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update() {
    TimeSinceLastSpawn -= Time.deltaTime;
    if (TimeSinceLastSpawn < 0f) {
      SpawnEnemy();
      TimeSinceLastSpawn = SpawnTimer;
    }
  }

  void SpawnEnemy() {
    var selectWeight = Random.value * TotalWeight;
    foreach (var spawn in Spawns) {
      if (spawn.EnemyPrefab == null) continue;
      selectWeight -= spawn.Weight;
      if (selectWeight <= 0f) {
        Instantiate(spawn.EnemyPrefab, transform.position, transform.rotation);
        return;
      }
    }
  }

}
