using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DetectTargets", story: "[Agent] detects [Target]", category: "Action", id: "59cd33ca7db33693cd54b29bf3eaed6b")]
public partial class DetectTargetsAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    private NavMeshAgent agent;
    private Sensor sensor;
    
    protected override Status OnStart()
    {
        agent = Agent.Value.GetComponent<NavMeshAgent>();
        sensor = Agent.Value.GetComponent<Sensor>();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        var target = sensor.GetClosestTarget("Targets");
        if (target == null) return Status.Running;
        
        Target.Value = target.gameObject;
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

