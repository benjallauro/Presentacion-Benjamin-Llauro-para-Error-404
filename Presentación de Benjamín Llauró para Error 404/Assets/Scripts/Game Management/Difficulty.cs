using UnityEngine;

namespace GameManagement
{
    [CreateAssetMenu(fileName = "Difficulty", menuName = "Scriptable/Difficulty")]
    public class Difficulty : ScriptableObject
    {
        public float minimumTimeBetweenSpawns;
        public float maximumTimeBetweenSpawns;
        public int minimumObjectsPerSpawn;
        public int maximumObjectsPerSpawn;
    }
}