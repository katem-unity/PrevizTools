using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

//Adapted from SubtitleTrack example on unity forums

[TrackClipType(typeof(ShotData))]
[TrackBindingType(typeof(GameObject))]
public class ShotTrack : TrackAsset {
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount) {
        return ScriptPlayable<ShotMixer>.Create(graph, inputCount);
    }
}
