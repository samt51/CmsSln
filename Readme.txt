merhaba;
Content ve user olmak �zere 2 tane mikroservisim vard�r. Mikroservisler aralar�nda asenkron ileti�im i�in rabbit mq ve massTransit kulland�m.
Her servis kendi i�inde Onion Arch. d�zenine g�re in�a ettim. Veritaban� olarak PostgreSql ve her iki mikroserviste docker container �zerinden
aya�a kalkmaktad�r.
Her iki mikroservisim CQRS patterni ve mediatr kullanmaktay�m.Projede global error Middleware aktiftir bu sebeble �o�u yerde olumsuz y�nde sorgulamas� yoktur
bunun yerine Middleware yapmaktad�r bu nedenle tekrar eden kodlardan kurtar�lm�� olmu�tur.Ayr�c� bu Middleware sayesinde merkeze al�nm�� bir log sistemi kurulabilir.
Kendi mapper metodumu yazarak sistemde daha kolay kullan�m� sa�lam��t�r.
Content servis �zerinden user update i�lemi saga'n�n choreography g�re transaction sa�lad�m.
Content controller �zerinden user update action tetiklendi�inde handler k�sm�nda gelen userRequest modeli ilgili kuyru�a at�p
user taraf�nda o kuyru�u consume eden i�lemini yap�yor i�lem ba�ar�l� ile bu sefer completed event kuyru�a at�p content servis dinleme i�lemi yapmaktda�r.
Di�er actionlar i�in user getall action i�in userlar�n alt�nda ilgili userin contentleri listelendi�i yerde ve buna benzer di�er actionlarda 
a��rl�kl� olarak rabbitmq Rpc yolu ile ileti�ime ge�mektedir.