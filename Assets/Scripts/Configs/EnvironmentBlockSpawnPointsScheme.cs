using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/EnvironmentBlockSpawnPointsScheme", fileName = "EnvironmentBlockSpawnPointsScheme", order = 0)]
public class EnvironmentBlockSpawnPointsScheme : ScriptableObject
{
    public PointsRow[] rows;

    [Serializable]
    public class PointsRow
    {
        public Vector3[] positions;
    }
}