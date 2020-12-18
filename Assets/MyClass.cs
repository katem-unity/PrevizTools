  using UnityEngine;
  using UnityEngine.EventSystems;

  public class MyClass : MonoBehaviour, IPointerClickHandler {
  	
     public void OnPointerClick (PointerEventData eventData)
     {
     	//public GameObject Camera;

        Debug.Log ("clicked");
     }
  }