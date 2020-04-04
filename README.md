Seamode projekin perus luku- ja kirjoitus luokat.

Yritetään saada hakemistopolut ja kirjoitettavien tiedostojen nimet application.config tiedostoon, jolloin niitä ei tarvitsisi kovakoodata ohejlmassa. Ohjeet löytyvät seuraavan linkin taka:

https://docs.microsoft.com/en-us/dotnet/framework/configure-apps/?redirectedfrom=MSDN

Seamode reader luokka saa hakee aloituspäivällä nimettyjä tiedostoja ohjelman hakemistosta ja lukee tiedostojen nimet List tyyppiseen muuttujaan. 

SeamodeReader Constructor

    Saa parametrina kaksi DateTime objektia. Aloitusajan ja lopetusajan. Näitä kahta vertailemaalla poimitaan rivit.

SeamodeReader haeTiedostot   

    lukee tiedosto ja palauttaa List tyyppisen objektin, jossa on tiedostojen nimet. Tämän hetkisessä versiossa on vain mahdollista hakea     vain yhden päivän aikan muodostuneita tiedostoja. 

    Metodi päivittä myös muuttujan, jossa on hakemiston nimi. Jatkossa käytettäneen toivon mukaan config tiedostoa.
    
SeamodeReader lueTiedosto

    Lukee yksittäisen tiedoston rivit ja ensimmäisellä kierroksella lukee sisään myös otsikkotiedot .

    Tarkistaa sopiiko tapahtuman aika haluttuun.
    
    
