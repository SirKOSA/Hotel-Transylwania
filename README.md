# Hotel Transylwania
Projekt zaliczeniowy z przedmiotu Środowisko Oprogramowania Komponentowego. Jest to interfejs API obsługujący hotel (sieć hoteli). Umożliwia zarządzanie pokojami, klientami, oraz rezerwacjami.

### Postęp prac
Na dzień dzisiejszy (18 stycznia 2020) jest dostępny Swagger UI do zarządzania interfejsem, a baza danych tworzona jest w pamięci RAM.

## Wymagania
* Visual Studio 2019 lub nowszy
* .NET Core 3.1 lub nowszy

## Obsługa
Przed uruchomieniem programu należy wpisać w:
  Narzędzia -> Menedżer pakietów NuGet -> Konsola menedżera pakietów
  
Polecenie:
  Update-Database

Po uruchomieniu programu, serwer z API działa pod jednym z dwóch adresów:
```
http://localhost:5000/
```
```
https://localhost:5001/
```

Z uwagi na brak GUI polecenia należy wysyłać za pośrednictwem programu Postman. Zapytania i odpowiedzi przesyłane są w formacie JSON. Obecnie API ma zaimplementowane trzy metody HTTP - POST, GET, PUT - oraz trzy klasy danych (tabele) znajdujące się pod adresami:
```
/api/Klient/
```
```
/api/Pokoj/
```
```
/api/Rezerwacje/
```
```
/api/Standard/
```
