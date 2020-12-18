using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Rendering.HighDefinition;

public class LoadEnvironment : MonoBehaviour
{
    public GameObject masterTimeline;
    public GameObject actorObject;

    [ExecuteAlways]
    public GameObject LoadLgt(string lgtSeq)
    {
        //string[] seqShot = lgtSeq.Split('_');

        string searchString = lgtSeq;

        FindObject(masterTimeline, searchString);

        //Move character to shot dolly



        /* Lighting Prefabs [Without 2020.2 this isn't really useful, need the ability to edit prefabs in context]
        if(loadedLgt){
            DestroyImmediate(loadedLgt);
        }
        if(loadedShotLgt){
            DestroyImmediate(loadedShotLgt);
        }
        GameObject lgtPrefab = Resources.Load("LGT_PREFAB/SEQ/LGT_" + seqShot[0] + "_000") as GameObject;
        GameObject lgtShotPrefab = Resources.Load("LGT_PREFAB/SHOT/LGT_" + lgtSeq) as GameObject;
        //If you want to do this in the Editor and want it to be an "instance" of the Prefab, you need to use PrefabUtility.InstantiatePrefab. Note that at runtime, Prefabs don't exist, they're nothing but serialised GameObjects.
        loadedLgt = PrefabUtility.InstantiatePrefab(lgtPrefab) as GameObject;
        if(lgtShotPrefab){
            loadedShotLgt = PrefabUtility.InstantiatePrefab(lgtShotPrefab) as GameObject;
        }
        */
        return null;
    }



    public void FindObject(GameObject po, string name)
    {
        //Find shot in masterTimeline
        foreach(Transform t in po.transform){
            if (t.name != "Timelines"){
                t.gameObject.SetActive(false);    
            }
            if(t.name == name){
                //Enable shot
                t.gameObject.SetActive(true);

                //Move character to shot dolly
                foreach(Transform tc in t.transform){
                    if(tc.gameObject.tag == "DollyCart"){
                        actorObject.transform.SetParent(tc);
                    }
                }

                //Clear local transforms on actor
                actorObject.transform.localPosition = new Vector3(0, 0, 0);
                actorObject.transform.localRotation = Quaternion.Euler(270, 0, 0);
            }
        }

    }
}