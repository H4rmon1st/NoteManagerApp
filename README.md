O aplicație simplă de tip Console App scrisă în C#, pentru gestionarea de note personale.  
Notele sunt salvate automat într-un fișier local (`notes.txt`), astfel încât să nu se piardă după închiderea aplicației.

## Funcționalități
- Adăugare de note noi
- Afișare lista de note existente
- Ștergere note după titlu
- Salvare automată a notelor într-un fișier text
- Încărcare automată a notelor la pornirea aplicației

## Tipuri de Note
- **Simple Note** – o notă normală
- **Important Note** – o notă evidențiată special

## Design Patterns utilizate
- **Factory Method** – pentru crearea diferitelor tipuri de note (`SimpleNote`, `ImportantNote`) prin `NoteFactory`.
- **Observer** – pentru notificarea utilizatorului la adăugare/ștergere de note (`INotifier` și `ConsoleNotifier`).

## Principii SOLID respectate
- **S**ingle Responsibility: fiecare clasă are un scop clar.
- **O**pen/Closed: codul poate fi extins fără a modifica clasele existente.
- **L**iskov Substitution: toate clasele moștenite pot fi folosite corect.
- **I**nterface Segregation: interfețele sunt mici și dedicate.
- **D**ependency Inversion: dependența pe interfețe, nu pe implementări concrete.
