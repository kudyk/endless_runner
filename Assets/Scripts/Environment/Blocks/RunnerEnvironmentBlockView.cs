using UnityEngine;

public class RunnerEnvironmentBlockView : EnvironmentBlockViewBase
{
    [SerializeField] private float                             halfLenght             = 10.0f;
    [SerializeField] private EnvironmentBlockSpawnPointsScheme blockSpawnPointsScheme = null;

    public override float                             HalfLenght        => halfLenght;
    public override EnvironmentBlockSpawnPointsScheme SpawnPointsScheme => blockSpawnPointsScheme;


    public override void Init()
    {
        gameObject.SetActive(true);
    }

    public override void Deinit()
    {
        gameObject.SetActive(false);
    }
}