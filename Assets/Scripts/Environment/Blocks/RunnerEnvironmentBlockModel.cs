using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class RunnerEnvironmentBlockModel : EnvironmentBlockModelBase
{
    [SerializeField] private EnvironmentBlockViewBase[] blockViews     = null;
    [SerializeField] private Transform                  itemsContainer = null;

    private ObstacleItemModel.Pool              obstaclesPool       = null;
    private CollectableItemModel.Pool           collectablesPool    = null;
    private EnvironmentItemsRandomizationConfig randomizationConfig = null;
    private EnvironmentBlockViewBase            currentView         = null;

    private List<ObstacleItemModel>    obstacles    = new List<ObstacleItemModel>();
    private List<CollectableItemModel> collectables = new List<CollectableItemModel>();

    public override float UpperEdgePosition => transform.localPosition.z + currentView.HalfLenght;


    [Inject]
    private void Construct(EnvironmentItemsRandomizationConfig randomizationConfig, ObstacleItemModel.Pool obstaclesPool, CollectableItemModel.Pool collectablesPool)
    {
        this.randomizationConfig = randomizationConfig;
        this.obstaclesPool       = obstaclesPool;
        this.collectablesPool    = collectablesPool;
    }

    public override void Init(Vector3 position, bool withoutItems = false)
    {
        InitRandomAvailableView();
        InitSelfPosition(position, true);

        if (!withoutItems)
            SpawnItems();
    }

    public override void Move(float movementSpeed)
    {
        transform.localPosition += new Vector3(0, 0, movementSpeed * Time.deltaTime);
    }

    public override void Deinit()
    {
        DeinitCurrentView();
        DespawnAllObstacles();
        DespawnAllCollectables();
    }


    private void InitRandomAvailableView()
    {
        if (blockViews == null || blockViews.Length == 0)
            throw new Exception($"{nameof(RunnerEnvironmentBlockModel)} {gameObject.name} doesn't have any view!");

        currentView = blockViews[Random.Range(0, blockViews.Length)];
        currentView.Init();
    }

    private void InitSelfPosition(Vector3 position, bool isPreviousEdgePosition)
    {
        transform.localPosition = isPreviousEdgePosition ? position + new Vector3(0, 0, currentView.HalfLenght) : position;
    }

    private void SpawnItems()
    {
        foreach (var pointsRow in currentView.SpawnPointsScheme.rows)
        {
            int pointWithObstacle = -1;

            if (Random.value <= randomizationConfig.obstaclePerRowChance)
                pointWithObstacle = SpawnObstacle(pointsRow.positions);

            SpawnCollectables(pointsRow.positions, pointWithObstacle);
        }
    }

    private int SpawnObstacle(Vector3[] positions)
    {
        int     cellIndex    = Random.Range(0, positions.Length);
        Vector3 cellPosition = positions[cellIndex];

        ObstacleItemModel obstacleItemModel = obstaclesPool.Spawn();
        obstacles.Add(obstacleItemModel);

        obstacleItemModel.transform.SetParent(itemsContainer);
        obstacleItemModel.transform.localPosition = cellPosition;

        return cellIndex;
    }

    private void SpawnCollectables(Vector3[] positions, int pointWithObstacle)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            if (i == pointWithObstacle)
                continue;

            if (Random.value > randomizationConfig.collectableChancePerCell)
                continue;

            CollectableItemModel collectableItem = collectablesPool.Spawn();
            collectables.Add(collectableItem);

            collectableItem.transform.SetParent(itemsContainer);
            collectableItem.transform.localPosition = positions[i];
        }
    }

    private void DeinitCurrentView()
    {
        currentView.Deinit();
    }

    private void DespawnAllObstacles()
    {
        foreach (ObstacleItemModel obstacle in obstacles)
            obstaclesPool.Despawn(obstacle);

        obstacles.Clear();
    }

    private void DespawnAllCollectables()
    {
        foreach (CollectableItemModel collectable in collectables)
            collectablesPool.Despawn(collectable);

        collectables.Clear();
    }
}