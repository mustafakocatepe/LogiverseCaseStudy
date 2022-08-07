# Logiverse Case Çalışması

 2 vakanın çözümü ve açıklamaları da bu repo altında bulunmaktadır. 
 
## Vaka 1 

Çözüme ilk başladığımda aşağıdaki yöntem ile her elemanı sırayla dizinin diğer elemanları ile karşılaştırarak ilk for döngüsündeki elemanın içerideki for döngüsündeki elemandan küçük olması koşulunu kontrol ediyordum. Eğer bu koşul sağlanırsa maxDiff adındaki değişkenimde tuttuğum maksimum farkı da kontrol ederek atamasını yapıyordum. 

![solution1](https://user-images.githubusercontent.com/7917266/182937939-383f4c97-f9b7-42af-9045-5bffdfc675e3.png)

Fakat bu çözümde iç içe 2 for döngüsü kullanmak yerine aşağıda kullandığım çözüm yöntemi ile tek bir for döngüsü sayesinde aradığım datanın daha performanslı bir şekilde bulunacağını düşündüm. 

![solution2](https://user-images.githubusercontent.com/7917266/182939559-bff037f7-5db9-4cdf-ab18-6f49284ff2f3.png)

## Vaka 2

Robotun X ve Y koordinatlarında max gidebileceği alanları ve robotun max kat edebileceği yolu tutabilmek için alanlar tanımladım. (maxX, maxY, fullRoundLength)
Robotun bulunduğu X ve Y koordinatlarını tutacağım ve ayrıca toplam adım sayısını tutacağım alanlar tanımladım. (currentX, currentY, currentLocation)
Yönler için bir enum tanımladım ve ilk yön East olarak başlayacağı için ilk set işlemini yaptım. (Direction)

![robot1](https://user-images.githubusercontent.com/7917266/182940885-c25849de-2e7e-4e4e-96ec-529e9061b34b.png)

Robot cons. metodunda genişlik ve yükseklik alanlarını alarak maxX ve maxY metotlarına gerekli kontrolleri yaparak attım ve burada robotun max kat edebileceği yolu hesaplayarak ilgili değişkene atadım. 

Step metodunda gerekli kontrolleri yaptıktan sonra currentLocation isimli fielda atılan adım sayısını set edildi. (currentLocation atılan adım sayısı gibi kullanılıyor fakat robot tam tur attı ise başlangıç noktasında bu sıfırlanıyor gibi düşünülebilir ) Step içerisindeki -1 kontrolü step metodu çağrılmadan önce GetPos veya GetDir metotları çağrılırsa hatalı bir sonuç geri döndürmemek için konulmuştur.

CalculatePositionAndDirection adlı metotta ise robotun çizilen alanın neresinde olduğu gerekli kontroller sağlanarak tespit edilip sonucunda değişkenlere gerekli set işlemleri yapılmıştır. Örneğin currentLocation'ın maxX değerinden küçük olduğu durumda robot her zaman doğu yönüne bakmaktadır, her zaman currentY pozisyonunu 0'dır gibi. 

![robot2](https://user-images.githubusercontent.com/7917266/182941977-cdccc027-17e9-494d-80c8-254e2cdf6dd3.png)
