# BorsaOdev
Merhabalar öncelikle proje basit bir borsa uygulaması mantığında çalışmaktadır.
Projemizde ürün satılacak ve aynı şekilde ürünü alınması gerekiyor.
Proje de 3 rol de kullanıcı var admin, alıcı ve satıcı.
Programımıza girişte kayıt ol butonumuz var satıcı=s , alıcı=a ve admin=m olarak rolleri seçip kullanıcı kayıt olması lazım.
Programa kayıt olduktan sonra kullanıcımız eğer satıcı ise ürün ekleme özelliği aktif olacak ve ürün ekleyebilecek ama aynı zaman ürün ekleme yaparken
direkt olarak yayınlanmayacak admin onay kısmına gidecek.
Kullanıcımız eğer alıcı ise satıcıların ne sattığını görebilecek ve sattığı şeyi alabilecekler ve son özellik olarak alıcının bir cüzdanı olacak cüzdanına parak eklemek
isterse eğer ne kadar ekleyeceğini yazacak ama direkt cüzdanı güncellenmeyecek admin onay kısmına gidecek eğer admin onaylarsa cüzdanına eklemek istediği miktar eklenecektir.
Eğer alıcı satıcıların herhangi bir ürününü almak isterse parası eğer varsa alabilecek parası eğer var ise cüzdanından o miktar düşülecek satıcının cüzdanına otomatikmen atılacak,
aynı zamanda aldığı kadar satıcının ürünün parası ona oranla artacaktır ve ürünün kilogram başı fiyatı artacaktır.
Borsa olan hacim mantığı gibi.
++
FİNAL
++
Alıcı bir ürün almak istediğinde eğer satılan o fiyata o kilogramda o ürün yok ise sistemde run-time çalışan fonksiyonumuz var her han fiyatı düşen kilogramı artan veya sisteme istediği bir ürünü girince otomatik alım gerçekleşiyor 
Alıcı ve Satıcı aldığı ve sattığı ürünleri excel olarak rapor alabiliyor
Aracı olarak muhasebe kullanıcımızı ekledik ve her üründen %1 lik bir komisyon kesiliyor bu parayı da alıcıdan tahsil ediliyor.
Artık alıcılarımız 4 farklı para birimi ile sistemimize para yükleyebilecekler bunlar sırasıyla ; USD,TL,EURO,GBP sistem anlık döviz kurunu çekip tl olarak cüzdanına ekliyor.
