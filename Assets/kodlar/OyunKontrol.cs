using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OyunKontrol : MonoBehaviour
{
    public GameObject Asteroid;
    public Vector3 randomPos;
    public float baslangıcBekleme;
    public float olusturmaBekleme;
    public float donguBekleme;
    public Text text;
    bool oyunBittiKontrol = false;
    bool yenidenBaslaKontrol = false;


    int score;
    void Start()
    {
        
        score = 0;
        text.text = "score=" + score;
        StartCoroutine (olustur()); 
    }
    void update()
    {
        if (Input.GetKeyDown(KeyCode.R) && yenidenBaslaKontrol)
        {
            Debug.Log("+++");
        }
    }
    IEnumerator olustur()
    {
        yield return new WaitForSeconds(baslangıcBekleme);
        while (true)
        {
            for (int i = 0; i < 10; i++)//10 meteor olusturduktan sonra beklemesı ıcın yazılan metod
            {
                Vector3 vec = new Vector3 (Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(Asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(olusturmaBekleme);
            }
            yield return new WaitForSeconds(donguBekleme);


            if (oyunBittiKontrol)
            {
                yenidenBaslaKontrol = true;
                break;
            }
        }


    }
    public void ScoreArttir(int gelenScore)
    {
        score += gelenScore;
        text.text = "score=" + score;
        Debug.Log(score);
    }
    public void oyunBitti()
    {
        Debug.Log("OYUN BİTTİ");
        oyunBittiKontrol = true;
    }
}
