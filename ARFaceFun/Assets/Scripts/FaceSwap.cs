using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class FaceSwap : MonoBehaviour

{
  public List<Material> faceMaterials = new List<Material>();
  private ARFaceManager faceManager;
  private int randomNumber;
  private int lastNumber;
  private int faceMaterialIndex = 0;

  void Start()
  {
    faceManager = GetComponent<ARFaceManager>();
  }

  void NewRandomNumber()
  {
    randomNumber = Random.Range(0, faceMaterials.Count - 1);
    if (randomNumber == lastNumber)
    {
      randomNumber = Random.Range(0, faceMaterials.Count - 1);
    }
    lastNumber = randomNumber;
  }

  public void SwitchFace()
  {
    foreach (ARFace face in faceManager.trackables)
    {
      face.GetComponent<Renderer>().material = faceMaterials[randomNumber];
    }

    // faceMaterialIndex++;

    // if (faceMaterialIndex == faceMaterials.Count)
    // {
    //   faceMaterialIndex = 0;
    // }
  }

  public void SwitchFaceTo(int index)
  {
    foreach (ARFace face in faceManager.trackables)
    {
      face.GetComponent<Renderer>().material = faceMaterials[index];
    }
  }

  public void NoFilter()
  {
    foreach (ARFace face in faceManager.trackables)
    {
      face.GetComponent<Renderer>().materials = new Material[0];
    }
  }
}

