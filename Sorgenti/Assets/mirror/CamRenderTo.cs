using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CamRenderTo : MonoBehaviour {
	
	Texture2D texture;
	public Material AppliedTo;
	
	//Turn this on to automatically set depth
	public bool autoDepth;
	
	void Start () {
		camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(new Vector3 (1,1,1));
		if(autoDepth && camera != Camera.main)
			camera.depth=Camera.main.depth+1;
		texture = new Texture2D(Mathf.RoundToInt(Screen.width), Mathf.RoundToInt(Screen.height), TextureFormat.ARGB32, false);
		
	}
	
	//Called after current camera has rendered
	void OnPostRender () {
		texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
		texture = FlipTexture (texture);
		texture.Apply();
		AppliedTo.mainTexture=texture;
		
	}

	Texture2D FlipTexture(Texture2D original){
		Texture2D flipped = new Texture2D(original.width,original.height);
		
		int xN = original.width;
		int yN = original.height;
		
		
		for(int i=0;i<xN;i++){
			for(int j=0;j<yN;j++){
				flipped.SetPixel(xN-i-1, j, original.GetPixel(i,j));
			}
		}
		flipped.Apply();
		
		return flipped;
	}
}