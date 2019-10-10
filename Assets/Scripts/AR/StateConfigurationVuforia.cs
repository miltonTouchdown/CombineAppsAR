using Vuforia;
using UnityEngine;

public class StateConfigurationVuforia : MonoBehaviour
{
    public bool IsTrackerPose = false;

    void Start()
    {
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(() => {
            SetPositionTrackerVuforia();
        });
    }

    /// <summary>
    /// Activar/Desactivar positional tracker
    /// </summary>
    private void SetPositionTrackerVuforia()
    {
        PositionalDeviceTracker pdt = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();

        if (pdt != null)
        {
            if (IsTrackerPose)
                pdt.Start();
            else
                pdt.Stop();
        }
    }
}
