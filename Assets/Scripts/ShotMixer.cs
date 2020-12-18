using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Playables;
using UnityEngine.UI;
//using UnityEngine.Formats.Alembic;
//using UnityEngine.Formats.Alembic.Importer;
//using UnityEngine.Formats.Alembic.Sdk;

//Adapted from SubtitleTrack example on unity forums

public class ShotMixer : PlayableBehaviour {

    //string previousLgt;
    //int courtesyFrame = 0;

    // Called each frame the mixer is active, after inputs are processed
    public override void ProcessFrame(Playable handle, FrameData info, object playerData) {
        var go = playerData as GameObject;
        if (playerData == null)
            return;

        string shot = string.Empty;
        
        var count = handle.GetInputCount();
        for (var i = 0; i < count; i++) {

            var inputHandle = handle.GetInput(i);
            var weight = handle.GetInputWeight(i);

            if (inputHandle.IsValid() && inputHandle.GetPlayState() == PlayState.Playing && weight > 0)
            {
                var data = ((ScriptPlayable<ShotDataPlayable>) inputHandle).GetBehaviour();
                if (data != null && weight == 1) {
                    shot = data.shot;
                }

            }
        }
        //previousLgt = go.GetComponent<LoadEnvironment>().LoadLgt(shot).name;
        go.GetComponent<LoadEnvironment>().LoadLgt(shot);
        /*
       if(shot != string.Empty && shot != previousLgt){

       		if(courtesyFrame < 1){
       			courtesyFrame ++;
       		} else {
            	previousLgt = go.GetComponent<LoadEnvironment>().LoadLgt(shot).name;
       			courtesyFrame = 0;
       		}
        }
        */

    }
}
