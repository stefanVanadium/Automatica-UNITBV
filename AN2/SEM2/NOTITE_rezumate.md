# Status rezumate examen — unde am rămas (18.08.2026)

## Ce există deja
- `PS/Rezumat_Examen_PS.pdf` — făcut într-o sesiune anterioară, din cursuri + `Tematica examen PS`. Model de stil pentru toate celelalte (LaTeX dens, boxe roșii cu formule cheie, secțiune finală cu bilete rezolvate).
- `SAE/Rezumat_Examen_SAE.pdf` (+ `.tex`) — 7 pagini. Ponderat pe **6 bilete de examen SAE** găsite (poze WhatsApp), toate cu aceeași structură: 4 subiecte (funcție transfer prin matched/trapez/dreptunghi + eroare staționară + răspuns, curbă polară/amplitudine-fază, locul rădăcinilor discret, model variabile de stare + controlabilitate/observabilitate) + 5 întrebări de teorie de 1p. Secțiunea 16 = fișă rapidă cu tiparul biletelor.
- `TS 2/Rezumat_Examen_TS2.pdf` (+ `.tex`) — 6 pagini. Din curs (14 fișiere) + LABORATOARE.pdf + SEMINARII.pdf, plus **1 bilet real (sesiunea toamnă 2025)** găsit — secțiunea 19. Nu am destule bilete TS2 încă pentru un tipar clar ca la SAE.

## Cum diferențiezi un bilet SAE de unul TS2 (poze foarte asemănătoare!)
- **SAE** = sisteme discrete: apare `T_e` explicit, funcții `G_d(z)`, ERO, transformata matched/trapez/z, locul rădăcinilor **discret** (cerc unitar), curbă polară pe `z=e^{jωT_e}`.
- **TS2** = sisteme continue: funcții `G(s)`, Bode/curbă polară **continuă** (Nyquist clasic, fără `T_e`), locul rădăcinilor în semiplan (asimptote spre infinit, nu cerc), spațiu stărilor pentru circuite RLC, sisteme neliniare/liniarizare.
- Titularul e același pe ambele, deci nu ajută la diferențiere, verifică conținutul (z vs s, T_e prezent sau nu).

## Ce fac data viitoare când aduci poze noi
1. Le citesc, identific disciplina (SAE vs TS2, vezi mai sus) și sesiunea (dacă scrie pe foaie).
2. Dacă e SAE: actualizez `SAE/Rezumat_Examen_SAE.tex` — verific dacă subiectele confirmă tiparul din secțiunea 16 (4 subiecte fixe) sau aduc ceva nou; actualizez numărul de bilete + eventual adaug variante noi de metodă/formulare.
3. Dacă e TS2: actualizez `TS 2/Rezumat_Examen_TS2.tex` secțiunea 19 (sau creez secțiuni noi dacă apar subiecte complet diferite de RLC/Bode+eroare, ex. Nyquist complet, locul rădăcinilor continuu, sisteme neliniare).
4. Recompilez cu `pdflatex`, verific vizual paginile modificate (randare PNG + citire), șterg `.aux`/`.log`.

## De reținut
- Nu am găsit deloc materiale de curs pentru SAE 8-11 sau seminar 1,5 — user a confirmat că nu există, nu-i o lipsă de fișiere.
- La SAE, când un subiect arată o metodă (ex. trapez), tratez toată familia de metode (matched/MDS/MDF/trapez) în rezumat, pentru că biletele alternează între ele — cerință explicită a userului.
