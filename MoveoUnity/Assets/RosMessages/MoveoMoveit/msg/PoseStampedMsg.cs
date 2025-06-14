//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.MoveoMoveit
{
    [Serializable]
    public class PoseStampedMsg : Message
    {
        public const string k_RosMessageName = "moveo_moveit/PoseStamped";
        public override string RosMessageName => k_RosMessageName;

        //  A Pose with reference coordinate frame and timestamp
        public Std.HeaderMsg header;
        public PoseMsg pose;

        public PoseStampedMsg()
        {
            this.header = new Std.HeaderMsg();
            this.pose = new PoseMsg();
        }

        public PoseStampedMsg(Std.HeaderMsg header, PoseMsg pose)
        {
            this.header = header;
            this.pose = pose;
        }

        public static PoseStampedMsg Deserialize(MessageDeserializer deserializer) => new PoseStampedMsg(deserializer);

        private PoseStampedMsg(MessageDeserializer deserializer)
        {
            this.header = Std.HeaderMsg.Deserialize(deserializer);
            this.pose = PoseMsg.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.pose);
        }

        public override string ToString()
        {
            return "PoseStampedMsg: " +
            "\nheader: " + header.ToString() +
            "\npose: " + pose.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
