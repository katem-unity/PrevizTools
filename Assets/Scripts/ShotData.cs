using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Collections.Generic;

//Adapted from SubtitleTrack example on unity forums

[Serializable]
public class ShotDataPlayable : PlayableBehaviour {
    //public string set = "SET_corridorA";
    public string shot = "run_020";
}


[Serializable]
public class ShotData : PlayableAsset, ITimelineClipAsset {

    public ShotDataPlayable shotData = new ShotDataPlayable();



    // Create the runtime version of the clip, by creating a copy of the template
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go) {
        return ScriptPlayable<ShotDataPlayable>.Create(graph, shotData);
    }

    // Use this to tell the Timeline Editor what features this clip supports
    public ClipCaps clipCaps {
        get { return ClipCaps.Blending | ClipCaps.Extrapolation; }
    }
}
