using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPhone : MonoBehaviour
{
    public GameObject PhoneRingTrigger;
    public GameObject TransitionTrigger;
    public GameObject BlackBox;
    public AudioSource source;

    public AudioClip PhoneRingSound;
    public AudioClip PersonOnPhone;
    public AudioClip PickUpSound;
    public AudioClip BusyTone;

    private void Start(){
      TransitionTrigger.GetComponent<BoxCollider>().enabled = false;
      BlackBox.SetActive(false);

    }

    private IEnumerator WaitSomeTime(){
      Debug.Log("Waiting Time Started!");
      yield return new WaitForSeconds(10);
      Debug.Log("Before Ring");
      PlayRingSound();
      yield return new WaitForSeconds(4);
      Debug.Log("Before PickUp");
      PlayPhonePickUpSound();
      BlackBox.SetActive(true);
      yield return new WaitForSeconds(2);
      Debug.Log("Before VoiceOnPhone");
      PlayPersonOnPhone();
      yield return new WaitForSeconds(10);
      Debug.Log("Before BusyTone");
      PlayBusyTone();
      yield return new WaitForSeconds(6);

      TransitionTrigger.GetComponent<BoxCollider>().enabled =true;
      BlackBox.SetActive(false);

      PhoneRingTrigger.GetComponent<BoxCollider>().enabled = false;
      PhoneRingTrigger.GetComponent<MeshRenderer>().enabled = false;

    }


    private void PlayRingSound(){
      source.clip = PhoneRingSound;
      source.Play();
    }

    private void PlayPhonePickUpSound(){
      source.clip = PickUpSound;
      source.Play();
    }

    private void PlayPersonOnPhone(){
      source.clip = PersonOnPhone;
      source.Play();
    }

    private void PlayBusyTone(){
      source.clip = BusyTone;
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
