using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRecorder : MonoBehaviour
{
    Config config;
    public List<Vector3> positions = new List<Vector3>();
    public Dictionary<int, bool> frameToInteract = new Dictionary<int, bool>();


    private void Start()
    {
        config = FindFirstObjectByType<Config>();
    }

    void FixedUpdate()
    {
        if (config.timeStep > 0)
        {
            if (positions.Count > config.currentFrame)
            {
                positions.RemoveRange(config.currentFrame, positions.Count - config.currentFrame);
            }

            var whoToRecord = FindFirstObjectByType<Character>();
            if (whoToRecord != null)
            {
                positions.Add(whoToRecord.transform.position);
            }
        }
    }

    void OnInteract()
    {
        frameToInteract.Add(config.currentFrame, true);
    }
}
