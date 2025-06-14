//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Moveit
{
    [Serializable]
    public class LocalPlannerGoal : Message
    {
        public const string k_RosMessageName = "moveit_msgs/LocalPlanner";
        public override string RosMessageName => k_RosMessageName;

        //  Local constraints to apply when following the target trajectory produced by the GlobalPlanner
        public ConstraintsMsg[] local_constraints;

        public LocalPlannerGoal()
        {
            this.local_constraints = new ConstraintsMsg[0];
        }

        public LocalPlannerGoal(ConstraintsMsg[] local_constraints)
        {
            this.local_constraints = local_constraints;
        }

        public static LocalPlannerGoal Deserialize(MessageDeserializer deserializer) => new LocalPlannerGoal(deserializer);

        private LocalPlannerGoal(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.local_constraints, ConstraintsMsg.Deserialize, deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.WriteLength(this.local_constraints);
            serializer.Write(this.local_constraints);
        }

        public override string ToString()
        {
            return "LocalPlannerGoal: " +
            "\nlocal_constraints: " + System.String.Join(", ", local_constraints.ToList());
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Goal);
        }
    }
}
