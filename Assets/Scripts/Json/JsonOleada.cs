using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class JsonOleada : MonoBehaviour
{
    [Header("Configuración")]
    public string jsonUrl = "https://kev-games-development.net/Services/WavesTest.json";

    [Header("Prefabs de enemigos (indexados por ID del JSON)")]
    public GameObject[] enemyPrefabs; 

    [Header("Posición de spawn")]
    public Transform [] spawnPoint;

    private RootData wavesData;

    void Start()
    {
        StartCoroutine(LoadWaves());
    }

    IEnumerator LoadWaves()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(jsonUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error al cargar JSON: " + www.error);
            }
            else
            {
                string jsonText = www.downloadHandler.text;
                wavesData = JsonUtility.FromJson<RootData>(jsonText);

                StartCoroutine(RunWaves());
            }
        }
    }

    IEnumerator RunWaves()
    {
        foreach (var wave in wavesData.Waves)
        {
            Debug.Log($"Iniciando Oleada {wave.Wave}");

            foreach (var enemy in wave.Enemies)
            {
                yield return new WaitForSeconds(enemy.Time);

                SpawnEnemy(enemy.Enemy);
            }

            Debug.Log($"Oleada {wave.Wave} terminada ✅");

            yield return new WaitForSeconds(2f);
        }

        Debug.Log("🎉 Todas las oleadas completadas");
    }

    void SpawnEnemy(int enemyType)
    {
        int index = enemyType - 1;

        if (index >= 0 && index < enemyPrefabs.Length && spawnPoint.Length > 0)
        {
            // Selecciona un punto de spawn aleatorio
            int spawnIndex = Random.Range(0, spawnPoint.Length);
            Instantiate(enemyPrefabs[index], spawnPoint[spawnIndex].position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning($"No hay prefab asignado para el enemigo tipo {enemyType} o no hay puntos de spawn.");
        }
    }
}
