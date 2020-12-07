using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public float[] position;
    public int level;
    public int health;

    public Data(GameManager manager)
    {
        level = manager.currentLevel;
        health = manager.health;
        position = new float[3];

        position[0] = manager.lastCheckpointPos.x;
        position[1] = manager.lastCheckpointPos.y;
        position[2] = manager.lastCheckpointPos.z;
    }
}
