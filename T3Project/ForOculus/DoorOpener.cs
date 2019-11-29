using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour{

  public AudioSource AudioSource;
  [SerializeField] private AudioClip DoorOpenSound;
  [SerializeField] private AudioClip DoorCloseSound;

  [SerializeField] private Animator DoorAnimator;



  private IEnumerator WaitSomeTime(){

    PlayDoorOpenSound();
    yield return new WaitForSeconds(5.5f);
    PlayDoorCloseSound();
    Debug.Log("DoorOpener Trigger Finished");

  }

  private void PlayDoorOpenSound(){
    AudioSource.clip = DoorOpenSound;
    AudioSource.Play();
  }
  private void PlayDoorCloseSound(){
    AudioSource.clip = DoorCloseSound;
    AudioSource.Play();
  }

  private void OnTriggerEnter(Collider other){
    if (other.CompareTag("Player"))
    {
      Debug.Log("DoorOpener Trigger activated");
      DoorAnimator.SetBool("isOpen", true);
      StartCoroutine(WaitSomeTime());
    }
  }

  private void OnTriggerExit(Collider other){
    if (other.CompareTag("Player"))
    {
      DoorAnimator.SetBool("isOpen",false);
    }
  }

}
