using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class UniverseAcademy : Academy
{
    public Transform wallSetPrefab;
    public Transform wallsWrapper;
    
    public override void InitializeAcademy()
    {
        ResetEnvironment();
    }
    
    public override void AcademyReset()
    {
        ResetEnvironment();
    }
    
    public void ResetEnvironment()
    {
        DestroyWallSets();

        const int wallCount = 10;
        const float distanceBetweenWalls = 25f;
        
        for (int i = 0; i < wallCount; i++)
        {
            Transform wall = Instantiate(wallSetPrefab);
            wall.parent = wallsWrapper;
            
            Vector3 position = wall.localPosition;
            position.z = -(i + 1) * distanceBetweenWalls;
            wall.localPosition = position;
        }
    }
    
    void DestroyWallSets()
    {
        GameObject[] wallSets = GameObject.FindGameObjectsWithTag("WallSet");
        for (int i = 0; i < wallSets.Length; i++)
        {
            Destroy(wallSets[i]);
        }
    }
}
