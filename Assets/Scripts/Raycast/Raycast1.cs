using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast1 : MonoBehaviour
{
    //NOT: Ýstediðimiz noktaya bir ýþýn göndererek o ýþýnýn herhangi bir objeye çarpýp çarpmamasýný kontrol edebilmemizi saðlar RAYCAST.



    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        int layerMask = 1 << 6; //Bunun anlamý bu ýþýn sadece 6. katmana ait olan objeleri dikkate alacaktýr. Sadece bu katmandaki objelere bu ýþýný göndereceksin ve onlara çarptýðýnda true olacaksýn diyor. Diðerlerini dikkate almayacaktýr bu kullanýma göre. Bu iþlemin tam tersini yapacaðýmýz zaman ise þu þekilde yaparýz;

        layerMask = ~ layerMask; // Burada ise yukarýdaki int layerMask = 1<<6; iþleminin tam tersini yap diyoruz. Yani 6. katmana ait olan objeleri dikkate almayacaksýn, 6. katman dýþýnda kalan diðer objeleri dikkate alacaksýn. 

        RaycastHit hit; //RaycastHit: Iþýný çarptýrdýðýmýz objeyle ilgili bilgileri alabileceðimiz bir kontroldür. Burdaki hit ile o objenin name i olsun componentleri olsun herþeyine eriþebiliriz. GetComponent<> mantýðý gibi düþün. 

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask)) //Burada yazmýþ olduðumuz layerMask, bu ýþýnýn hangi katmaný dikkate alacaðýný ya da dikkate almayaaðýný belirttiðimiz noktadýr. 
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black); //RaycastHit diyerek fizik sýnýfýnýn içindeki Raycast i çaðýrýyoruz, bu çarpma iþlemini saðlamak için. Ýlk vermiþ olduðumuz transform.postion parametresi benim ýþýnýmýn baþlayacak olduðu parametre. Yani bu script dosyasýnýn ekli olduðu objeden itibaren ýþýn yaymaya baþlayabilirsin. Burada ise transform.TransformDirection(Vector3.forward) ýþýnýn hangi yönde ilerleyeceðine karar veriyor. out hit ise ýþýn herhangi bir objeye çarptýðý zaman o bilgileri hit de tutabiliyoruz, ýþýn çarptýðý zaman hit deðeri true ya dönecektir. Hiç bir objeye çarpmadýðý zaman ýþýn false deðeri verecektir. Mathf.Infinity ise göndereceðimiz ýþýnýn menzili belirttiðimiz yerdir. Yani bu çizgi ne kadar ileri gidecek onu belirtiyoruz. Debug.Drawray ise oyunda çizilen çizgiyi rahat görebilmemiz için. hit.distance diyerek çarpýlan objenin almak istediðimiz özelliklerine ulaþabiliyoruz burada distance yani mesafeye ulaþýlmýþ Yukarýdaki Mathf.Infinity yerine 5 yazmýþ olsaydýk, ýþýnýn çýktýðý obje ile deydiði obje arasýndaki mesafe 5 birim veya altýnda olduðunda aktif olur. Eðer istersek Mathf.Infinity den sonra layerMask tanýmlayabiliriz.   
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
