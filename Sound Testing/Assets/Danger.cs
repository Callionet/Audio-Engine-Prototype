using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour {

    //base layer
    [SerializeField , Range(1.0f, 100.0f)]
    public float danger;

    //melody
    [SerializeField, Range(1.0f, 100.0f)]
    public float topLayer;

    //percusion layer
    [SerializeField, Range(1.0f, 100.0f)]
    public float percusion;

    //bool for attacked
    [SerializeField]
    public bool attacked;

    // Use this for initialization
    void Start (){

	}

    // Update is called once per frame
    void Update() {
        //send float as RTPC value to WWISE
        AkSoundEngine.SetRTPCValue("Top_Layers", topLayer);
        AkSoundEngine.SetRTPCValue("Percusive", percusion);
        AkSoundEngine.SetRTPCValue("Danger", danger);

        //switch string layer in WWISE on or off
        if (attacked) {AkSoundEngine.SetState("Combat", "Yes");}
        else {AkSoundEngine.SetState("Combat", "No");}

        /*if (checker != Attacked){
            checker = Attacked;
            if (checker) { AkSoundEngine.SetState("Combat", "Yes"); AkSoundEngine.SetState("Combat", "No"); }
        }*/
    }

    /*public bool Attacked {
        get { return attacked; }
        set{
            if (value == attacked) return;
            attacked = value;
            if (attacked) { AkSoundEngine.SetState("Combat", "Yes"); }
            else { AkSoundEngine.SetState("Combat", "No"); }
        }
    }*/

    /*public float TopLayer{
        get { return topLayer; }
        set {
            if (value == topLayer) return;
            AkSoundEngine.SetRTPCValue("Top_Layers", topLayer);
        }
    }*/
}
