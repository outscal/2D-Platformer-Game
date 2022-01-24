using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class FlickeringLight : MonoBehaviour {


    public delegate void MainLoop();

    public event MainLoop mainLoop;


    [Tooltip("This is how big the light is. Experiment with it.")]public float scale;
    [Tooltip("The moves (new targets for properties; intensity, range, position) your light will do per second.")]public float speed;

    [HideInInspector]public bool MakeSourceStationary;
    [HideInInspector]public float positionOffset;

    private Light light;

    private float intensityOrigin;
    private float intensityOffset;
    private float intensityDelta;
    private float rangeOrigin;
    private float rangeOffset;
    private float rangeTarget;
    private float rangeDelta;

    private Vector3 positionOrigin;
    private Vector3 positionDelta;

    private bool setNewTargets;


    private float deltaSum = 0;


    void Start ()
    {
        light = GetComponent<Light>();

        intensityOrigin = light.intensity;
        rangeOrigin = light.range;
        positionOrigin = transform.position;

        setNewTargets = true;

        scale *= 0.1f;
        speed *= 0.02f;

        intensityOffset = light.intensity * scale;
        rangeOffset = light.range * scale;
        positionOffset *= scale * 0.1f;

        mainLoop += IntensityAndRange;

        if (!MakeSourceStationary)
        {
            mainLoop += Position;
        }

    }





    private void IntensityAndRange()
    {

        if (setNewTargets) ////////////////SETTING INTENSITY TARGET IS ENOUGH, AS WE ONLY USE IT TO CHECK IF EVERY PROPERTY HAS REACHED THEIR TARGET. WE CAN DO THIS BECAUSE WE KNOW THEY ALL REACH THEIR TARGETS AT THE SAME TIME.//////
        {
            intensityDelta = (intensityOrigin + Random.Range(-intensityOffset, intensityOffset) - light.intensity) * speed;


            rangeTarget = rangeOrigin + Random.Range(-rangeOffset, rangeOffset);
            rangeDelta = (rangeTarget - light.range) * speed;

            setNewTargets = false;
        }

        light.intensity += intensityDelta;
        light.range += rangeDelta;


        if (Mathf.Abs(light.range - rangeTarget) < 5f * scale) //////// CHECK IF TARGET IS NEAR ENOUGH. /////////
            setNewTargets = true;


        

     }






    private void Position()
    {

        if (setNewTargets)
        {
            positionDelta = (positionOrigin + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * positionOffset - transform.position) * speed;
            
        }

        transform.position += positionDelta;
        

    }



    void Update()
    {

        if (deltaSum >= 0.02f)
        { 

            mainLoop();
            deltaSum -= 0.02f;

        }

        deltaSum += Time.deltaTime;
	}




}



#if UNITY_EDITOR

[CustomEditor(typeof(FlickeringLight))]
public class MyScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var flicker = target as FlickeringLight;

        flicker.MakeSourceStationary = GUILayout.Toggle(flicker.MakeSourceStationary, "Make Source Stationary");

      if (!flicker.MakeSourceStationary)
            flicker.positionOffset = EditorGUILayout.FloatField(new GUIContent("Position Offset Multiplier:", "Source's movement freedom. Increasing this value will increase shadow flickering. IF you don't want shadow flickering, check 'Make Source Stationary'."), flicker.positionOffset);

    }
}

#endif