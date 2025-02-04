# README

Ovaj projekt napravljen je pomoću ekstenzije Katalon Recorder. Napravljeno je pet testova gdje se testiraju funkcionalnoti web stranice Fakulteta elektrotehnike, računarstva i informacijskih tehnologija ( https://www.ferit.unios.hr/)
Pomoću Katalon Recordera, možemo snimiti korake testiranja koje odradimo na svojem pregledniku. Katalon Recorder nakon snimljenih koraka generira kod za testiranje u proizvoljnom razvojonom okruženju.
Testovi su odrađeni u Visual studio C# NUNIT frameworku. Kako bi se testovi pokrenili, potrebno je klonirati repozitorij i instalirati sljedeće NuGet pakete

 - NUnit framework
 - Selenium WebDriver
 - Selenium Support
 - Nunit3 Test Adapter
 - Selenium WebDriver
 - 
Prilikom pravljenja novog TestCase-a i kopiranja generiranog koda u, potrebno je unutar TearDowna u try blocku dodati liniju koda driver.dispose() radi ispravnog pokretanja testa.

TestCase 1:
 - Dohvatiti podatke kolegija pomoću rasporeda studija

TestCase 2:

 - Dohvatiti podatke o profesoru koji predaje na kolegiju koji se nalazi na popisu predmeta studija
 
TestCase 3:
 - Provjeriti ispravnost linkova društvenih mreža koji se nalaze na stranici. Također provjeriti funkcionalnost prevođenja stranice na engleski/hrvatski jezik.

TestCase4:

 - Provjeriti funkcionalnost pregledavanja novih objava.

TestCase5:
- Provjeriti ispravno funkcioniranje rasporeda za studente.

