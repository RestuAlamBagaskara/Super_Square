using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    // public AudioClip audioBenar;
    // private AudioSource mediaPlayerBenar;
    public AudioSource ButtonSound;
    public string namaScene;
    public void PindahLayar(){
        AudioSource buttonSound = ButtonSound.GetComponent<AudioSource>();
        buttonSound.PlayOneShot(buttonSound.clip);

        Scene sceneIni = SceneManager.GetActiveScene();

        if (sceneIni.name != namaScene){
            SceneManager.LoadScene (namaScene);
            // mediaPlayerBenar.Play();
        }
    }

    public void pindahScene(string namaScene){
        // AudioSource buttonSound = ButtonSound.GetComponent<AudioSource>();
        // buttonSound.PlayOneShot(buttonSound.clip);
            SceneManager.LoadScene (namaScene);
    }

    public void Keluar(){
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        // mediaPlayerBenar = gameObject.GetComponent<AudioSource>();
        // mediaPlayerBenar.clip = audioBenar;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
