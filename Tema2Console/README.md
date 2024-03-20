# Principiile SOLID în Proiect

## Single Responsibility Principle - SRP

**Motivul încălcării principiului**: Clasa `HotelReception` are prea multe responsabilități și coeziune scăzută, deci poate fi împărțită în mai multe clase mici cu coeziune ridicată.

**Implementare**:

- Crearea unei clase `Logger` care se ocupă doar de afișarea mesajelor în consolă.
- Crearea unei clase `FileReader` care se ocupă doar de citirea din fișier.
- Crearea unei clase `OrderDeserializer` care se ocupă doar de deserializarea obiectelor de tip `Order`.

**Rezultat**: Fiecare clasă are acum propria responsabilitate.

## Open/Closed Principle - OCP

**Motivul încălcării principiului**: Clasa `HotelReception` nu este deschisă pentru extindere, deoarece nu putem adăuga noi tipuri de obiecte de tip `Order` fără a modifica clasa.

**Implementare**:

- Crearea unei fabrici pentru crearea de procesori de comenzi. Clasa `ProcessorFactory` permite adăugarea de noi tipuri de procesori fără a modifica codul existent.

**Rezultat**: Pot fi introduse noi tipuri de comenzi (deschis pentru extindere), fără a fi necesar să modificăm codul existent (închis pentru modificare).

## Liskov Substitution Principle - LSP

**Motivul încălcării principiului**: Clasa `HotelReception` conține mai multe tipuri de comenzi care sunt procesate, iar acestea nu utilizează o clasă abstractă cu ajutorul căreia comenzile să poată fi înlocuite între ele fără a afecta programul.

**Implementare**:

- Crearea unei clase abstracte `Processor`.
- Crearea claselor `ProductOrderProcessor`, `BreakfastOrderProcessor`, `RoomOrderProcessor` și `UnknownOrderProcessor` care moștenesc clasa `Processor`.

**Rezultat**: Principiul LSP este respectat, deoarece clasele pot fi înlocuite între ele fără a fi afectat programul.

## Interface Segregation Principle - ISP

**Motivul încălcării principiului**: Programul nu utilizează interfețe, ceea ce înseamnă că este posibil ca clienții să depindă de metode pe care nu le utilizează.

**Implementare**:

- Crearea de interfețe mici și specifice, cum ar fi `IFileReader`, `IOrderDeserializer`, care sunt implementate de clasele care au nevoie de aceste comportamente.

**Rezultat**: Codul este mai puțin fragil, mai ușor de testat și mai puțin cuplat.

## Dependency Inversion Principle - DIP

**Motivul încălcării principiului**: Programul nu injectează dependințe în constructorul clasei `HotelReception`, aceasta depinzând de implementări concrete ale claselor utilizate.

**Implementare**:

- Injectarea dependințelor necesare (`ILogger`, `IFileReader`, `IOrderDeserializer`, `IProcessorFactory`) în constructorul clasei `HotelReception`.

**Rezultat**: Clasa `HotelReception` depinde acum de interfețe, ceea ce face codul mai flexibil și mai ușor de testat.
