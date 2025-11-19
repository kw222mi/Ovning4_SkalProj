# Teorisvar – Datastrukturer & Minne  
Det här dokumentet besvarar teorifrågorna om stack/heap, value/reference types och skillnaden mellan ReturnValue- och ReturnValue2-exemplen.

---

## 1. Hur fungerar stacken och heapen?

### Stacken
Stacken är ett snabbt och strukturerat minnesområde som används för:
- lokala variabler
- värdetyper (t.ex. int, double, bool, struct)
- metodanrop och deras parametrar

När en metod anropas läggs en **stack frame** ovanpå stacken som innehåller alla lokala variabler.  
När metoden avslutas tas hela stack-framen bort automatiskt.  
Det gör stacken mycket snabb och förutsägbar, men också begränsad i storlek.

### Heapen
Heapen är ett mer flexibelt minnesområde där **objekt** lagras, t.ex.:
- instanser av klasser
- arrayer
- listor
- strängar

När man skapar ett objekt (`new`) läggs det i heapen, och variabeln lagrar en **referens** dit.  
Minnet i heapen hanteras av .NET:s **Garbage Collector**, som automatiskt tar bort objekt som inte används längre.

**Kort sagt:**  
- Stack → snabb, strukturerad, lagrar värden och metoddata  
- Heap → flexibel, lagrar objekt som refereras av variabler

---

## 2. Vad är skillnaden mellan Value Types och Reference Types?

### Value Types
Exempel: `int`, `bool`, `double`, `char`, `struct`

Egenskaper:
- Lagrar **själva värdet**
- Kopieras vid tilldelning  
  → två variabler innehåller två separata värden
- Ligger oftast på stacken (om de är lokala variabler)

### Reference Types
Exempel: `class`, `array`, `string`, `List<T>`

Egenskaper:
- Variabeln innehåller en **referens** till ett objekt på heapen
- Flera variabler kan peka på samma objekt
- Ändringar via en variabel påverkar samma objekt för alla som pekar på det

**Kort sagt:**  
- Value types kopieras som värden  
- Reference types kopieras som pekare


---
## 3. Varför returnerar ReturnValue = 3 och ReturnValue2 = 4?

### ReturnValue (med int)
`int` är en value type.
När värdet skickas in i en metod skapas en kopia.
Ändringar i metoden påverkar bara kopian, inte originalet.

→ därför returneras **3**.

### ReturnValue2 (med MyInt)
`MyInt` är en reference type.
När en reference type skickas in i en metod kopieras bara referensen.
Både originalvariabeln och metodparametern pekar på samma objekt i heapen.

När metoden ändrar `Number` ändras alltså samma objekt.

→ därför returneras **4**.

---
## Sammanfattning

- Value types → kopieras → originalet ändras inte  
- Reference types → referenser kopieras → samma objekt ändras  
- Därför ger ReturnValue och ReturnValue2 olika resultat

