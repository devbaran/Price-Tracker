# Price Tracker / Fiyat Takip Projesi

![WebApp](https://user-images.githubusercontent.com/78992596/167325615-a028925d-3280-4312-91be-551296840275.png)

Bu uygulama e-ticaret sitelerindeki ürünlerin güncel fiyatlarını düzenli bir şekilde kontrol ederek; linki verilen ürünün, arzulanan fiyata düşmesi durumunda kullanıcının eposta yoluyla bilgilendirilmesini sağlar.

Uygulama şu şekilde çalışır;

İlk olarak istenen platform seçilir(amazon,trendyol). Ardından bu platformdaki seçilen ürünün linki girilir. Son olarak eposta ve düşmesi beklenen fiyat girilir. 
Form gönderildikten sonra kullanıcı (başarılı olması durumunda/ validasyonlardan geçtikten sonra) bu işlemin başarılı olduğuna dair bir sayfa görecektir.
Ürün istenen fiyata düştüğü anda kullanıcı otomatik olarak e-posta yoluyla bilgilendirilecektir.


TrackerApp klasöründe bulunan uygulama ile Web servisi sağlanıyor; e-ticaret platformu, ürün linki, istenen fiyat ve eposta adresi alınıp doğrudan veritabanına kaydediliyor.

ConsoleApp klasöründe ise; Web servisi aracılığıyla veritabanına kaydedilen bu veriler konsol uygulaması yardımıyla kontrol edilerek ürünler istenen fiyatlara düşmüş mü kontrol ediliyor.

Konsol uygulaması olması sayesinde Windows Task Scheduler kullanılarak(linux için CronJob olarak ayarlanabilir) bu console uygulamasının EXE'si seçilip, belirli aralıklarla/istenen sürelerle çalışması sağlanabiliyor. Örneğin bu uygulamayı her 30dk da bir çalıştır diyerek aslında veritabanında bulunan kayıtlardaki bütün fiyatları yarım saatte bir kontrol etmiş olacağız.
#### Küçük bir not :)
Ek olarak; uygulamada pek çok hata ve eksik mevcut. Ortalama 1 günde uygulamayı kabaca tamamlayarak refactoring etmeden doğrudan github üzerine aktardım. Mevcut hataları da elimden geldiğince kodların arasında notlarda belirtmeye çalıştım. Değerlendirme yapılacaksa tüm bunların göz önüne alınması çok daha sağlıklı olacaktır. SOLID prensiplerinin ezildiği, Database yönetiminin kötü olduğu pek çok nokta olduğunun farkındayım. İnsanlara kabaca fikir vermesi açısından basit bir proje ortaya koymak istedim, takıldığınız yerlerde iletişime geçerseniz seve seve yardımcı olacağım.

## Kullanılan Paketler/Teknolojiler
WebApp .NET 6 ile geliştirildi. Veritabanı olarak MSSQL kullanıldı. ConsoleApp ise .NET 5 ile geliştirildi

Uygulama içerisinde bulunan paketler: 

- Entity Framework (veritabanı bağlantıları)
- Html Agility Pack (web scraping)


## Veritabanı
Uygulamanın oldukça basit bir veritabanı mevcut; DbFirst yaklaşımı ile oluşturuldu.

Elbette tablo oluşturma biçimi hatalı, parçalara bölünerek daha doğru şekilde oluşturulabilir ve yönetimi kolaylaştırılabilir.
Uygulamayı hızla ayağa kaldırmak adına bu şekilde konfigüre edildi.

Marketplaces tablosunun App içerisinde CRUD işlemleri mevcut değil, doğrudan SSMS yardımıyla yönetilmekte.

Bunlar WebApp içerisine entegre edilerek daha sağlıklı bir uygulama oluşturulabilir.

![database](https://user-images.githubusercontent.com/78992596/167325588-a4950e75-e6eb-4578-9a36-4ce067602131.png)
