using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour {

  [Serializable]
  public struct WaveProbablity {
    public GameObject Prefab;
    public float Weight;
  }

  [Serializable]
  public struct WaveSpawn {
    public WaveProbablity[] Probabilties;
    public int MaxSpawnCount;
    public int Count;
    public float Time;
    public float PostSpawnWait;

    public float SpawnDiff => Time / MaxSpawnCount;

    public void Spawn(Vector2 spawn) {
      Object.Instantiate(SelectEntry().Prefab, spawn, Quaternion.identity);
    }

    WaveProbablity SelectEntry() {
      var totalWeight = 0f;
      foreach (var entry in Probabilties) {
        totalWeight += entry.Weight;
      }
      var selectWeight = Random.value * totalWeight;
      foreach (var entry in Probabilties) {
        selectWeight -=  entry.Weight;
        if (selectWeight <= 0) return entry;
      }
      return Probabilties[0];
    }
  }

  [Serializable]
  public struct WaveSegment {
    public WaveSpawn[] Spawns;
    public GameObject Source;
  }
  
  [Serializable]
  public struct Wave {
    public WaveSegment[] Segments;
  }

  public Wave CurrentWave;
  public WaveProbablity[] BaseProbabilities;
  GameObject[] Spawners;

  [Header("Generation Info")]
  public float PostWaveWaitTime = 15f;

  public float WaveCountMultiplier = 2;
  public float WaveCountError = 3;

  public float MaxSpawnScale = 0.25f;
  public float MaxSpawnError = 0.75f;

  public float CountScale = 5;
  public float CountError = 1.2f;

  public float SpawnTime = 1;
  public float PostSpawnWait = 5;
  
  public float WaveCountScaleFactor = 1f;

  /// <summary>
  /// Start is called on the frame when a script is enabled just before
  /// any of the Update methods is called the first time.
  /// </summary>
  void Start() { 
    Spawners = GameObject.FindGameObjectsWithTag("SpawnerSource");
    StartCoroutine(RunWaves(WaveCountScaleFactor));
  }

  IEnumerator RunWaves(float waveCountScaleFactor) {
    int waveCount = 1;
    while (true) {
      CurrentWave = GenerateNewWave(Mathf.FloorToInt(waveCount * waveCountScaleFactor));
      yield return RunWave(CurrentWave);
      Debug.Log($"Wave {waveCount} finished.");
      waveCount++;
      yield return new WaitForSeconds(PostWaveWaitTime);
    }
  }

  Wave GenerateNewWave(int waveCount) {
    var segments = new WaveSegment[Spawners.Length];
    for (var i = 0; i < segments.Length; i++) {
      segments[i] = GenerateWaveSegment(waveCount, Spawners[i]);
    }
    return new Wave { Segments = segments };
  }

  WaveSegment GenerateWaveSegment(int waveCount, GameObject source) {
    var count = Mathf.Max(0, Mathf.RoundToInt(GenerateScaleWithNoise(waveCount, WaveCountMultiplier, WaveCountError)));
    var spawns = new WaveSpawn[count];
    for (var i = 0; i < spawns.Length; i++) {
      // TODO(jmaes7132): Alter probabilties to become harder and harder
      spawns[i] = new WaveSpawn {
        Probabilties = BaseProbabilities,
        MaxSpawnCount = (int)Mathf.Max(GenerateScaleWithNoise(waveCount, MaxSpawnScale, MaxSpawnError), 1),
        Count = (int)Mathf.Max(GenerateScaleWithNoise(waveCount, CountScale, CountError), 1),
        Time = SpawnTime,
        PostSpawnWait = PostSpawnWait
      };
    }
    return new WaveSegment { Spawns = spawns, Source = source };
  }

  float GenerateScaleWithNoise(int baseValue, float scale, float error) {
    return baseValue * (scale + ((Random.value - 0.5f) * 2 * error));
  }

  IEnumerator RunWave(Wave wave, Action callback = null) {
    var routines = new Coroutine[wave.Segments.Length];
    for (var i = 0; i < routines.Length; i++) {
      routines[i] = StartCoroutine(RunWaveSegment(wave.Segments[i]));
    }
    foreach (var routine in routines) {
      yield return routines;
    }
    callback?.Invoke();
  }

  IEnumerator RunWaveSegment(WaveSegment segment) {
    var totalCount = 0;
    foreach (var spawn in segment.Spawns) {
      for (var i = 0; i < spawn.MaxSpawnCount; i++) {
        spawn.Spawn(segment.Source.transform.position);
        totalCount++;
        yield return new WaitForSeconds(spawn.SpawnDiff);
        if (totalCount > spawn.Count) break;
      }
      yield return new WaitForSeconds(spawn.PostSpawnWait);
    }
  }


}
