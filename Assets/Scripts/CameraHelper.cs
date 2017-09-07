using UnityEngine;

public static class CameraHelper
{
  public static byte[] CaptureFrame(Camera camera)
  {
		if ( camera == null )
		{
			Debug.Log ( "null camera" );
			return new byte[0];
		}
    RenderTexture targetTexture = camera.targetTexture;
    RenderTexture.active = targetTexture;
	Texture2D texture2D = new Texture2D(targetTexture.width, targetTexture.height, TextureFormat.RGB24, false);
	texture2D.ReadPixels(new Rect(0, 0, targetTexture.width, targetTexture.height), 0, 0);
    texture2D.Apply();
	byte[] image = texture2D.EncodeToJPG();
	Object.DestroyImmediate(texture2D); // Required to prevent leaking the texture
    return image;
  }
  
  public static byte[] CaptureDepthFrame(Camera camera)
  {
		if ( camera == null )
		{
			Debug.Log ( "null camera" );
			return new byte[0];
		}
    RenderTexture targetTexture = camera.targetTexture;
    RenderTexture.active = targetTexture;
	  Texture2D texture2D = new Texture2D(targetTexture.width, targetTexture.height, TextureFormat.ARGB32, false);
    texture2D.ReadPixels(new Rect(0, 0, targetTexture.width, targetTexture.height), 0, 0);
    texture2D.Apply();
    // Debug
    //Debug.Log("Values at 10,10: " + texture2D.GetPixel(10,10));

	  byte[] image = texture2D.EncodeToPNG();
	  Object.DestroyImmediate(texture2D); // Required to prevent leaking the texture
    return image;
  }
}
