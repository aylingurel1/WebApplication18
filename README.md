# Otopark Yönetim Sistemi

Otopark işletmecileri ve kullanıcıları için geliştirilmiş, park yeri rezervasyonları, araç yönetimi ve ödeme süreçlerini dijitalleştiren kapsamlı bir web uygulamasıdır.

## Proje Hakkında Detaylı Bilgi

Bu proje, modern otopark yönetiminin karmaşıklığını çözmeyi amaçlayan kapsamlı bir web uygulamasıdır. Geleneksel otopark yönetiminde karşılaşılan sorunları (manuel kayıt tutma, rezervasyon karmaşıklığı, ödeme takibi zorluğu) teknolojik çözümlerle ortadan kaldırarak hem otopark işletmecilerine hem de kullanıcılara kolaylık sağlar.

Sistem, kullanıcıların park yerlerini önceden rezerve edebilmelerini, otopark işletmecilerinin ise tüm süreçleri merkezi bir platformdan yönetebilmelerini sağlar. Real-time park yeri takibi, otomatik faturalama ve kapsamlı raporlama özellikleri ile otopark yönetiminde verimliliği artırır.

## Özellikler (Features)

- **👤 Kullanıcı Yönetimi**: Güvenli kullanıcı kaydı, giriş ve profil yönetimi
- **🚗 Araç Yönetimi**: Kullanıcıların araçlarını sisteme kaydetme ve yönetme
- **📅 Park Yeri Rezervasyonu**: Tarih ve saat bazlı park yeri rezervasyon sistemi
- **🅿️ Park Yeri Yönetimi**: Park yerlerinin durumunu, konumunu ve özelliklerini yönetme
- **📝 Giriş-Çıkış Kayıtları**: Araçların otoparka giriş ve çıkış zamanlarının takibi
- **💳 Ödeme Yönetimi**: Rezervasyonlar için ödeme takibi ve faturalama
- **📊 Fiyatlandırma Sistemi**: Esnek fiyatlandırma modellerini destekleme
- **🔐 Güvenlik**: Cookie tabanlı kimlik doğrulama ve yetkilendirme
- **📱 Responsive Tasarım**: Tüm cihazlarda uyumlu kullanıcı arayüzü
- **📋 Veri Tabloları**: Gelişmiş filtreleme ve sıralama özellikleri

## Kullanılan Teknolojiler (Tech Stack)

### Backend

- **Framework**: ASP.NET Core 8.0
- **Database**: Microsoft SQL Server
- **ORM**: Entity Framework Core 8.0.5
- **Authentication**: Cookie Authentication
- **Language**: C# (.NET 8.0)

### Frontend

- **UI Framework**: ASP.NET MVC
- **CSS Framework**: Bootstrap
- **JavaScript Libraries**: jQuery, DataTables
- **Icons**: Bootstrap Icons

### Veritabanı

- **Primary**: Microsoft SQL Server
- **Connection**: Trusted Connection

### Diğer Araçlar

- **Development Environment**: Visual Studio 2022
- **Scaffolding**: Microsoft.VisualStudio.Web.CodeGeneration.Design
- **Package Manager**: NuGet

## Kurulum (Installation)

### Gereksinimler

- .NET 8.0 SDK
- Microsoft SQL Server (LocalDB veya Full Version)
- Visual Studio 2022 (önerilen) veya Visual Studio Code

### Adım Adım Kurulum

1. **Repoyu klonlayın**

   ```bash
   git clone https://github.com/aylingurel1/Otopark-Projesi.git
   cd Otopark-Projesi
   ```

2. **Proje dizinine geçin**

   ```bash
   cd WebApplication18/WebApplication18
   ```

3. **NuGet paketlerini yükleyin**

   ```bash
   dotnet restore
   ```

4. **Veritabanı bağlantısını yapılandırın**

   - `appsettings.json` dosyasındaki connection string'i kendi SQL Server ayarlarınıza göre güncelleyin:

   ```json
   "ConnectionStrings": {
     "constring": "Data Source=YOUR_SERVER;initial Catalog=Otopark_uygulamasi;trusted_connection=yes;TrustServerCertificate=true"
   }
   ```

5. **Veritabanını oluşturun**

   ```bash
   dotnet ef database update
   ```

6. **Uygulamayı çalıştırın**

   ```bash
   dotnet run
   ```

7. **Tarayıcınızda açın**
   - Varsayılan adres: `https://localhost:7xxx` (port numarası console'da görüntülenecektir)

## Kullanım (Usage)

### Ana İşlevler

- **Giriş/Kayıt**: `/Startp/Login` adresinden sisteme giriş yapabilirsiniz
- **Dashboard**: Giriş yaptıktan sonra ana kontrol paneline yönlendirilirsiniz
- **Araç Yönetimi**: `/Araclars` - Araçlarınızı ekleyin, düzenleyin ve yönetin
- **Park Yeri Rezervasyonu**: `/Rezervasyonlars` - Yeni rezervasyon oluşturun veya mevcut rezervasyonları yönetin
- **Park Yerleri**: `/ParkYerleris` - Mevcut park yerlerini görüntüleyin ve durumlarını kontrol edin

### Admin Paneli

- **Kullanıcı Yönetimi**: `/Kullanicilars` - Sistem kullanıcılarını yönetin
- **Fiyatlandırma**: `/Fiyatlandirmas` - Park ücreti tarifelerini belirleyin
- **Raporlar**: `/GirisCikisKayitlaris` - Giriş-çıkış kayıtlarını görüntüleyin
- **Ödemeler**: `/Odemelers` - Ödeme kayıtlarını takip edin

### API Endpoints

- `GET /Demo/GetAraclar/{KullaniciId}` - Kullanıcının araçlarını JSON formatında getirir
- Tüm CRUD işlemleri için RESTful endpoint'ler mevcuttur

## Veritabanı Şeması

Proje aşağıdaki ana tablolara sahiptir:

- **Kullanicilar**: Sistem kullanıcıları
- **Araclar**: Kullanıcı araçları
- **ParkYerleri**: Park yeri bilgileri
- **Rezervasyonlar**: Park yeri rezervasyonları
- **GirisCikisKayitlari**: Araç giriş-çıkış kayıtları
- **Odemeler**: Ödeme kayıtları
- **Fiyatlandirma**: Fiyat tarifeleri

## Katkıda Bulunma (Contributing)

Katkılarınızı memnuniyetle karşılıyoruz! Katkıda bulunmak için:

1. Bu repository'yi fork edin
2. Yeni bir feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Bir Pull Request açın

### Geliştirme Kuralları

- Clean Code prensiplerini takip edin
- Unit testler yazın
- Commit mesajlarını açıklayıcı yazın
- Pull request açmadan önce kodu test edin

## Lisans (License)

Bu proje MIT Lisansı ile lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakınız.

## İletişim (Contact)

- **Geliştirici**: Aylin Gürel
- **GitHub**: [@aylingurel1](https://github.com/aylingurel1)
- **Proje Linki**: [https://github.com/aylingurel1/Otopark-Projesi](https://github.com/aylingurel1/Otopark-Projesi)

---

## Ekran Görüntüleri

> Bu bölüme uygulamanızın ekran görüntülerini ekleyerek kullanıcılara arayüz hakkında ön bilgi verebilirsiniz.

## Gelecek Planları

- [ ] Mobile uygulama desteği
- [ ] QR kod ile hızlı park yeri tanıma
- [ ] Real-time bildirimler
- [ ] Gelişmiş raporlama dashboard'u
- [ ] API dokumentasyonu
- [ ] Docker containerization

## Sorun Giderme

Yaygın sorunlar ve çözümleri için [Issues](https://github.com/aylingurel1/Otopark-Projesi/issues) bölümünü kontrol edin.

### Sık Karşılaşılan Sorunlar

**Veritabanı Bağlantı Hatası**

- Connection string'inizin doğru olduğundan emin olun
- SQL Server'ın çalıştığını kontrol edin

**Migration Hataları**

- `dotnet ef migrations add InitialCreate` komutu ile yeni migration oluşturun
- `dotnet ef database update` ile veritabanını güncelleyin
