using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private GameObject sahnedekiKadın;
    [SerializeField] private GameObject yeniKadın;
    [SerializeField] private Animator   polisAnimator;
    [SerializeField] private GameObject konusma1yanlis;
    [SerializeField] private GameObject konusma1dogru;
    [SerializeField] private GameObject konusma2yanlis;
    [SerializeField] private GameObject konusma2dogru;
    [SerializeField] private GameObject konusma3yanlis;
    [SerializeField] private GameObject konusma3dogru;
    [SerializeField] private GameObject adamkonusma1;
    [SerializeField] private GameObject adamkonusma2;

    [SerializeField] private Color buttonPressetColor;
    [SerializeField] private float ilkSoruGelmedenÖnceBeklenenSüre = 1f;
    [SerializeField] private float buttonaBasmadanÖnceBeklenenSüre = 3f;
    [SerializeField] private float buttonBasılıDuracağıSüre = 0.5f;
    [SerializeField] private float buttonagittiktenSonraAdamınCevabıGeleneKadarOlanSüre = 0.5f;
    [SerializeField] private float adamınKonuşmasınınDuracağıSüre = 2f;
    [SerializeField] private float adamınKonuşmasıGittiktenSonraSonrakiSorununGelmeSüresi = 1;
    
    [Header("Slider")] 
    public Slider slider;
    public Image fill;
    [SerializeField] private int currentValue = 0;
    [SerializeField] private int maxValue = 100;
    [SerializeField] private GameObject winCanvas;


    [SerializeField] private GameObject particlePrefabTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dialog());
        StartCoroutine(SliderValue(true));
    }


    private void Update()
    {
       
    }

    private IEnumerator Dialog()
    {
        yield return new WaitForSeconds(ilkSoruGelmedenÖnceBeklenenSüre);
        konusma1dogru.SetActive(true);
        konusma1yanlis.SetActive(true);

        yield return new WaitForSeconds(buttonaBasmadanÖnceBeklenenSüre);
        konusma1dogru.GetComponent<Image>().DOColor(buttonPressetColor, buttonBasılıDuracağıSüre/4);
        yield return new WaitForSeconds(buttonBasılıDuracağıSüre);
        
        konusma1dogru.SetActive(false);
        konusma1yanlis.SetActive(false);
        UpdateSlider();
        
        yield return new WaitForSeconds(buttonagittiktenSonraAdamınCevabıGeleneKadarOlanSüre);
        
        adamkonusma1.SetActive(true);
        yield return new WaitForSeconds(adamınKonuşmasınınDuracağıSüre);
        adamkonusma1.SetActive(false);

        yield return new WaitForSeconds(adamınKonuşmasıGittiktenSonraSonrakiSorununGelmeSüresi);
        

        
        
        konusma2dogru.SetActive(true);
        konusma2yanlis.SetActive(true);

        yield return new WaitForSeconds(buttonaBasmadanÖnceBeklenenSüre);
        konusma2dogru.GetComponent<Image>().DOColor(buttonPressetColor, buttonBasılıDuracağıSüre);
        yield return new WaitForSeconds(buttonBasılıDuracağıSüre);
        
        konusma2dogru.SetActive(false);
        konusma2yanlis.SetActive(false);
        UpdateSlider();
        
        yield return new WaitForSeconds(buttonagittiktenSonraAdamınCevabıGeleneKadarOlanSüre);
        
        adamkonusma2.SetActive(true);
        yield return new WaitForSeconds(adamınKonuşmasınınDuracağıSüre);
        adamkonusma2.SetActive(false);

        yield return new WaitForSeconds(adamınKonuşmasıGittiktenSonraSonrakiSorununGelmeSüresi);
        
        
        
        konusma3dogru.SetActive(true);
        konusma3yanlis.SetActive(true);

        yield return new WaitForSeconds(buttonaBasmadanÖnceBeklenenSüre);
        konusma3dogru.GetComponent<Image>().DOColor(buttonPressetColor, buttonBasılıDuracağıSüre);
        yield return new WaitForSeconds(buttonBasılıDuracağıSüre);
        
        konusma3dogru.SetActive(false);
        konusma3yanlis.SetActive(false);
        UpdateSlider();

        yield return new WaitForSeconds(buttonaBasmadanÖnceBeklenenSüre);

        Instantiate(particlePrefab,particlePrefabTarget.transform.position, Quaternion.identity);
        yeniKadın.SetActive(true);
        polisAnimator.SetBool("sapiklas", true);
        Destroy(sahnedekiKadın);



        yield return new WaitForSeconds(4);

        winCanvas.SetActive(true);
    }
    
    private IEnumerator SliderValue(bool isIncreasing)
    {
        while (isIncreasing && currentValue <= maxValue || !isIncreasing && currentValue > 0)
        {
            if (isIncreasing && currentValue <= maxValue)
            {
                yield return new WaitForSeconds(0.2f);
                currentValue++;
                UpdateSlider();
            }
            else if(!isIncreasing && currentValue > 0)
            {
                yield return new WaitForSeconds(0.2f);
                currentValue--;
                UpdateSlider();
            }
        }   
    }
    private void UpdateSlider()
    {
        slider.maxValue = maxValue;
        slider.value = currentValue;
        fill.fillAmount = slider.value;
    }
}
