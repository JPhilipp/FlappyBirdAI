using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class BirdAgent : Agent
{
    UniverseAcademy academy;
    Rigidbody body;
    Vector3 startPosition = Vector3.zero;

    const float jumpEnergyFull = 1f;
    float jumpEnergy = jumpEnergyFull;
    
    public override void InitializeAgent()
    {
        body = GetComponent<Rigidbody>();
        academy = FindObjectOfType( typeof(UniverseAcademy) ) as UniverseAcademy;
        startPosition = transform.position;

        ResetBody();
    }
    
    public override void CollectObservations()
    {
        AddVectorObs(body.velocity.y);
    }
    
    public override void AgentAction(float[] vectorAction, string textAction)
    {
        if (vectorAction[0] == 1 && jumpEnergy >= jumpEnergyFull)
        {
            const float force = 250f;
            body.AddForce(transform.up * force);
            jumpEnergy = 0f;
        }
        
        AddReward(0.001f);
        
        jumpEnergy = Mathf.Clamp(jumpEnergy + 0.05f, 0f, jumpEnergyFull);
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                Done();
                break;
            
            case "Ground":
            case "Ceiling":
                AddReward(-0.002f);
                break;
        }
    }
    
    public override void AgentReset()
    {
        academy.ResetEnvironment();
        ResetBody();
    }
    
    void ResetBody()
    {
        body.velocity      = Vector3.zero;
        transform.position = startPosition;
    }
}
