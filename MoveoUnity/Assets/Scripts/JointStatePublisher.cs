using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Sensor;
using System.Collections.Generic;

public class JointStatePub : MonoBehaviour
{
    public string rosTopic = "/joint_states";
    public string[] jointNames = new string[6]; // muszą pasować do nazw w URDF!
    public ArticulationBody[] jointArticulations = new ArticulationBody[6];
    public float publishRate = 30f;

    private ROSConnection ros;
    private float timeElapsed;

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<JointStateMsg>(rosTopic);
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > 1f / publishRate)
        {
            PublishJointStates();
            timeElapsed = 0;
        }
    }

    void PublishJointStates()
    {
        JointStateMsg jointState = new JointStateMsg();

        List<string> names = new List<string>();
        List<double> positions = new List<double>();

        for (int i = 0; i < jointArticulations.Length; i++)
        {
            names.Add(jointNames[i]);
            positions.Add(jointArticulations[i].jointPosition[0]); // radians
        }

        jointState.name = names.ToArray();
        jointState.position = positions.ToArray();

        jointState.header = new RosMessageTypes.Std.HeaderMsg
        {
            stamp = new RosMessageTypes.BuiltinInterfaces.TimeMsg
            {
                sec = (int)Time.timeSinceLevelLoad,
                nanosec = (uint)((Time.timeSinceLevelLoad - (int)Time.timeSinceLevelLoad) * 1e9)
            },
            frame_id = "base_link" // lub jakakolwiek twoja rama podstawowa
        };

        ros.Publish(rosTopic, jointState);
    }
}
