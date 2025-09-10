using System;

[Serializable]
public class EnemyData
{
    public int Enemy;   // Tipo de enemigo
    public float Time;  // Tiempo en segundos en que aparece
}

[Serializable]
public class WaveData
{
    public int Wave;            // Número de oleada
    public EnemyData[] Enemies; // Enemigos de esta oleada
}

[Serializable]
public class RootData
{
    public WaveData[] Waves;    // Todas las oleadas
}
