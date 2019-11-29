using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPhone : MonoBehaviour
{
    public GameObject PhoneRingTrigger;
    public GameObject TransitionTrigger;
    public AudioSource source;

    public AudioClip PhoneRingSound;


    private void Start(){
      //TransitionTrigger.GetComponent<BoxCollider>().enabled = false;

    }

    private IEnumerator WaitSomeTime(){
      Debug.Log("Waiting Time Started!");
      yield return new WaitForSeconds(2);
      Debug.Log("Before Ring");
      PlayRingSound();
      yield return new WaitForSeconds(1);
      Debug.Log("Before PickUp");

      //TransitionTrigger.GetComponent<BoxCollider>().enabled =true;

      PhoneRingTrigger.GetComponent<BoxCollider>().enabled = false;
      PhoneRingTrigger.GetComponent<MeshRenderer>().enabled = false;

    }
    private void PlayRingSound(){
      source.clip = PhoneRingSound;
      source.Play();
    }

    private void OnTriggerEnter(Collider other){
      if (other.CompareTag("Player"))
      {
        Debug.Log("PhoneRingTrigger Started");
        StartCoroutine(WaitSomeTime());
        Debug.Log("Wait time for Phone ring passed");
      }
    }
}
