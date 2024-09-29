![Ekran görüntüsü 2024-09-29 230119](https://github.com/user-attachments/assets/410b703e-4c08-4798-98e3-b6d2ffd8c97c)
![Ekran görüntüsü 2024-09-29 230109](https://github.com/user-attachments/assets/0edf4c62-e4d1-410c-a54a-621944ca2898)
proje  Tanımı
Kütüphane Yönetim Sistemi, ASP.NET Core MVC kullanarak geliştirilmiş bir uygulamadır. Bu sistem, bir kütüphanenin kitap ve yazar işlemlerini yönetmek için kapsamlı bir çözüm sunar. Kullanıcılar, kitapları görüntüleyebilir, detaylarını inceleyebilir, yeni kitaplar ekleyebilir, mevcut kitapları düzenleyebilir ve silebilir.

Proje Yapılandırması
Gerekli Teknolojiler
ASP.NET Core MVC: Uygulamanın temel yapısını oluşturur.
C#: Sunucu tarafı programlama dili.
HTML/CSS: Görsel arayüz için kullanılır.
Razor: Dinamik web sayfaları oluşturmak için kullanılır.
Model Yapısı
Proje üç ana model içermektedir:

Book: Kitap bilgilerini tutar (Id, Title, AuthorId, Genre, PublishDate, ISBN, CopiesAvailable).
Author: Yazar bilgilerini tutar (Id, FirstName, LastName, DateOfBirth).
User: Kullanıcı bilgilerini tutar (Id, FullName, Email, Password, PhoneNumber, JoinDate).
Controller Yapısı
Projede iki ana controller bulunmaktadır:

BookController: Kitaplarla ilgili tüm işlemleri yönetir (listeleme, detay, ekleme, düzenleme, silme).
AuthorController: Yazarlarla ilgili tüm işlemleri yönetir (listeleme, detay, ekleme, düzenleme, silme).
AuthController: Kullanıcı kayıt ve giriş işlemlerini yönetir.
View Yapısı
Her controller için uygun view'lar oluşturulmuştur:

Kitaplar ve yazarlar için listeleme, detay, ekleme ve düzenleme sayfaları.
Kullanıcılar için kayıt ve giriş sayfaları.
Projenin Çalışma Şekli
Kullanıcı Arayüzü: Kullanıcı, ana sayfada kitaplar ve yazarlar hakkında genel bir bilgiye ulaşır. Buradan ilgili sayfalara yönlendirilir.
Veri İşlemleri: Kullanıcı, kitap eklemek, düzenlemek veya silmek istediğinde form aracılığıyla gerekli bilgileri girer. Bu bilgiler, ilgili controller aracılığıyla işlenir.
Veritabanı Entegrasyonu: Uygulama henüz bir veritabanı kullanmıyor, ancak ileride veri kalıcılığı sağlamak için bir veritabanı entegrasyonu düşünülmektedir.
Test Süreci
Fonksiyonel Testler: Her bir eylem metodunun beklenen şekilde çalışıp çalışmadığı kontrol edilmiştir. Örneğin, kitap ekleme ve silme işlemleri test edilmiştir.
Kullanıcı Arayüzü Testleri: Tüm view'ların doğru bir şekilde görüntülenip görüntülenmediği kontrol edilmiştir.
Model Doğrulama: Kullanıcıdan alınan verilerin doğruluğu, model doğrulama mekanizmaları ile test edilmiştir.
Gelecek Geliştirmeler
Veritabanı Entegrasyonu: Kalıcı veri saklama için Entity Framework veya başka bir ORM kullanılabilir.
Kullanıcı Yetkilendirme: Kullanıcıların yetkilendirilmesi için daha gelişmiş kimlik doğrulama mekanizmaları eklenebilir.
Test Otomasyonu: Unit testler ve entegrasyon testleri eklenerek uygulamanın sağlamlığı artırılabilir.
