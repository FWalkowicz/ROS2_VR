using UnityEngine;
using UnityEngine.UI;

public class SingleJointSlider : MonoBehaviour
{
    [SerializeField] private Slider jointSlider;
    [SerializeField] private ArticulationBody joint;
    [SerializeField] private float minAngle = -90f;
    [SerializeField] private float maxAngle = 90f;

    void Start()
    {
        if (jointSlider == null || joint == null)
        {
            Debug.LogError("Brakuje slidera lub jointa!");
            return;
        }

        // Ustaw zakres slidera
        jointSlider.minValue = minAngle;
        jointSlider.maxValue = maxAngle;

        // Ustaw wartość początkową na aktualną pozycję jointa (w stopniach)
        jointSlider.value = joint.jointPosition[0] * Mathf.Rad2Deg;

        jointSlider.onValueChanged.AddListener(OnSliderChanged);
    }

    void OnSliderChanged(float value)
    {
        var drive = joint.xDrive;
        drive.target = value;
        joint.xDrive = drive;
    }
}
