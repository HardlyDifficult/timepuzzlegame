using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRecorder : MonoBehaviour
{
    Config config;
    public List<Vector3> positions = new List<Vector3>();


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
}
