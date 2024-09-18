merhaba;
Content ve user olmak üzere 2 tane mikroservisim vardýr. Mikroservisler aralarýnda asenkron iletiþim için rabbit mq ve massTransit kullandým.
Her servis kendi içinde Onion Arch. düzenine göre inþa ettim. Veritabaný olarak PostgreSql ve her iki mikroserviste docker container üzerinden
ayaða kalkmaktadýr.
Her iki mikroservisim CQRS patterni ve mediatr kullanmaktayým.Projede global error Middleware aktiftir bu sebeble çoðu yerde olumsuz yönde sorgulamasý yoktur
bunun yerine Middleware yapmaktadýr bu nedenle tekrar eden kodlardan kurtarýlmýþ olmuþtur.Ayrýcý bu Middleware sayesinde merkeze alýnmýþ bir log sistemi kurulabilir.
Kendi mapper metodumu yazarak sistemde daha kolay kullanýmý saðlamýþtýr.
Content servis üzerinden user update iþlemi saga'nýn choreography göre transaction saðladým.
Content controller üzerinden user update action tetiklendiðinde handler kýsmýnda gelen userRequest modeli ilgili kuyruða atýp
user tarafýnda o kuyruðu consume eden iþlemini yapýyor iþlem baþarýlý ile bu sefer completed event kuyruða atýp content servis dinleme iþlemi yapmaktdaýr.
Diðer actionlar için user getall action için userlarýn altýnda ilgili userin contentleri listelendiði yerde ve buna benzer diðer actionlarda 
aðýrlýklý olarak rabbitmq Rpc yolu ile iletiþime geçmektedir.