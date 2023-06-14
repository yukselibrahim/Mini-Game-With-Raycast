using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast1 : MonoBehaviour
{
    //NOT: �stedi�imiz noktaya bir ���n g�ndererek o ���n�n herhangi bir objeye �arp�p �arpmamas�n� kontrol edebilmemizi sa�lar RAYCAST.



    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        int layerMask = 1 << 6; //Bunun anlam� bu ���n sadece 6. katmana ait olan objeleri dikkate alacakt�r. Sadece bu katmandaki objelere bu ���n� g�ndereceksin ve onlara �arpt���nda true olacaks�n diyor. Di�erlerini dikkate almayacakt�r bu kullan�ma g�re. Bu i�lemin tam tersini yapaca��m�z zaman ise �u �ekilde yapar�z;

        layerMask = ~ layerMask; // Burada ise yukar�daki int layerMask = 1<<6; i�leminin tam tersini yap diyoruz. Yani 6. katmana ait olan objeleri dikkate almayacaks�n, 6. katman d���nda kalan di�er objeleri dikkate alacaks�n. 

        RaycastHit hit; //RaycastHit: I��n� �arpt�rd���m�z objeyle ilgili bilgileri alabilece�imiz bir kontrold�r. Burdaki hit ile o objenin name i olsun componentleri olsun her�eyine eri�ebiliriz. GetComponent<> mant��� gibi d���n. 

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask)) //Burada yazm�� oldu�umuz layerMask, bu ���n�n hangi katman� dikkate alaca��n� ya da dikkate almayaa��n� belirtti�imiz noktad�r. 
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black); //RaycastHit diyerek fizik s�n�f�n�n i�indeki Raycast i �a��r�yoruz, bu �arpma i�lemini sa�lamak i�in. �lk vermi� oldu�umuz transform.postion parametresi benim ���n�m�n ba�layacak oldu�u parametre. Yani bu script dosyas�n�n ekli oldu�u objeden itibaren ���n yaymaya ba�layabilirsin. Burada ise transform.TransformDirection(Vector3.forward) ���n�n hangi y�nde ilerleyece�ine karar veriyor. out hit ise ���n herhangi bir objeye �arpt��� zaman o bilgileri hit de tutabiliyoruz, ���n �arpt��� zaman hit de�eri true ya d�necektir. Hi� bir objeye �arpmad��� zaman ���n false de�eri verecektir. Mathf.Infinity ise g�nderece�imiz ���n�n menzili belirtti�imiz yerdir. Yani bu �izgi ne kadar ileri gidecek onu belirtiyoruz. Debug.Drawray ise oyunda �izilen �izgiyi rahat g�rebilmemiz i�in. hit.distance diyerek �arp�lan objenin almak istedi�imiz �zelliklerine ula�abiliyoruz burada distance yani mesafeye ula��lm�� Yukar�daki Mathf.Infinity yerine 5 yazm�� olsayd�k, ���n�n ��kt��� obje ile deydi�i obje aras�ndaki mesafe 5 birim veya alt�nda oldu�unda aktif olur. E�er istersek Mathf.Infinity den sonra layerMask tan�mlayabiliriz.   
            Debug.Log("Hedef var");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) *1000, Color.yellow);
            Debug.Log("Hedef yok");
        }
    }

    private void Update()
    {
        
    }
}
