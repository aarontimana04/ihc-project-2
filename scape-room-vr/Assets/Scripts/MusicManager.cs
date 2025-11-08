using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource ambientSound;
    public AudioSource musicaFondo;
    public float tiempoAmbient = 30f; 
    public float tiempoMusicaFondo = 45f; 
    public float tiempoFade = 2f;

    void Start()
    {
        StartCoroutine(SecuenciaMusica());
    }

    IEnumerator SecuenciaMusica()
    {
        ambientSound.Play();
        musicaFondo.volume = 0f;

        yield return new WaitForSeconds(tiempoAmbient - tiempoFade);

        float volumenAmbient = ambientSound.volume;
        float volumenObjetivo = 0.4f;
        float tiempoTranscurrido = 0f;

        musicaFondo.Play();

        while (tiempoTranscurrido < tiempoFade)
        {
            float progreso = tiempoTranscurrido / tiempoFade;
            ambientSound.volume = Mathf.Lerp(volumenAmbient, 0, progreso);
            musicaFondo.volume = Mathf.Lerp(0, volumenObjetivo, progreso);

            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }

        ambientSound.Stop();
        ambientSound.volume = volumenAmbient;

        yield return new WaitForSeconds(tiempoMusicaFondo - tiempoFade);

        tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < tiempoFade)
        {
            float progreso = tiempoTranscurrido / tiempoFade;
            musicaFondo.volume = Mathf.Lerp(volumenObjetivo, 0, progreso);

            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }

        musicaFondo.Stop();
        musicaFondo.volume = volumenObjetivo;
    }
}