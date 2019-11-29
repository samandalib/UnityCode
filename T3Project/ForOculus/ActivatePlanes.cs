using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlanes : MonoBehaviour{

  public GameObject Codeplanes;
  public GameObject CubeTrigger;
  public GameObject LightHole;
  public GameObject FPS;
  public GameObject PresentTimeObjects;
  public GameObject PastTimeObjects;

  public AudioSource source;

  public AudioClip HoleOpenSound;
  public AudioClip electricity;
  public AudioClip transitionsound;
  public AudioClip EdithPiaf;

  [SerializeField] private Animator TransitionAnimator;

  private void Start(){
    PresentTimeObjects.SetActive(true);
    PastTimeObjects.SetActive(false);
    LightHole.SetActive(false);
    Codeplanes.SetActive(false);
    FPS.GetComponent<Animator>().enabled = false;
  }

  private IEnumerator WaitSomeTime(){

    Debug.Log("IEnumerator Started");

    PlayElectricitySound();

    Codeplanes.SetActive (true);
    PresentTimeObjects.SetActive(false);
    PastTimeObjects.SetActive(true);
    CubeTrigger.SetActive(false);

    Debug.Log(" Befor waiting for LightHole Appears");

    yield return new WaitForSeconds(3);

    PlayHoleSound();
    yield return new WaitForSeconds(2);
    LightHole.SetActive(true);

    yield return new WaitForSeconds(2);
    PlayTransitionSound();
    FPS.GetComponent<Animator>().enabled =true;
    //yield return new WaitForSeconds(1);
    //FPS.GetComponent<Animator>().enabled =true;

    //Run Transition Animator
    TransitionAnimator.SetBool("TransTrigged", true);
    //PresentTimeObjects.SetActive(false);

    yield return new WaitForSeconds(20);
    PlayOldSong();
    //FPS.GetComponent<Animator>().enabled =false;
    Debug.Log("IEnumerator Ended");

  }


  private void PlayElectricitySound(){//Play an Electricity sound when the Player touches the phoen boot
    source.clip = electricity;
    source.Play();
  }

  private void PlayHoleSound(){//Play a sound to show where the transition is going to start
    source.clip = HoleOpenSound;
    source.Play();
  }

  private void PlayTransitionSound(){//Music for Transition state
    source.clip = transitionsound;
    source.Play();
  }

  private void PlayOldSong(){//Ambient Music for the old buidling
    source.clip = EdithPiaf;
    source.Play();
  }

  //When the Player enters the collider, trigger a set of actions in IEnumerator function
  void OnTriggerEnter(Collider other)
  {
      if (other.CompareTag ("Player"))
      {
        StartCoroutine(WaitSomeTime());

      }

  }
}
