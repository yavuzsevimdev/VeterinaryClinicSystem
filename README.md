# 🐾 Veterinary Clinic Management System

**Veterinary Clinic Management System**, veteriner kliniklerinin günlük operasyonlarını dijital ortamda yönetebilmek amacıyla geliştirilmiş, **ASP.NET Core 8** tabanlı full-stack bir web uygulamasıdır.

Proje; **hayvan, randevu, tedavi, ödeme ve raporlama** süreçlerini tek bir platform üzerinden yönetmeyi ve farklı kullanıcı rollerine göre yetkilendirilmiş bir kullanım deneyimi sunmayı amaçlamaktadır.

---

### 🚀 Kullanılan Temel Teknolojiler

![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-12-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![ASP.NET Identity](https://img.shields.io/badge/ASP.NET%20Identity-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-Authentication-000000?style=for-the-badge&logo=jsonwebtokens&logoColor=white)

---

## 📖 Proje Hakkında

**Veterinary Clinic Management System**, bir veteriner kliniğinin günlük operasyonlarını tek bir platform üzerinden yönetebilmek amacıyla geliştirilmiş katmanlı bir web uygulamasıdır.

Sistem içerisinde **Customer** ve **Manager** olmak üzere iki farklı kullanıcı rolü bulunmaktadır. Kullanıcıların erişebileceği işlemler rol bazlı yetkilendirme ile kontrol edilmektedir.

Müşteriler kendi hayvanlarını ve randevularını yönetebilirken, Manager kullanıcıları kliniğin genel operasyonlarını yönetebilir. Hayvan kayıtları, randevular, tedaviler, ödemeler ve raporlama gibi temel süreçler uygulama üzerinden gerçekleştirilebilmektedir.

Proje kapsamında ayrıca **OpenWeatherMap**, **QuestPDF**, **SMTP Email**, **Serilog** ve **Swagger** gibi farklı teknolojiler ve harici servisler entegre edilerek gerçek dünya senaryolarına daha yakın bir uygulama yapısı oluşturulmuştur.

---

## 🎯 Projenin Amaçları

Projenin geliştirilmesindeki temel amaçlar:

- Gerçek dünya senaryosuna uygun bir veteriner klinik yönetim sistemi geliştirmek.
- Katmanlı mimari yaklaşımını uygulamak.
- Güvenli Authentication ve Role-Based Authorization yapısı oluşturmak.
- Hayvan, randevu, tedavi ve ödeme süreçlerini yönetmek.
- Klinik operasyonları için raporlama ve finansal takip özellikleri sunmak.
- Harici servis entegrasyonlarını uygulamak.
- Randevu ve yönetim raporlarını PDF olarak oluşturabilmek.
- E-posta gönderim altyapısını sisteme dahil etmek.
- Serilog ile uygulama loglarını takip etmek.
- Merkezi hata yönetimi mekanizması oluşturmak.
- Modern ve kullanıcı dostu bir web arayüzü geliştirmek.

---

## 🖼️ Ekran Görüntüleri

Uygulamanın temel ekranlarından seçilmiş örnekler aşağıda yer almaktadır.

### 🔐 Giriş ve Kayıt
<img width="1919" height="1079" alt="1-)Account-Login" src="https://github.com/user-attachments/assets/b4e73684-6331-4c23-a612-07fd85deea3b" />
<img width="1919" height="1079" alt="2-)Account-Register" src="https://github.com/user-attachments/assets/cd03109a-bd5d-47d4-9d1c-27ce7745b055" />


### 🩺 Manager Dashboard
<img width="1415" height="3013" alt="10-)Manager-Home-Dashboard" src="https://github.com/user-attachments/assets/871b14e8-3f7d-466c-8742-9287f3a1a0e8" />

### 👤 Customer Dashboard
<img width="1355" height="1889" alt="3-)Customer-Home-Dashboard" src="https://github.com/user-attachments/assets/45d8f06a-01e5-403e-85fc-efd9fa3c7455" />

### 🐾 Hayvan Yönetimi
<img width="1355" height="1798" alt="4-)Customer-Animal-Index" src="https://github.com/user-attachments/assets/66fe61bb-a3a8-4b1e-b0b4-4edb7c1531a5" />
<img width="1350" height="1287" alt="13-)Manager-Animal-Create" src="https://github.com/user-attachments/assets/9c8cc6f3-a6e9-4a3c-8bff-89cf258530c4" />
<img width="1355" height="1598" alt="6-)Customer-Animal-Detail" src="https://github.com/user-attachments/assets/e6ea59db-0898-4fa4-a36e-1217fe43c89b" />
<img width="1350" height="1257" alt="12-)Manager-Animal-Detail" src="https://github.com/user-attachments/assets/0c4638db-30ff-438b-a121-9ea1ddb433c1" />

### 📅 Randevu Yönetimi
<img width="1350" height="1494" alt="14-)Manager-Appointment-Index" src="https://github.com/user-attachments/assets/6f5fad97-7828-44a3-9461-c8928066a858" />
<img width="1355" height="2180" alt="8-)Customer-Appointment-Detail" src="https://github.com/user-attachments/assets/1135bd98-855e-4b1a-b8c2-a0bbaec0dc6b" />
<img width="1350" height="1637" alt="15-)Manager-Appointment-Detail" src="https://github.com/user-attachments/assets/7b9d9d30-713b-4d7e-a500-2d1da306b451" />
<img width="1350" height="1215" alt="16-)Manager-Appointment-Create" src="https://github.com/user-attachments/assets/0c4b8dd6-9180-409f-b14c-ba049e30e95a" />

### 💊 Tedavi Yönetimi
<img width="1350" height="1907" alt="17-)Manager-Treatment-Index" src="https://github.com/user-attachments/assets/71ffac7c-71c6-400a-b51e-62c7778d8d03" />
<img width="1355" height="987" alt="9-)Customer-Treatment-Index" src="https://github.com/user-attachments/assets/b5fa0c1f-bfae-4924-9aa7-3595a55ee4b4" />
<img width="1350" height="1162" alt="18-)Manager-Treatment-Create" src="https://github.com/user-attachments/assets/46b88aab-3fcd-4e7d-a6d6-895274676399" />

### 💳 Ödeme Yönetimi
<img width="1350" height="2547" alt="19-)Manager-Payment-Index" src="https://github.com/user-attachments/assets/7eb75d3d-d7a2-495a-bfd3-6bb5a0b2c06b" />
<img width="1350" height="1274" alt="20-)Manager-Payment-MakePayment" src="https://github.com/user-attachments/assets/d8277adf-5006-47b8-86d8-f3f26d874510" />

### 📊 Raporlama
<img width="1350" height="1002" alt="21-)Manager-Report-Index" src="https://github.com/user-attachments/assets/945bd814-75f0-4637-b4d9-5ff462507b38" />
<img width="1365" height="945" alt="22-)Manager-Report-Examplepng" src="https://github.com/user-attachments/assets/689888a5-4c10-4dcf-863b-fcaa9f6726e9" />

---

## ✨ Temel Özellikler

Veterinary Clinic Management System içerisinde kullanıcı rollerine ve klinik operasyonlarına göre farklı özellikler sunulmaktadır.

### 🔐 Kimlik Doğrulama ve Yetkilendirme

- Kullanıcı kayıt ve giriş işlemleri
- ASP.NET Core Identity ile kullanıcı yönetimi
- JWT tabanlı API Authentication
- Role-Based Authorization
- Customer ve Manager rollerinin ayrıştırılması
- Yetkisiz kullanıcıların korumalı alanlara erişiminin engellenmesi
- Oturum süresi ve güvenli çıkış yönetimi

---

### 🐾 Hayvan Yönetimi

- Hayvan kayıtlarının oluşturulması
- Hayvan bilgilerinin güncellenmesi
- Hayvan detaylarının görüntülenmesi
- Hayvan kayıtlarının silinmesi
- Hayvanların sahipleriyle ilişkilendirilmesi
- Tür, cins, yaş, ağırlık ve boy gibi bilgilerin yönetilmesi
- Hayvanların sağlık geçmişinin tutulması
- Hayvanlara ait randevu ve tedavi geçmişinin görüntülenmesi

---

### 📅 Randevu Yönetimi

- Randevu oluşturma
- Randevu bilgilerinin güncellenmesi
- Randevu detaylarının görüntülenmesi
- Randevu iptal işlemleri
- Randevu geçmişinin görüntülenmesi
- Randevu durumlarının takip edilmesi
- Customer kullanıcılarının kendi hayvanları için randevu oluşturabilmesi
- Manager kullanıcılarının klinikteki randevuları yönetebilmesi
- Randevuların hayvan ve sahip bilgileriyle birlikte takip edilmesi

---

### 💊 Tedavi Yönetimi

- Tedavi kaydı oluşturma
- Tedavi bilgilerinin güncellenmesi
- Tedavi detaylarının görüntülenmesi
- Tedavi kayıtlarının silinmesi
- Tedavi türü ve açıklamalarının tutulması
- Tedavi maliyetlerinin kaydedilmesi
- Tedavi geçmişinin hayvan ve randevu ile ilişkilendirilmesi
- Tedavi maliyetlerinin finansal süreçlere yansıtılması

---

### 💳 Ödeme Yönetimi

- Ödeme kaydı oluşturma
- Ödeme bilgilerinin görüntülenmesi
- Ödeme yöntemlerinin takip edilmesi
- Randevu bazlı ödeme takibi
- Toplam tedavi maliyeti ve yapılan ödemelerin karşılaştırılması
- Kalan borç tutarının hesaplanması
- Ödeme geçmişinin görüntülenmesi
- Finansal istatistiklerin görüntülenmesi

---

### 📊 Raporlama

- Günlük raporlar
- Aylık raporlar
- Finansal raporlar
- Hayvan tedavi geçmişi raporları
- Raporların PDF olarak oluşturulması
- Raporların yazdırılabilmesi
- Raporların e-posta ile gönderilebilmesi

---

### 📄 PDF ve E-posta Entegrasyonu

- Randevu raporlarının PDF olarak oluşturulması
- PDF belgelerinin e-posta eki olarak gönderilmesi
- Günlük, aylık ve finansal raporların PDF çıktılarının oluşturulması
- Raporların Manager kullanıcısının e-posta adresine gönderilebilmesi
- SMTP tabanlı e-posta gönderim altyapısı

---

### 🌤️ Hava Durumu Entegrasyonu

- OpenWeatherMap API entegrasyonu
- Klinik konumuna göre hava durumu bilgilerinin görüntülenmesi
- Sıcaklık ve hava durumu açıklamalarının gösterilmesi
- Harici API üzerinden güncel hava durumu verilerinin alınması

---

### 📈 Dashboard ve İstatistikler

#### Customer Dashboard

- Kullanıcıya ait hayvanların görüntülenmesi
- Yaklaşan randevuların görüntülenmesi
- Kullanıcıya özel klinik bilgilerinin takip edilmesi

#### Manager Dashboard

- Klinik genelindeki operasyonların özetlenmesi
- Hayvan ve randevu istatistikleri
- Günlük randevuların görüntülenmesi
- Klinik operasyonlarının merkezi olarak takip edilmesi

---

### 📝 Loglama ve Hata Yönetimi

- Serilog ile uygulama loglama
- Console loglama
- Dosya tabanlı loglama
- Global Error Handling Middleware
- Uygulama içerisindeki beklenmeyen hataların merkezi olarak yönetilmesi

---

### 📚 API ve Swagger

- RESTful API yapısı
- Hayvan, randevu, kullanıcı, tedavi ve ödeme endpoint'leri
- JWT ile korunan API endpoint'leri
- Swagger UI ile API dokümantasyonu
- API endpoint'lerinin test edilebilir olması

---

## 👥 Kullanıcı Rolleri ve Yetkilendirme

Uygulamada kullanıcıların erişebileceği işlemler **Role-Based Authorization** yapısı kullanılarak ayrıştırılmıştır.

Sistemde iki temel kullanıcı rolü bulunmaktadır:

- 👤 **Customer** — Kendi hayvan ve randevu süreçlerini yönetir.
- 🩺 **Manager** — Klinik operasyonlarını ve tüm yönetim süreçlerini kontrol eder.

### 👤 Customer

Customer kullanıcıları kendi hesapları üzerinden yalnızca kendilerine ait veriler üzerinde işlem gerçekleştirebilir.

| Özellik | Customer |
|---|:---:|
| Kayıt / Giriş | ✅ |
| Kendi hayvanlarını görüntüleme | ✅ |
| Hayvan ekleme | ✅ |
| Kendi hayvanlarını güncelleme | ✅ |
| Kendi hayvanlarını silme | ✅ |
| Kendi hayvanlarının detaylarını görüntüleme | ✅ |
| Randevu oluşturma | ✅ |
| Kendi randevularını görüntüleme | ✅ |
| Kendi randevularını güncelleme | ✅ |
| Kendi randevusunu iptal etme | ✅ |
| Başka kullanıcıların hayvanlarına erişim | ❌ |
| Başka kullanıcıların randevularına erişim | ❌ |
| Klinik genelindeki randevuları yönetme | ❌ |
| Tedavi yönetimi | ❌ |
| Ödeme yönetimi | ❌ |
| Yönetim raporları | ❌ |

### 🩺 Manager

Manager kullanıcıları kliniğin genel operasyonlarını yönetebilecek yetkilere sahiptir.

| Özellik | Manager |
|---|:---:|
| Giriş | ✅ |
| Hayvanları yönetme | ✅ |
| Hayvan detaylarını görüntüleme | ✅ |
| Randevuları yönetme | ✅ |
| Randevu oluşturma | ✅ |
| Randevu güncelleme | ✅ |
| Randevu iptal etme | ✅ |
| Tedavi kayıtlarını yönetme | ✅ |
| Ödeme kayıtlarını yönetme | ✅ |
| Ödeme ve borç takibi | ✅ |
| Günlük raporlar | ✅ |
| Aylık raporlar | ✅ |
| Finansal raporlar | ✅ |
| Hayvan tedavi geçmişi raporları | ✅ |
| PDF raporları oluşturma | ✅ |
| Raporları e-posta ile gönderme | ✅ |
| Klinik hava durumu bilgilerini görüntüleme | ✅ |

### 🔐 Yetkilendirme Yaklaşımı

API tarafında JWT Authentication kullanılırken, kullanıcıların erişebileceği kaynaklar ayrıca sahiplik kontrolleriyle sınırlandırılmıştır.

Örneğin Customer kullanıcısı yalnızca kendi `OwnerId` bilgisiyle ilişkili hayvan ve randevulara erişebilir. Başka bir Customer kullanıcısına ait kaynaklara erişmeye çalışılması durumunda erişim engellenmektedir.

Manager kullanıcıları ise klinik genelindeki yönetim işlemlerine erişebilir.

Bu yapı sayesinde Authentication ve Authorization süreçleri birbirinden ayrılarak uygulanmıştır:

```text
Authentication
      ↓
Kullanıcı kimliği doğrulanır
      ↓
JWT Token
      ↓
Authorization
      ↓
Kullanıcı rolü ve kaynak sahipliği kontrol edilir
      ↓
Yetkili işlem gerçekleştirilir

```
---

## 🏗️ Proje Mimarisi

Proje, sorumlulukların birbirinden ayrılmasını sağlamak amacıyla **Katmanlı Mimari (Layered Architecture)** yaklaşımı kullanılarak geliştirilmiştir.

Her katman kendi sorumluluğuna odaklanmakta ve uygulamanın farklı bölümlerinin daha düzenli ve yönetilebilir şekilde geliştirilmesine olanak sağlamaktadır.

### 📂 Solution Yapısı

    VeterinaryClinicSystem
    │
    ├── VeterinaryClinic.Entities
    │
    ├── VeterinaryClinic.DataAccess
    │
    ├── VeterinaryClinic.Business
    │
    ├── VeterinaryClinic.API
    │
    └── VeterinaryClinic.UI

---

### 🧩 Katmanların Sorumlulukları

#### 📦 VeterinaryClinic.Entities

Uygulamanın temel veri modellerinin bulunduğu katmandır.

Bu katmanda sistem içerisindeki temel entity'ler tanımlanmaktadır:

- `User`
- `Animal`
- `Appointment`
- `Treatment`
- `Payment`
- `WeatherInfo`

Entity sınıfları uygulamanın veri modelini temsil etmekte ve diğer katmanlar tarafından kullanılmaktadır.

---

#### 🗄️ VeterinaryClinic.DataAccess

Veritabanı işlemlerinden sorumlu katmandır.

Bu katmanda:

- Entity Framework Core
- `DbContext`
- Generic Repository
- Specific Repository'ler
- Unit of Work

yapıları kullanılmaktadır.

Veritabanına erişim ve veri işlemlerinin yönetimi bu katman üzerinden gerçekleştirilmektedir.

---

#### ⚙️ VeterinaryClinic.Business

Uygulamanın iş kurallarının ve servislerinin bulunduğu katmandır.

Bu katmanda:

- Animal işlemleri
- Appointment işlemleri
- Treatment işlemleri
- Payment işlemleri
- User işlemleri
- Report işlemleri
- Weather işlemleri

gibi uygulama servisleri yönetilmektedir.

Business katmanı, uygulamanın iş mantığını veri erişim katmanından ayırarak daha düzenli bir yapı oluşturmayı amaçlamaktadır.

---

#### 🌐 VeterinaryClinic.API

Uygulamanın REST API katmanıdır.

Bu katman UI ile Business katmanı arasında iletişim sağlar ve uygulamanın dış dünyaya sunduğu API endpoint'lerini içerir.

Başlıca API alanları:

- `/api/users`
- `/api/animals`
- `/api/appointments`
- `/api/treatments`
- `/api/payments`
- `/api/external/weather`
- `/api/reports`

API katmanında ayrıca:

- JWT Authentication
- Role-Based Authorization
- Swagger
- Global Error Handling
- Serilog
- PDF işlemleri
- E-posta gönderimi

gibi uygulama servisleri ve altyapı bileşenleri kullanılmaktadır.

---

#### 🖥️ VeterinaryClinic.UI

Kullanıcının uygulama ile etkileşime geçtiği web arayüzü katmanıdır.

Bu katmanda:

- ASP.NET Core MVC
- Controllers
- Razor Views
- ViewComponents
- UI Services
- DTO'lar
- Cookie Authentication

kullanılmaktadır.

UI katmanı API üzerinden aldığı verileri kullanıcıya modern ve kullanıcı dostu bir arayüz ile sunmaktadır.

---

### 🔄 Katmanlar Arası İletişim

Uygulamanın temel veri akışı aşağıdaki yapı üzerinden ilerlemektedir:

    VeterinaryClinic.UI
             │
             │ HTTP / REST API
             ▼
    VeterinaryClinic.API
             │
             ▼
    VeterinaryClinic.Business
             │
             ▼
    VeterinaryClinic.DataAccess
             │
             ▼
         SQL Server

UI katmanı, HTTP/REST API üzerinden API katmanıyla iletişim kurmaktadır.

API katmanı gelen istekleri ilgili Business servislerine yönlendirmekte, Business katmanı gerekli iş mantığını uygulamakta ve veri erişim işlemleri DataAccess katmanı üzerinden gerçekleştirilmektedir.

---

### 🎯 Katmanlı Mimari ile Sağlanan Avantajlar

- Sorumlulukların ayrıştırılması
- Kodun daha düzenli ve yönetilebilir olması
- Veri erişimi ile iş mantığının birbirinden ayrılması
- API ve UI katmanlarının bağımsız olarak yönetilebilmesi
- Yeni özelliklerin mevcut yapıya daha kontrollü şekilde eklenebilmesi
- Projenin bakım ve geliştirme süreçlerinin kolaylaştırılması

---

## 🔄 Uygulama Veri Akışı ve Servis Mimarisi

Uygulama içerisinde kullanıcı işlemleri, API istekleri ve veri erişimi katmanlar arasında belirli bir akış üzerinden gerçekleştirilmektedir.

Bu yapı sayesinde kullanıcı arayüzü, API endpoint'leri, iş mantığı ve veritabanı işlemleri birbirinden ayrılmıştır.

### 🌐 Genel İstek Akışı

    Kullanıcı
       │
       ▼
    VeterinaryClinic.UI
       │
       │ HTTP / REST API
       ▼
    VeterinaryClinic.API
       │
       ▼
    Business Services
       │
       ▼
    Repository / Unit of Work
       │
       ▼
    Entity Framework Core
       │
       ▼
    SQL Server

Kullanıcının gerçekleştirdiği işlemler UI katmanından başlatılmakta ve HTTP/REST API üzerinden API katmanına iletilmektedir.

API katmanı ilgili Business servisini çağırarak gerekli iş mantığının uygulanmasını sağlar.

Veritabanı işlemleri ise DataAccess katmanındaki Repository ve Unit of Work yapıları üzerinden gerçekleştirilir.

---

### 🔐 Authentication Akışı

Uygulamada API tarafında **JWT Authentication**, UI tarafında ise **Cookie Authentication** kullanılmaktadır.

    Kullanıcı
       │
       ▼
    Login
       │
       ▼
    VeterinaryClinic.API
       │
       ▼
    Identity / UserManager
       │
       ▼
    JWT Token
       │
       ▼
    VeterinaryClinic.UI
       │
       ▼
    Cookie Authentication
       │
       ▼
    Korumalı Sayfalar

Kullanıcı giriş yaptığında API tarafından oluşturulan JWT token UI katmanına iletilmektedir.

UI katmanı token içerisindeki kullanıcı bilgilerini kullanarak kendi Cookie Authentication oturumunu oluşturmaktadır.

API'ye gönderilen korumalı isteklerde JWT token kullanılarak kullanıcının kimliği doğrulanmaktadır.

---

### 👥 Yetkilendirme Akışı

Authentication işleminin ardından kullanıcının sisteme erişim yetkileri kontrol edilmektedir.

    JWT Token
       │
       ▼
    Kullanıcı Kimliği
       │
       ▼
    Kullanıcı Rolü
       │
       ├── Customer
       │
       └── Manager
       │
       ▼
    Authorization Kontrolü
       │
       ▼
    İlgili Kaynağa Erişim

Customer kullanıcıları yalnızca kendi kaynakları üzerinde işlem yapabilirken, Manager kullanıcıları klinik genelindeki yönetim işlemlerine erişebilmektedir.

Ayrıca API tarafında kaynak sahipliği kontrolleri uygulanarak bir Customer kullanıcısının başka bir Customer kullanıcısına ait verilere erişmesi engellenmektedir.

---

### 🐾 Hayvan ve Randevu Veri Akışı

Hayvan ve randevu işlemlerinde ilgili entity'ler arasındaki ilişkiler kullanılarak veri bütünlüğü korunmaktadır.

    User
      │
      └── Animal
            │
            └── Appointment
                  │
                  ├── Treatment
                  │
                  └── Payment

Bir hayvan bir kullanıcıyla ilişkilendirilmekte, hayvana ait randevular oluşturulabilmekte ve ilgili randevu üzerinden tedavi ve ödeme kayıtları takip edilebilmektedir.

Bu ilişki yapısı sayesinde hayvanın klinik geçmişi, randevuları, tedavileri ve ödeme bilgileri birbiriyle ilişkilendirilmektedir.

---

### 💊 Tedavi ve Ödeme Akışı

Tedavi kayıtları ilgili randevu üzerinden oluşturulmaktadır.

    Appointment
         │
         ├── Treatment
         │      │
         │      └── Cost
         │
         └── Payment
                │
                └── AmountPaid

Tedavi maliyetleri ile yapılan ödemeler karşılaştırılarak ilgili randevu için kalan ödeme tutarı hesaplanabilmektedir.

Bu yapı ödeme takibi ve finansal raporlama süreçlerinde kullanılmaktadır.

---

### 📄 PDF ve E-posta Akışı

Uygulamada QuestPDF kullanılarak randevu ve yönetim raporları PDF formatında oluşturulabilmektedir.

    Rapor / Randevu Verisi
             │
             ▼
         PdfService
             │
             ▼
          QuestPDF
             │
             ▼
        PDF Document
             │
             ▼
        EmailService
             │
             ▼
       SMTP / E-Mail

Oluşturulan PDF belgeleri kullanıcıya indirilebilmekte, yazdırılabilmekte veya e-posta eki olarak gönderilebilmektedir.

---

### 🌤️ Hava Durumu Veri Akışı

Hava durumu bilgileri OpenWeatherMap API üzerinden alınmaktadır.

    VeterinaryClinic.UI
             │
             ▼
       Weather Service
             │
             ▼
      OpenWeatherMap API
             │
             ▼
      Weather Information
             │
             ▼
       Kullanıcı Arayüzü

Harici API üzerinden alınan hava durumu bilgileri uygulama içerisinde kullanıcıya sunulmaktadır.

---

### 📝 Hata Yönetimi ve Loglama Akışı

API tarafında merkezi hata yönetimi için Global Error Handling Middleware kullanılmaktadır.

Uygulama içerisinde oluşan loglar ise Serilog aracılığıyla yönetilmektedir.

    API Request
        │
        ▼
    Application
        │
        ├── Başarılı işlem
        │
        └── Exception
               │
               ▼
      Error Handling Middleware
               │
               ▼
          Error Response

Serilog ile uygulama logları Console ve File sink'leri üzerinden takip edilebilmektedir.

---

## 🛠️ Kullanılan Teknolojiler ve Araçlar

Projede backend, API, veri erişimi, authentication, raporlama, harici servis entegrasyonları ve kullanıcı arayüzü için farklı teknolojiler bir arada kullanılmıştır.

### 💻 Backend ve Framework

| Teknoloji | Kullanım Alanı |
|---|---|
| **C#** | Uygulamanın temel programlama dili |
| **.NET 8** | Uygulamanın temel çalışma platformu |
| **ASP.NET Core 8** | Web uygulaması ve API geliştirme |
| **ASP.NET Core MVC** | Kullanıcı arayüzünün geliştirilmesi |
| **Razor Views** | Server-side web sayfalarının oluşturulması |

---

### 🗄️ Veritabanı ve Veri Erişimi

| Teknoloji | Kullanım Alanı |
|---|---|
| **SQL Server** | Uygulamanın ilişkisel veritabanı |
| **Entity Framework Core 8** | ORM ve veritabanı işlemleri |
| **EF Core Code First** | Entity modellerinden veritabanı oluşturulması |
| **Migrations** | Veritabanı şema değişikliklerinin yönetilmesi |
| **Generic Repository** | Genel veri erişim işlemlerinin yönetilmesi |
| **Specific Repository** | Entity'lere özel veri erişim işlemleri |
| **Unit of Work** | Birden fazla veri işleminin koordineli şekilde yönetilmesi |

---

### 🔐 Authentication ve Authorization

| Teknoloji | Kullanım Alanı |
|---|---|
| **ASP.NET Core Identity** | Kullanıcı ve rol yönetimi |
| **JWT Bearer Authentication** | API authentication |
| **Cookie Authentication** | UI tarafında kullanıcı oturum yönetimi |
| **Role-Based Authorization** | Customer ve Manager erişimlerinin ayrıştırılması |
| **User Secrets** | Hassas yapılandırma bilgilerinin güvenli şekilde saklanması |

---

### 🌐 API ve Entegrasyonlar

| Teknoloji | Kullanım Alanı |
|---|---|
| **REST API** | UI ve backend arasındaki iletişim |
| **Swagger / OpenAPI** | API dokümantasyonu ve endpoint testleri |
| **HttpClient** | Harici API ve servislerle iletişim |
| **OpenWeatherMap API** | Hava durumu verilerinin alınması |
| **SMTP** | E-posta gönderim işlemleri |

---

### 📄 PDF ve Raporlama

| Teknoloji | Kullanım Alanı |
|---|---|
| **QuestPDF** | Randevu ve yönetim raporlarının PDF olarak oluşturulması |
| **SMTP / Email** | PDF ve raporların e-posta ile gönderilmesi |

---

### 📝 Logging ve Hata Yönetimi

| Teknoloji | Kullanım Alanı |
|---|---|
| **Serilog** | Uygulama loglama altyapısı |
| **Serilog Console Sink** | Console loglarının oluşturulması |
| **Serilog File Sink** | Dosya tabanlı logların oluşturulması |
| **Global Error Handling Middleware** | API tarafında merkezi hata yönetimi |

---

### 🎨 Frontend ve Kullanıcı Arayüzü

| Teknoloji | Kullanım Alanı |
|---|---|
| **HTML5** | Sayfa yapısının oluşturulması |
| **CSS3** | Kullanıcı arayüzü stilleri |
| **JavaScript** | Dinamik kullanıcı etkileşimleri |
| **Bootstrap** | Responsive ve yardımcı UI bileşenleri |
| **Font Awesome** | Arayüz ikonları |
| **Razor ViewComponents** | UI bileşenlerinin modüler şekilde oluşturulması |

---

### 🧰 Geliştirme Araçları

| Araç | Kullanım Alanı |
|---|---|
| **Visual Studio** | Proje geliştirme ve debugging |
| **Git** | Versiyon kontrolü |
| **GitHub** | Kaynak kod yönetimi ve proje paylaşımı |
| **Swagger UI** | API testleri ve dokümantasyon |
| **SQL Server Management Studio** | Veritabanı yönetimi ve sorgulama |

---

## 🔐 Güvenlik

Uygulamada kullanıcı kimlik doğrulama, rol bazlı yetkilendirme, kaynak sahipliği kontrolü ve hassas yapılandırma bilgilerinin korunması için birden fazla güvenlik mekanizması birlikte kullanılmaktadır.

### 🔑 ASP.NET Core Identity

ASP.NET Core Identity kullanılarak kullanıcı hesapları ve roller yönetilmektedir.

Identity üzerinden:

- Kullanıcı kayıt işlemleri
- Kullanıcı giriş işlemleri
- Şifre yönetimi
- Kullanıcı kimlik bilgileri
- Customer ve Manager rolleri

yönetilmektedir.

---

### 🎫 JWT Authentication

API tarafındaki korumalı endpoint'lerde **JWT Bearer Authentication** kullanılmaktadır.

Kullanıcı başarılı şekilde giriş yaptığında API tarafından JWT token oluşturulmaktadır.

Token içerisinde kullanıcı kimliği, e-posta, isim ve rol gibi claim bilgileri bulunmaktadır.

Korumalı API isteklerinde JWT token doğrulanarak kullanıcının kimliği kontrol edilmektedir.

---

### 👥 Role-Based Authorization

Uygulamada iki temel rol bulunmaktadır:

- `Customer`
- `Manager`

Endpoint ve uygulama alanlarına göre kullanıcı rolü kontrol edilmektedir.

Manager'a özel işlemler Customer kullanıcılarından korunurken, Customer kullanıcılarının kendi kaynakları üzerindeki işlemleri ayrıca sahiplik kontrolünden geçirilmektedir.

---

### 🛡️ Kaynak Sahipliği Kontrolü

Customer kullanıcılarının yalnızca kendi verilerine erişebilmesi için kaynak sahipliği kontrolleri uygulanmaktadır.

Örneğin:

    Customer
       │
       ▼
    JWT UserId
       │
       ▼
    Animal.OwnerId
       │
       ├── Eşleşiyor → İşleme izin ver
       │
       └── Eşleşmiyor → Erişimi engelle

Bu kontrol hayvan ve randevu gibi kullanıcıya ait kaynaklarda uygulanmaktadır.

---

### 🍪 UI Cookie Authentication

UI katmanında kullanıcı oturumlarının yönetilmesi için Cookie Authentication kullanılmaktadır.

JWT token üzerinden elde edilen kullanıcı bilgileri UI tarafındaki authentication cookie içerisinde kullanılmaktadır.

Cookie oturum süresi belirlenmiş ve sliding expiration devre dışı bırakılmıştır.

---

### 🔒 User Secrets

Veritabanı bağlantı bilgileri, JWT anahtarı, OpenWeatherMap API anahtarı ve e-posta gibi hassas yapılandırma bilgileri kaynak kod içerisinde tutulmamaktadır.

Development ortamında bu bilgiler **ASP.NET Core User Secrets** kullanılarak yönetilmektedir.

Bu sayede hassas bilgilerin GitHub repository'sine gönderilmesinin önüne geçilmiştir.

---

### 🧱 API Güvenlik Yapısı

Korumalı API endpoint'lerinde JWT authentication kullanılmaktadır.

Genel güvenlik akışı:

    Request
       │
       ▼
    JWT Token
       │
       ▼
    Token Validation
       │
       ▼
    Authentication
       │
       ▼
    Authorization
       │
       ▼
    Resource Ownership
       │
       ▼
    Controller Action
---

---

## 📄 PDF ve E-posta Sistemi

Uygulamada randevu ve yönetim raporlarının PDF formatında oluşturulabilmesi ve e-posta üzerinden gönderilebilmesi için **QuestPDF** ve SMTP tabanlı e-posta altyapısı kullanılmıştır.

### 📑 PDF Oluşturma

PDF işlemleri `PdfService` üzerinden gerçekleştirilmektedir.

PDF oluşturma süreçlerinde **QuestPDF** kullanılmıştır.

Desteklenen rapor türleri:

- Randevu raporu
- Günlük rapor
- Aylık rapor
- Finansal rapor
- Hayvan tedavi geçmişi raporu

---

### 📅 Randevu PDF Raporu

Manager veya yetkili Customer kullanıcıları ilgili randevu için PDF raporu oluşturabilmektedir.

Randevu raporunda randevuya ait temel bilgiler ile hayvan, tedavi ve ödeme bilgileri kullanılmaktadır.

    Appointment
         │
         ├── Animal
         ├── Treatment
         └── Payment
                │
                ▼
           PdfService
                │
                ▼
             QuestPDF
                │
                ▼
           PDF Document

---

### 📧 E-posta Gönderimi

Oluşturulan PDF belgeleri e-posta eki olarak gönderilebilmektedir.

E-posta işlemleri SMTP üzerinden gerçekleştirilmektedir.

    Report / Appointment
             │
             ▼
         PdfService
             │
             ▼
        PDF Attachment
             │
             ▼
        EmailService
             │
             ▼
            SMTP
             │
             ▼
         Recipient

---

### 📊 Yönetim Raporları

Manager kullanıcıları aşağıdaki raporları oluşturabilir:

- Günlük rapor
- Aylık rapor
- Finansal rapor
- Hayvan tedavi geçmişi

Her rapor için:

- PDF olarak indirme
- Yazdırma
- E-posta ile gönderme

işlemleri desteklenmektedir.

---

### 🛠️ Kullanılan Teknolojiler

- **QuestPDF** — PDF dokümanlarının oluşturulması
- **SMTP** — E-posta gönderimi
- **EmailService** — Uygulama içerisindeki e-posta işlemleri
- **PdfService** — PDF oluşturma işlemleri

---

## 🌤️ OpenWeatherMap Entegrasyonu

Uygulamada klinik için hava durumu bilgilerinin görüntülenebilmesi amacıyla **OpenWeatherMap API** entegre edilmiştir.

Harici API üzerinden alınan hava durumu bilgileri uygulamanın WeatherService yapısı üzerinden işlenerek kullanıcı arayüzüne aktarılmaktadır.

### 🔄 Veri Akışı

    VeterinaryClinic.UI
             │
             ▼
        WeatherService
             │
             ▼
       HTTP Request
             │
             ▼
     OpenWeatherMap API
             │
             ▼
      Weather Response
             │
             ▼
       Weather Data
             │
             ▼
      Kullanıcı Arayüzü

---

### 🌡️ Gösterilen Bilgiler

Hava durumu ekranında API'den alınan temel bilgiler kullanıcıya sunulmaktadır.

- 🌡️ Sıcaklık
- 🌤️ Hava durumu açıklaması
- 📍 Şehir bilgisi
- 📅 Veri tarihi

---

### 🔗 Entegrasyon Yapısı

Harici API ile iletişim için .NET `HttpClient` altyapısı kullanılmaktadır.

Weather işlemleri Business katmanındaki servis yapısı üzerinden yönetilmekte ve UI tarafı API üzerinden elde edilen verileri kullanmaktadır.

API anahtarı kaynak kod içerisinde tutulmamakta ve yapılandırma sistemi üzerinden yönetilmektedir.

---

### 🎯 Entegrasyonun Amacı

OpenWeatherMap entegrasyonu ile projeye gerçek bir harici servis entegrasyonu eklenmiş ve uygulamanın yalnızca yerel veritabanı işlemlerinden oluşmayan bir yapıya sahip olması sağlanmıştır.

---

## 📊 Raporlama

Uygulamada Manager kullanıcılarının klinik operasyonlarını ve finansal süreçleri takip edebilmesi amacıyla çeşitli raporlama ekranları oluşturulmuştur.

Raporlar hem uygulama içerisinde görüntülenebilmekte hem de PDF ve e-posta formatlarında kullanılabilmektedir.

### 📋 Rapor Türleri

| Rapor | Açıklama |
|---|---|
| 📅 Günlük Rapor | Gün içerisindeki klinik operasyonlarının özetlenmesi |
| 📆 Aylık Rapor | Aylık operasyon ve finansal verilerin görüntülenmesi |
| 💰 Finansal Rapor | Tedavi ve ödeme verilerinin finansal olarak incelenmesi |
| 🐾 Hayvan Tedavi Geçmişi | Hayvan bazlı tedavi kayıtlarının görüntülenmesi |

---

### 📅 Günlük Rapor

Günlük rapor içerisinde ilgili günün operasyonlarına ait bilgiler özetlenmektedir.

Randevu, tedavi ve ödeme süreçleri üzerinden günlük klinik durumu takip edilebilmektedir.

---

### 📆 Aylık Rapor

Aylık raporlar belirli bir ay içerisindeki klinik faaliyetlerinin genel görünümünü sunmaktadır.

Bu raporlar özellikle operasyonel ve finansal istatistiklerin takip edilmesi amacıyla kullanılmaktadır.

---

### 💰 Finansal Rapor

Finansal rapor ile tedavi maliyetleri ve yapılan ödemeler birlikte değerlendirilebilmektedir.

Tedavi maliyetleri ile ödeme kayıtları arasındaki fark üzerinden ödeme durumu ve kalan tutarlar takip edilebilmektedir.

---

### 🐾 Hayvan Tedavi Geçmişi

Hayvan tedavi geçmişi raporu üzerinden belirli bir hayvana ait tedavi kayıtları incelenebilmektedir.

Rapor içerisinde:

- Hayvan bilgileri
- Randevu bilgileri
- Tedavi türü
- Tedavi tarihi
- Tedavi maliyeti
- Tedavi açıklamaları

gibi bilgiler kullanılmaktadır.

---

### 📄 Rapor İşlemleri

Her rapor için aşağıdaki işlemler desteklenmektedir:

- 📥 PDF Download
- 🖨️ Print
- 📧 Email Send

Bu yapı sayesinde raporlar hem uygulama içerisinde incelenebilmekte hem de dışarıya aktarılabilmektedir.

---

## 📝 Logging ve Error Handling

Uygulamada oluşabilecek hataların merkezi olarak yönetilmesi ve uygulama davranışlarının takip edilebilmesi amacıyla **Global Error Handling Middleware** ve **Serilog** kullanılmıştır.

### 🛡️ Global Error Handling

API tarafında merkezi hata yönetimi için `ErrorHandlingMiddleware` kullanılmaktadır.

Genel akış:

    API Request
         │
         ▼
    Controller / Service
         │
         ├── Başarılı
         │      │
         │      ▼
         │   Response
         │
         └── Exception
                │
                ▼
       ErrorHandlingMiddleware
                │
                ▼
          Error Response

Bu yapı sayesinde uygulama içerisindeki beklenmeyen exception'lar merkezi bir noktada ele alınabilmektedir.

---

### 📋 Serilog

Uygulama loglama altyapısı için **Serilog** kullanılmıştır.

Serilog ile loglar farklı hedeflere gönderilebilmektedir.

Kullanılan sink'ler:

- Console
- File

---

### 🖥️ Console Logging

Development sürecinde uygulamanın çalışma durumunu takip edebilmek amacıyla Console logları kullanılmaktadır.

Bu sayede uygulama çalışırken oluşan önemli olaylar ve hatalar takip edilebilmektedir.

---

### 📁 File Logging

Uygulama logları dosya tabanlı olarak da tutulmaktadır.

Log dosyaları günlük olarak oluşturulacak şekilde yapılandırılmıştır.

Bu yapı geçmişte meydana gelen uygulama olaylarının incelenmesine yardımcı olmaktadır.

---

### 🎯 Hata Yönetiminin Amacı

Merkezi hata yönetimi ve loglama yapısı sayesinde:

- Uygulama hatalarının merkezi olarak ele alınması
- Beklenmeyen exception'ların kontrol edilmesi
- Hataların takip edilebilmesi
- Development sürecinde debugging işlemlerinin kolaylaştırılması
- Uygulama davranışlarının loglar üzerinden incelenebilmesi

amaçlanmıştır.

---

## 🗄️ Veritabanı

Uygulamanın veri yönetimi için **Microsoft SQL Server** ve **Entity Framework Core 8** kullanılmıştır.

Veritabanı geliştirme yaklaşımı olarak **Code First** tercih edilmiştir.

### 🧩 Temel Entity Yapısı

Uygulamanın temel veri modeli aşağıdaki entity'lerden oluşmaktadır:

    User
      │
      └── Animal
            │
            └── Appointment
                  │
                  ├── Treatment
                  │
                  └── Payment

    WeatherInfo

---

### 👤 User

ASP.NET Core Identity altyapısı kullanılarak kullanıcı hesapları yönetilmektedir.

Temel kullanıcı bilgileri:

- Id
- FullName
- Email
- Authentication bilgileri
- Role bilgileri

Identity tarafından yönetilmektedir.

---

### 🐾 Animal

Hayvanların klinik içerisindeki temel bilgilerini temsil eder.

Temel alanlar:

- Id
- OwnerId
- Name
- Age
- Weight
- Height
- Species
- Breed
- MedicalHistory
- City
- ImageUrl

Hayvan kayıtları ilgili kullanıcı ile ilişkilendirilmektedir.

---

### 📅 Appointment

Hayvanlara ait randevu bilgilerini temsil eder.

Temel alanlar:

- Id
- AnimalId
- Date
- Time
- Status
- AppointmentType
- Notes

Bir randevu ilgili hayvan ile ilişkilendirilmekte ve randevu üzerinden tedavi ve ödeme kayıtları takip edilebilmektedir.

---

### 💊 Treatment

Randevu kapsamında gerçekleştirilen tedavi işlemlerini temsil eder.

Temel alanlar:

- Id
- AppointmentId
- TreatmentType
- Notes
- Cost
- Date

Tedavi maliyetleri ödeme ve finansal raporlama süreçlerinde kullanılmaktadır.

---

### 💳 Payment

Randevulara ait ödeme bilgilerini temsil eder.

Temel alanlar:

- Id
- AppointmentId
- AmountPaid
- PaymentDate
- PaymentMethod

Ödeme kayıtları tedavi maliyetleriyle karşılaştırılarak finansal takip yapılmaktadır.

---

### 🌤️ WeatherInfo

Hava durumu verilerinin uygulama içerisindeki modelini temsil eder.

Temel alanlar:

- Id
- City
- Temperature
- Description
- Date

---

### 🛠️ Entity Framework Core

Entity Framework Core ile:

- DbContext
- DbSet
- Code First
- Migration
- LINQ sorguları
- Repository yapısı

kullanılmaktadır.

Veritabanı değişiklikleri Migration mekanizması üzerinden yönetilmektedir.

---

### 🔄 Repository ve Unit of Work

Veritabanı işlemlerinin yönetiminde:

- Generic Repository
- Specific Repository
- Unit of Work

yaklaşımı kullanılmıştır.

Bu yapı veri erişim işlemlerinin Business katmanından ayrılmasına yardımcı olmaktadır.

---

## 🚀 Kurulum

Projeyi lokal ortamınızda çalıştırmak için aşağıdaki adımları takip edebilirsiniz.

### 📋 Gereksinimler

Projeyi çalıştırmadan önce sisteminizde aşağıdaki araçların bulunması önerilmektedir:

- **.NET 8 SDK**
- **Visual Studio 2022 / 2026**
- **SQL Server**
- **SQL Server Management Studio**
- **Git**

---

### 1️⃣ Repository'yi Klonlama

GitHub repository'sini lokal bilgisayarınıza klonlayın.

    git clone https://github.com/yavuzsevimdev/VeterinaryClinicSystem.git

Ardından proje klasörüne geçin:

    cd VeterinaryClinicSystem

---

### 2️⃣ Solution'ı Açma

`VeterinaryClinicSystem.sln` dosyasını Visual Studio üzerinden açın.

Solution içerisinde aşağıdaki projeler bulunmaktadır:

- `VeterinaryClinic.Entities`
- `VeterinaryClinic.DataAccess`
- `VeterinaryClinic.Business`
- `VeterinaryClinic.API`
- `VeterinaryClinic.UI`

---

### 3️⃣ Veritabanı Yapılandırması

SQL Server'ın çalıştığından emin olun.

API projesinde kullanılacak `DefaultConnection` bağlantı bilgisini User Secrets üzerinden yapılandırın.

---

### 4️⃣ Migration'ları Uygulama

Visual Studio Package Manager Console üzerinden gerekli migration işlemlerini gerçekleştirin.

Migration'ların uygulanmasının ardından SQL Server üzerinde gerekli tablolar oluşturulacaktır.

---

### 5️⃣ API ve UI Projelerini Çalıştırma

API ve UI projelerinin startup olarak çalıştırılması gerekmektedir.

API projesi çalıştırıldığında Swagger arayüzü üzerinden API endpoint'lerine erişilebilir.

UI projesi çalıştırıldığında kullanıcı arayüzü üzerinden uygulama kullanılabilir.

---

### 6️⃣ Uygulamaya Giriş

Uygulama çalıştırıldıktan sonra:

- Customer hesabı oluşturabilir
- Customer olarak giriş yapabilir
- Manager hesabı ile yönetim işlemlerini gerçekleştirebilirsiniz.

Manager rolü ile test yapılacaksa ilgili kullanıcıya `Manager` rolünün atanmış olması gerekir.

---

## ⚙️ Configuration ve User Secrets

Projede hassas bilgilerin kaynak kod içerisinde tutulmaması amacıyla **ASP.NET Core User Secrets** kullanılmıştır.

Bu yapı özellikle development ortamında API anahtarları, bağlantı bilgileri ve authentication secret değerlerinin güvenli şekilde yönetilmesini sağlar.

### 🔐 Yönetilen Hassas Bilgiler

Projede User Secrets üzerinden aşağıdaki türde bilgiler yönetilmektedir:

- SQL Server Connection String
- JWT Key
- JWT Issuer
- JWT Audience
- OpenWeatherMap API Key
- SMTP / E-mail bilgileri

---

### 🗄️ Database Configuration

SQL Server bağlantı bilgisi `DefaultConnection` üzerinden okunmaktadır.

    ConnectionStrings
          │
          └── DefaultConnection
                    │
                    ▼
                SQL Server

Gerçek bağlantı bilgileri repository içerisinde tutulmamaktadır.

---

### 🎫 JWT Configuration

JWT authentication için gerekli secret ve doğrulama bilgileri configuration üzerinden okunmaktadır.

Kullanılan temel yapılandırmalar:

- `Jwt:Key`
- `Jwt:Issuer`
- `Jwt:Audience`

JWT Key gibi hassas değerler kaynak kod içerisinde bulunmamaktadır.

---

### 🌤️ OpenWeatherMap Configuration

OpenWeatherMap API anahtarı da User Secrets üzerinden yönetilmektedir.

Bu sayede harici servis için kullanılan API anahtarı GitHub repository'sine dahil edilmemektedir.

---

### 📧 SMTP Configuration

E-posta gönderiminde kullanılan SMTP bilgileri de configuration sistemi üzerinden yönetilmektedir.

SMTP kullanıcı adı ve parola gibi hassas bilgiler kaynak kodda saklanmamaktadır.

---

### 🚫 Hassas Bilgilerin GitHub'a Gönderilmemesi

Repository içerisinde gerçek secret değerleri bulunmamaktadır.

Ayrıca `.gitignore` içerisinde development ve secret dosyalarının repository'ye eklenmesini önlemeye yönelik kurallar bulunmaktadır.

Bu yaklaşım ile:

- API key'lerin korunması
- Database credentials bilgilerinin gizli tutulması
- JWT secret'ın korunması
- SMTP bilgilerinin gizli tutulması

amaçlanmıştır.

---

## 🧪 Testing ve Validation

Projenin geliştirme sürecinde temel modüller ve kullanıcı senaryoları manuel olarak test edilerek doğrulanmıştır.

Test sürecinde hem başarılı işlemler hem de yetkisiz erişim senaryoları kontrol edilmiştir.

### 🔐 Authentication Testleri

- Customer kayıt işlemi
- Customer login işlemi
- Hatalı kullanıcı adı / şifre kontrolü
- Logout işlemi
- Session expiration kontrolü

---

### 👥 Authorization Testleri

- Customer kullanıcısının Manager sayfalarına erişememesi
- Customer kullanıcısının başka bir Customer'a ait hayvana erişememesi
- Customer kullanıcısının başka bir Customer'a ait randevuya erişememesi
- Manager yetkilerinin kontrol edilmesi

---

### 🐾 Animal Testleri

- Hayvan oluşturma
- Hayvan güncelleme
- Hayvan detay görüntüleme
- Hayvan silme
- Kullanıcı sahipliği kontrolü
- Manager hayvan yönetimi

---

### 📅 Appointment Testleri

- Customer randevu oluşturma
- Manager randevu oluşturma
- Randevu güncelleme
- Randevu detay görüntüleme
- Randevu iptal işlemi
- Geçmiş tarihli randevu senaryoları
- Kullanıcı sahipliği kontrolü

---

### 💊 Treatment Testleri

- Tedavi oluşturma
- Tedavi güncelleme
- Tedavi silme
- Tedavi maliyetlerinin kontrol edilmesi
- Tedavi ve randevu ilişkisinin kontrol edilmesi
- Tedavi maliyetlerinin finansal süreçlere yansımasının kontrol edilmesi

---

### 💳 Payment Testleri

- Ödeme oluşturma
- Ödeme bilgilerinin görüntülenmesi
- Ödeme yöntemi kontrolü
- Randevu bazlı ödeme takibi
- Tedavi maliyeti ve ödeme karşılaştırması
- Kalan borç hesaplama

---

### 📊 Report Testleri

- Günlük rapor PDF oluşturma
- Aylık rapor PDF oluşturma
- Finansal rapor PDF oluşturma
- Hayvan tedavi geçmişi PDF oluşturma
- PDF indirme
- Yazdırma
- E-posta ile gönderim

---

### 🌤️ Weather Testleri

- OpenWeatherMap API bağlantısı
- Hava durumu verilerinin alınması
- Şehir bilgisinin kontrol edilmesi
- Sıcaklık ve açıklama bilgilerinin görüntülenmesi

---

### 📝 Logging ve Error Handling Testleri

- API exception senaryoları
- Global Error Handling Middleware
- Console log kontrolü
- File log kontrolü
- Beklenmeyen hatalarda merkezi response oluşturulması

---

### ✅ Genel Test Durumu

Projenin temel modülleri geliştirme sürecinde manuel olarak test edilmiş ve ana kullanıcı akışları doğrulanmıştır.

Authentication, Authorization, Animal, Appointment, Treatment, Payment, Report ve Weather modülleri üzerinde fonksiyonel kontroller gerçekleştirilmiştir.

Bazı ileri seviye edge-case senaryoları proje kapsamı dışında bırakılmıştır.

---

## 📁 Proje Durumu

Veterinary Clinic Management System projesinin temel geliştirme süreci tamamlanmıştır.

### ✅ Tamamlanan Modüller

- [x] ASP.NET Core 8 Web API
- [x] ASP.NET Core MVC UI
- [x] Layered Architecture
- [x] ASP.NET Core Identity
- [x] JWT Authentication
- [x] Cookie Authentication
- [x] Role-Based Authorization
- [x] Customer / Manager kullanıcı yapısı
- [x] Animal Management
- [x] Appointment Management
- [x] Treatment Management
- [x] Payment Management
- [x] Dashboard yapıları
- [x] OpenWeatherMap Integration
- [x] QuestPDF Integration
- [x] SMTP Email Integration
- [x] Daily Reports
- [x] Monthly Reports
- [x] Financial Reports
- [x] Animal Treatment History Reports
- [x] Swagger / OpenAPI
- [x] Serilog
- [x] Global Error Handling
- [x] Repository Pattern
- [x] Unit of Work
- [x] Entity Framework Core Code First
- [x] SQL Server
- [x] User Secrets
- [x] Manuel Functional Testing
- [x] Git / GitHub

---

### 🚀 Mevcut Durum

Proje temel gereksinimleri ve geliştirilen ana fonksiyonlarıyla birlikte çalışır durumdadır.

Geliştirme sürecinde temel kullanıcı senaryoları, authorization kontrolleri, veri işlemleri, raporlama, PDF, e-posta ve harici servis entegrasyonları test edilmiştir.

---

### 🔮 Gelecekte Eklenebilecek Özellikler

Projenin ilerleyen aşamalarında aşağıdaki özellikler eklenebilir:

- Online ödeme altyapısı
- Daha gelişmiş appointment validation
- Daha detaylı notification sistemi
- SMS entegrasyonu
- Gelişmiş dashboard analizleri
- Daha kapsamlı audit logging
- Daha gelişmiş filtreleme ve arama
- Unit ve Integration Test projeleri
- Docker containerization
- CI/CD pipeline

  ---

## 👨‍💻 Developer

### Yavuz Bahadır Sevim

**.NET Developer / Full Stack Web Developer**

ASP.NET Core ve .NET teknolojileri üzerine bireysel olarak projeler geliştiren ve gerçek dünya senaryolarına yönelik web uygulamaları üzerinde çalışan bir geliştiriciyim.

Bu projede özellikle:

- C#
- .NET 8
- ASP.NET Core
- ASP.NET Core MVC
- Web API
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- JWT
- Repository Pattern
- Unit of Work
- REST API
- PDF Generation
- SMTP Email
- OpenWeatherMap API
- Serilog

gibi teknolojiler üzerinde çalışarak full-stack bir veteriner klinik yönetim sistemi geliştirdim.

---

### 🔗 GitHub

[![GitHub](https://img.shields.io/badge/GitHub-yavuzsevimdev-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/yavuzsevimdev)

### 💼 LinkedIn

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Yavuz%20Bahadır%20Sevim-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/yavuz-bahadir-sevim-dev/)

---

### 📌 Proje Repository

[![Repository](https://img.shields.io/badge/GitHub-VeterinaryClinicSystem-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/yavuzsevimdev/VeterinaryClinicSystem)

---

### 📖 Proje Hakkında

Bu proje; katmanlı mimari, REST API, authentication, authorization, veritabanı yönetimi, harici servis entegrasyonları, raporlama ve modern kullanıcı arayüzü gibi farklı yazılım geliştirme konularını bir araya getiren kapsamlı bir çalışma olarak geliştirilmiştir.

Projenin geliştirilmesi sırasında yalnızca CRUD işlemlerine değil, aynı zamanda kullanıcı güvenliği, kaynak sahipliği, finansal takip, PDF oluşturma, e-posta gönderimi, loglama ve hata yönetimi gibi gerçek dünya uygulamalarında karşılaşılabilecek ihtiyaçlara da odaklanılmıştır.

---

⭐ Projeyi faydalı bulduysanız repository'yi inceleyebilir ve GitHub üzerinden projeyi takip edebilirsiniz.
    
