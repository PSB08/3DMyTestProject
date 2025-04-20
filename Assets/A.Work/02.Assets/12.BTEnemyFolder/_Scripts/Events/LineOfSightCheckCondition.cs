using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Line of Sight check", story: "Check [Target] with Line Of Sight [detector]", category: "Conditions", id: "650c5664f31e9db4cc26b7286be14d89")]
public partial class LineOfSightCheckCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<LineOfSightDetector> Detector;

    public override bool IsTrue()
    {
        return Detector.Value.PerformDetection(Target.Value) != null;
    }

    
}
