using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CreateObj : MonoBehaviour {

	public Image PP;
	public Sprite[] temp;
	public GameObject parent;
	public Color[] colorList;
	public int colorNo ;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < temp.Length; i++) {
			var createImage = Instantiate(PP) as Image;
			createImage.transform.SetParent(parent.transform, false);
			createImage.color = colorList [colorNo];
			createImage.gameObject.SetActive (true);
			Image tempNew = createImage.GetComponentsInChildren<Image>()[1];
			tempNew.sprite = temp [i];
			createImage.gameObject.name = temp [i].name;

//			string localPath = "Assets/UI button pack 3/Button round color "+(colorNo+1).ToString()+"/"+ createImage.gameObject.name + ".prefab";
//
//			CreateNew(createImage.gameObject, localPath);
		}
	}

//	void Start () {
//		for (int i = 0; i < temp.Length; i++) {
//			var createImage = Instantiate(PP) as Image;
//			createImage.transform.SetParent(parent.transform, false);
//			createImage.gameObject.SetActive (true);
//			createImage.sprite = temp [i];
//			createImage.gameObject.name = temp [i].name;
//		}
//	}

	static void CreateNew(GameObject obj, string localPath)
	{
		//Create a new prefab at the path given
		Object prefab = PrefabUtility.CreatePrefab(localPath, obj);
		PrefabUtility.ReplacePrefab(obj, prefab, ReplacePrefabOptions.ConnectToPrefab);
	}
	

}
