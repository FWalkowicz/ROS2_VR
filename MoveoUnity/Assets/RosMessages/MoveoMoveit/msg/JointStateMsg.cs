//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.MoveoMoveit
{
    [Serializable]
    public class JointStateMsg : Message
    {
        public const string k_RosMessageName = "moveo_moveit/JointState";
        public override string RosMessageName => k_RosMessageName;

        //  This is a message that holds data to describe the state of a set of torque controlled joints.
        // 
        //  The state of each joint (revolute or prismatic) is defined by:
        //   * the position of the joint (rad or m),
        //   * the velocity of the joint (rad/s or m/s) and
        //   * the effort that is applied in the joint (Nm or N).
        // 
        //  Each joint is uniquely identified by its name
        //  The header specifies the time at which the joint states were recorded. All the joint states
        //  in one message have to be recorded at the same time.
        // 
        //  This message consists of a multiple arrays, one for each part of the joint state.
        //  The goal is to make each of the fields optional. When e.g. your joints have no
        //  effort associated with them, you can leave the effort array empty.
        // 
        //  All arrays in this message should have the same size, or be empty.
        //  This is the only way to uniquely associate the joint name with the correct
        //  states.
        public Std.HeaderMsg header;
        public string[] name;
        public double[] position;
        public double[] velocity;
        public double[] effort;

        public JointStateMsg()
        {
            this.header = new Std.HeaderMsg();
            this.name = new string[0];
            this.position = new double[0];
            this.velocity = new double[0];
            this.effort = new double[0];
        }

        public JointStateMsg(Std.HeaderMsg header, string[] name, double[] position, double[] velocity, double[] effort)
        {
            this.header = header;
            this.name = name;
            this.position = position;
            this.velocity = velocity;
            this.effort = effort;
        }

        public static JointStateMsg Deserialize(MessageDeserializer deserializer) => new JointStateMsg(deserializer);

        private JointStateMsg(MessageDeserializer deserializer)
        {
            this.header = Std.HeaderMsg.Deserialize(deserializer);
            deserializer.Read(out this.name, deserializer.ReadLength());
            deserializer.Read(out this.position, sizeof(double), deserializer.ReadLength());
            deserializer.Read(out this.velocity, sizeof(double), deserializer.ReadLength());
            deserializer.Read(out this.effort, sizeof(double), deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.WriteLength(this.name);
            serializer.Write(this.name);
            serializer.WriteLength(this.position);
            serializer.Write(this.position);
            serializer.WriteLength(this.velocity);
            serializer.Write(this.velocity);
            serializer.WriteLength(this.effort);
            serializer.Write(this.effort);
        }

        public override string ToString()
        {
            return "JointStateMsg: " +
            "\nheader: " + header.ToString() +
            "\nname: " + System.String.Join(", ", name.ToList()) +
            "\nposition: " + System.String.Join(", ", position.ToList()) +
            "\nvelocity: " + System.String.Join(", ", velocity.ToList()) +
            "\neffort: " + System.String.Join(", ", effort.ToList());
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
