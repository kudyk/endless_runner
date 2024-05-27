using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RunnerEnvironmentTreadmill : EnvironmentTreadmillBase
{
    private EnvironmentBlockModelBase        lastBlock       = null;
    private RunnerEnvironmentTreadmillConfig treadmillConfig = null;
    private EnvironmentBlocksPool            blocksPool      = null;

    private readonly Queue<EnvironmentBlockModelBase> blocksQueue = new Queue<EnvironmentBlockModelBase>();


    [Inject]
    private void Construct(RunnerEnvironmentTreadmillConfig treadmillConfig, EnvironmentBlocksPool blocksPool)
    {
        this.treadmillConfig = treadmillConfig;
        this.blocksPool      = blocksPool;
    }

    public override void Init(int firstEmptyBlocks = 0)
    {
        SpawnNewBlocks(firstEmptyBlocks);
    }

    protected override void MoveAllElements(float movementSpeed)
    {
        foreach (EnvironmentBlockModelBase block in blocksQueue)
            block.Move(movementSpeed);
    }

    protected override void TryToDespawnOldElements()
    {
        if (blocksQueue.Count == 0)
            return;

        while (true)
        {
            EnvironmentBlockModelBase firstBlock = blocksQueue.Peek();

            float firstBlockEdgePosition = firstBlock.UpperEdgePosition;
            if (firstBlockEdgePosition > treadmillConfig.pointOfDispose)
                break;

            blocksPool.Despawn(firstBlock);
            blocksQueue.Dequeue();
        }
    }

    protected override void TryToSpawnNewElements()
    {
        bool hasAnyBlock = TryGetLastBlockEdgePosition(out float lastPosition);
        if (hasAnyBlock && lastPosition > treadmillConfig.pointOfGeneration)
            return;

        SpawnNewBlocks(0);
    }


    private void SpawnNewBlocks(int emptyBlocksCount)
    {
        while (true)
        {
            bool withoutItems = emptyBlocksCount > 0;

            lastBlock = blocksPool.Spawn(new Vector3(0, 0, GetLastBlockEdgePosition()), withoutItems);
            blocksQueue.Enqueue(lastBlock);

            if (lastBlock.UpperEdgePosition > treadmillConfig.pointOfGeneration)
                break;

            if (emptyBlocksCount != 0)
                emptyBlocksCount--;
        }

        float GetLastBlockEdgePosition()
        {
            if (!TryGetLastBlockEdgePosition(out float lastBlockEdgePosition))
                return treadmillConfig.zeroBlockEdgePoint;

            return lastBlockEdgePosition;
        }
    }

    private bool TryGetLastBlockEdgePosition(out float lastBlockPosition)
    {
        lastBlockPosition = float.MinValue;

        if (blocksQueue.Count == 0)
            return false;

        lastBlockPosition = lastBlock.UpperEdgePosition;
        return true;
    }
}